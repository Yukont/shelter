using BLL.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Interfaces
{
    public interface IAnimalService : IDisposable
    {
        Task AddAnimal(AnimalDTO animalDTO);
        Task UpdateAnimal(AnimalDTO animalDTO);
        Task RemoveAnimal(int animalId);
        Task<AnimalDTO> GetAnimalId(int animalId);
        Task<IEnumerable<AnimalDTO>> GetAllAnimals();
    }
}
