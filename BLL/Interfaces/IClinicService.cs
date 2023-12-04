using BLL.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Interfaces
{
    public interface IClinicService : IDisposable
    {
        Task AddClinic(ClinicDTO clinicDTO);
        Task UpdateClinic(ClinicDTO clinicDTO);
        Task RemoveClinic(int clinicId);
        Task<ClinicDTO> GetClinicId(int clinicId);
        Task<IEnumerable<ClinicDTO>> GetAllClinics();
    }
}
