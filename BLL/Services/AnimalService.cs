using AutoMapper;
using BLL.DTO;
using BLL.Interfaces;
using DAL.Entities;
using DAL.Interfaces;

namespace BLL.Services
{
    public class AnimalService : IAnimalService
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly IMapper mapper;

        public AnimalService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            this.unitOfWork = unitOfWork;
            this.mapper = mapper;
        }
        public async Task AddAnimal(AnimalDTO animalDTO)
        {
            Animal animal = mapper.Map<AnimalDTO, Animal>(animalDTO);
            await unitOfWork.Animal.CreateAsync(animal);
            unitOfWork.Save();
        }

        public void Dispose()
        {
            unitOfWork.Dispose();
        }

        public async Task<IEnumerable<AnimalDTO>> GetAllAnimals()
        {
            IEnumerable<Animal> animals = await unitOfWork.Animal.GetAllAsync();
            return mapper.Map<IEnumerable<Animal>, IEnumerable<AnimalDTO>>(animals);
        }

        public async Task<AnimalDTO> GetAnimalId(int animalId)
        {
            Animal animal = await unitOfWork.Animal.GetAsync(animalId);
            return mapper.Map<Animal, AnimalDTO>(animal);
        }

        public async Task RemoveAnimal(int animalId)
        {
            await unitOfWork.Animal.DeleteAsync(animalId);
            unitOfWork.Save();
        }

        public async Task UpdateAnimal(AnimalDTO animalDTO)
        {
            Animal animal = mapper.Map<AnimalDTO, Animal>(animalDTO);
            await unitOfWork.Animal.UpdateAsync(animal);
            unitOfWork.Save();
        }
    }
}
