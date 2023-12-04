using AutoMapper;
using BLL.DTO;
using BLL.Interfaces;
using DAL.Entities;
using DAL.Interfaces;

namespace BLL.Services
{
    public class AnimalStatusService : IAnimalStatusService
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly IMapper mapper;
        public AnimalStatusService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            this.unitOfWork = unitOfWork;
            this.mapper = mapper;
        }
        public async Task AddAnimalStatus(AnimalStatusDTO animalStatusDTO)
        {
            AnimalStatus animalStatus = mapper.Map<AnimalStatusDTO, AnimalStatus>(animalStatusDTO);
            await unitOfWork.AnimalStatus.CreateAsync(animalStatus);
            unitOfWork.Save();
        }

        public void Dispose()
        {
            unitOfWork.Dispose();
        }

        public async Task<IEnumerable<AnimalStatusDTO>> GetAllAnimalStatus()
        {
            IEnumerable<AnimalStatus> animalStatuses = await unitOfWork.AnimalStatus.GetAllAsync();
            return mapper.Map<IEnumerable<AnimalStatus>, IEnumerable<AnimalStatusDTO>>(animalStatuses);
        }

        public async Task<AnimalStatusDTO> GetAnimalSatusById(int animalStatusId)
        {
            AnimalStatus animalStatus = await unitOfWork.AnimalStatus.GetAsync(animalStatusId);
            return mapper.Map<AnimalStatus, AnimalStatusDTO>(animalStatus);
        }

        public async Task RemoveAnimalSatus(int animalStatusId)
        {
            await unitOfWork.AnimalStatus.DeleteAsync(animalStatusId);
            unitOfWork.Save();
        }

        public async Task UpdateAnimalStatus(AnimalStatusDTO animalStatusDTO)
        {
            AnimalStatus animalStatus = mapper.Map<AnimalStatusDTO, AnimalStatus>(animalStatusDTO);
            await unitOfWork.AnimalStatus.UpdateAsync(animalStatus);
            unitOfWork.Save();
        }
    }
}
