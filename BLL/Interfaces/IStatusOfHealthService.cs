using BLL.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Interfaces
{
    public interface IStatusOfHealthService : IDisposable
    {
        Task AddStatusOfHealth(StatusOfHealthDTO statusOfHealthDTO);
        Task UpdateStatusOfHealth(StatusOfHealthDTO statusOfHealthDTO);
        Task RemoveStatusOfHealth(int statusOfHealthId);
        Task<StatusOfHealthDTO> GetStatusOfHealthId(int statusOfHealthId);
        Task<IEnumerable<StatusOfHealthDTO>> GetAllStatusOfHealths();
    }
}
