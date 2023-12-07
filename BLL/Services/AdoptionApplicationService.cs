using AutoMapper;
using BLL.DTO;
using BLL.Interfaces;
using DAL.Entities;
using DAL.Interfaces;

namespace BLL.Services
{
    public class AdoptionApplicationService : IAdoptionApplicationService
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly IMapper mapper;

        public AdoptionApplicationService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            this.unitOfWork = unitOfWork;
            this.mapper = mapper;
        }
        public async Task AddAdoptionApplication(AdoptionApplicationDTO adoptionApplicationDTO)
        {
            AdoptionApplication adoptionApplication = mapper.Map<AdoptionApplicationDTO, AdoptionApplication>(adoptionApplicationDTO);
            await unitOfWork.AdoptionApplication.CreateAsync(adoptionApplication);
            unitOfWork.Save();
        }

        public void Dispose()
        {
            unitOfWork.Dispose();
        }

        public async Task<IEnumerable<AdoptionApplicationDTO>> GetAllAdoptionApplications()
        {
            IEnumerable<AdoptionApplication> adoptionApplications = await unitOfWork.AdoptionApplication.GetAllAsync();
            return mapper.Map<IEnumerable<AdoptionApplication>, IEnumerable<AdoptionApplicationDTO>>(adoptionApplications);
        }

        public async Task<AdoptionApplicationDTO> GetAdoptionApplicationById(int adoptionApplicationId)
        {
            AdoptionApplication adoptionApplication = await unitOfWork.AdoptionApplication.GetAsync(adoptionApplicationId);
            return mapper.Map<AdoptionApplication, AdoptionApplicationDTO>(adoptionApplication);
        }

        public async Task RemoveAdoptionApplication(int adoptionApplicationId)
        {
            await unitOfWork.AdoptionApplication.DeleteAsync(adoptionApplicationId);
            unitOfWork.Save();
        }

        public async Task UpdateAdoptionApplication(AdoptionApplicationDTO adoptionApplicationDTO)
        {
            AdoptionApplication adoptionApplication = mapper.Map<AdoptionApplicationDTO, AdoptionApplication>(adoptionApplicationDTO);
            await unitOfWork.AdoptionApplication.UpdateAsync(adoptionApplication);
            unitOfWork.Save();
        }
    }
}
