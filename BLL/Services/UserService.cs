using AutoMapper;
using BLL.DTO;
using BLL.Interfaces;
using DAL.Entities;
using DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Services
{
    public class UserService : IUserService
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly IMapper mapper;

        public UserService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            this.unitOfWork = unitOfWork;
            this.mapper = mapper;
        }
        public async Task AddUser(UserDTO userDTO)
        {
            User user = mapper.Map<UserDTO, User>(userDTO);
            await unitOfWork.User.CreateAsync(user);
            unitOfWork.Save();
        }

        public void Dispose()
        {
            unitOfWork.Dispose();
        }

        public async Task<IEnumerable<UserDTO>> GetAllUsers()
        {
            IEnumerable<User> users = await unitOfWork.User.GetAllAsync();
            return mapper.Map<IEnumerable<User>, IEnumerable<UserDTO>>(users);
        }

        public async Task<UserDTO> GetUserById(int userId)
        {
            User user = await unitOfWork.User.GetAsync(userId);
            return mapper.Map<User, UserDTO>(user);
        }

        public async Task RemoveUser(int userId)
        {
            await unitOfWork.User.DeleteAsync(userId);
            unitOfWork.Save();
        }

        public async Task UpdateUser(UserDTO userDTO)
        {
            User user = mapper.Map<UserDTO, User>(userDTO);
            await unitOfWork.User.UpdateAsync(user);
            unitOfWork.Save();
        }
    }
}
