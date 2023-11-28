using AutoMapper;
using BLL.DTO;
using BLL.Interfaces;
using DAL.Interfaces;
using shelter;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Services
{
    public class AdoptionStatusService : IAdoptionStatusService
    {
        private readonly IUnitOfWork unitOfWork;

        private readonly IMapper mapper;

        public AdoptionStatusService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            this.unitOfWork = unitOfWork;
            this.mapper = mapper;
        }
        public async Task AddAdoptionStatus(AdoptionStatusDTO adoptionStatusDto)
        {
            AdoptionStatus adoptionStatus = mapper.Map<AdoptionStatusDTO, AdoptionStatus>(adoptionStatusDto);

            await unitOfWork.AdoptionStatus.CreateAsync(adoptionStatus);
            unitOfWork.Save();
        }

        public void Dispose()
        {
            unitOfWork.Dispose();
        }

        public async Task<AdoptionStatusDTO> GetAdoptionStatusById(int adoptionStatusId)
        {
            AdoptionStatus adoptionStatus = await unitOfWork.AdoptionStatus.GetAsync(adoptionStatusId);

            AdoptionStatusDTO adoptionStatusDto = mapper.Map<AdoptionStatus, AdoptionStatusDTO>(adoptionStatus);
            return adoptionStatusDto;
        }

        public async Task<IEnumerable<AdoptionStatusDTO>> GetAllAdoptionStatus()
        {
            IEnumerable<AdoptionStatus> adoptionStatus = await unitOfWork.AdoptionStatus.GetAllAsync();
            return mapper.Map<IEnumerable<AdoptionStatus>, IEnumerable<AdoptionStatusDTO>>(adoptionStatus);
        }

        public async Task RemoveAdoptionStatus(int adoptionStatusId)
        {
            AdoptionStatus adoptionStatus = await unitOfWork.AdoptionStatus.GetAsync(adoptionStatusId);

            await unitOfWork.AdoptionStatus.DeleteAsync(adoptionStatusId);
            unitOfWork.Save();
        }

        public async Task UpdateAdoptionStatus(AdoptionStatusDTO adoptionStatusDto)
        {
            AdoptionStatus updatedAdoptionStatus = mapper.Map<AdoptionStatusDTO, AdoptionStatus>(adoptionStatusDto);

            await unitOfWork.AdoptionStatus.UpdateAsync(updatedAdoptionStatus);
            unitOfWork.Save();
        }
    }
}
