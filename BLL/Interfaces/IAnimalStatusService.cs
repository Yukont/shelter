using BLL.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Interfaces
{
    public interface IAnimalStatusService : IDisposable
    {
        Task AddAnimalStatus(AnimalStatusDTO animalStatusDTO);
        Task UpdateAnimalStatus(AnimalStatusDTO animalStatusDTO);
        Task RemoveAnimalSatus(int animalStatusId);
        Task<AnimalStatusDTO> GetAnimalSatusById(int animalStatusId);
        Task<IEnumerable<AnimalStatusDTO>> GetAllAnimalStatus();
    }
}
