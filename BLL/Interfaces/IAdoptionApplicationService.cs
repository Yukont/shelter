using BLL.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Interfaces
{
    public interface IAdoptionApplicationService : IDisposable
    {
        Task AddAdoptionApplication(AdoptionApplicationDTO adoptionApplicationDto);
        Task UpdateAdoptionApplication(AdoptionApplicationDTO adoptionApplicationDto);
        Task RemoveAdoptionApplication(int adoptionApplicationId);
        Task<AdoptionApplicationDTO> GetAdoptionApplicationById(int adoptionApplicationId);
        Task<IEnumerable<AdoptionApplicationDTO>> GetAllAdoptionApplications();
        Task<IEnumerable<AdoptionApplicationDTO>> GetAllAdoptionApplicationsByAnimalId(int id);
    }
}
