using AutoMapper;
using BLL.DTO;
using BLL.Interfaces;
using DAL.EFUnitOfWork;
using DAL.Entities;
using DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Numerics;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Services
{
    public class AccountService : IAccountService
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly IMapper mapper;

        public AccountService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            this.unitOfWork = unitOfWork;
            this.mapper = mapper;
        }
        public async Task<ClaimsIdentity> Login(AuthDTO authDTO)
        {
            try
            {
                var login = await unitOfWork.Auth.GetByLoginAsync(authDTO.Login);
                if (login == null)
                {
                    throw new ValidationException("Пользователь не найден");
                }

                if (login.Password != authDTO.Password)
                {
                    throw new ValidationException($"Неверный логин или пароль");
                }

                // Поиск логина и пароля по идентификатору
                User user = await unitOfWork.User.GetUserByIdAuth(login.Id);
                if (user == null)
                    throw new ValidationException("Пользователь не найден");

                UserDTO customerDTO = mapper.Map<User, UserDTO>(user);

                var result = Authenticate(customerDTO);

                return result;
            }
            catch (Exception ex)
            {
                throw new ValidationException(ex.Message);
            }
        }

        public async Task<ClaimsIdentity> Register(AuthDTO authDTO, UserDTO userDTO)
        {
            try
            {
                await CheakLoginAsync(authDTO.Login);

                // Валидация данных 
                if (string.IsNullOrEmpty(authDTO.Login.ToString()))
                    throw new ValidationException("Логин не может быть пустым");
                if (string.IsNullOrEmpty(authDTO.Password.ToString()))
                    throw new ValidationException("Пароль не может быть пустым");

                await unitOfWork.Auth.CreateAsync(mapper.Map<AuthDTO, Auth>(authDTO));
                unitOfWork.Save();

                Auth lastAuth = await unitOfWork.Auth.GetLastAsync();
                if (lastAuth == null)
                    throw new ValidationException("Логин и пароль не найдены");

                AuthDTO lastLoginDTO = mapper.Map<Auth, AuthDTO>(lastAuth);

                var user = new UserDTO()
                {
                    IdAuth = lastLoginDTO.Id,
                    IdUserRole = 2,
                    Name = userDTO.Name,
                    Address = userDTO.Address,
                    Email = userDTO.Email,
                    IdUserGender = userDTO.IdUserGender,
                    Experience = userDTO.Experience,
                    Phone = userDTO.Phone
                };

                await unitOfWork.User.CreateAsync(mapper.Map<UserDTO, User>(user));
                unitOfWork.Save();

                var result = Authenticate(user);

                return result;

            }
            catch
            {
                throw new ValidationException("Не работает");
            }
        }
        private ClaimsIdentity Authenticate(UserDTO user)
        {
            var claims = new List<Claim>
            {
                new Claim(ClaimsIdentity.DefaultNameClaimType, user.Id.ToString()),
                new Claim(ClaimsIdentity.DefaultRoleClaimType, user.IdUserRole.ToString())
            };
            return new ClaimsIdentity(claims, "ApplicationCookie",
                ClaimsIdentity.DefaultNameClaimType, ClaimsIdentity.DefaultRoleClaimType);
        }

        public async Task<bool> CheakLoginAsync(string inputLogin)
        {
            var login = await unitOfWork.Auth.GetByLoginAsync(inputLogin);
            if (login != null)
            {
                throw new ValidationException("Такое имя уже занято");
            }
            return true;
        }
    }
}
