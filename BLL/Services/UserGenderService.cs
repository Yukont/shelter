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
    public class UserGenderService : IUserGenderService
    {
        private readonly IUnitOfWork unitOfWork;

        private readonly IMapper mapper;
        public UserGenderService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            this.unitOfWork = unitOfWork;
            this.mapper = mapper;
        }
        public void Dispose()
        {
            unitOfWork.Dispose();
        }

        public async Task<IEnumerable<UsersGenderDTO>> GetAllUserGender()
        {
            IEnumerable<UsersGender> usersGender = await unitOfWork.UsersGender.GetAllAsync();
            return mapper.Map<IEnumerable<UsersGender>, IEnumerable<UsersGenderDTO>>(usersGender);
        }
    }
}
