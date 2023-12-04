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
    public class GenderService : IGenderService
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly IMapper mapper;

        public GenderService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            this.unitOfWork = unitOfWork;
            this.mapper = mapper;
        }
        public async Task AddGender(GenderDTO genderDTO)
        {
            Gender gender = mapper.Map<GenderDTO, Gender>(genderDTO);
            await unitOfWork.Gender.CreateAsync(gender);
            unitOfWork.Save();
        }

        public void Dispose()
        {
            unitOfWork.Dispose();
        }

        public async Task<IEnumerable<GenderDTO>> GetAllGenders()
        {
            IEnumerable<Gender> genders = await unitOfWork.Gender.GetAllAsync();
            return mapper.Map<IEnumerable<Gender>, IEnumerable<GenderDTO>>(genders);
        }

        public async Task<GenderDTO> GetGenderId(int genderId)
        {
            Gender gender = await unitOfWork.Gender.GetAsync(genderId);
            return mapper.Map<Gender, GenderDTO>(gender);
        }

        public async Task RemoveGender(int genderId)
        {
            await unitOfWork.Gender.DeleteAsync(genderId);
            unitOfWork.Save();
        }

        public async Task UpdateGender(GenderDTO genderDTO)
        {
            Gender gender = mapper.Map<GenderDTO, Gender>(genderDTO);
            await unitOfWork.Gender.UpdateAsync(gender);
            unitOfWork.Save();
        }
    }
}
