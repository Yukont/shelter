using BLL.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Interfaces
{
    public interface IAdoptionStatusService : IDisposable
    {
        Task AddAdoptionStatus(AdoptionStatusDTO adoptionStatusDto);
        Task UpdateAdoptionStatus(AdoptionStatusDTO adoptionStatusDto);
        Task RemoveAdoptionStatus(int adoptionStatusId);
        Task<AdoptionStatusDTO> GetAdoptionStatusById(int adoptionStatusId);
        Task<IEnumerable<AdoptionStatusDTO>> GetAllAdoptionStatus();
    }
}
