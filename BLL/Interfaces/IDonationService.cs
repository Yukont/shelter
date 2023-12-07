using BLL.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Interfaces
{
    public interface IDonationService : IDisposable
    {
        Task AddDonation(DonationDTO donationDTO);
        Task UpdateDonation(DonationDTO donationDTO);
        Task RemoveDonation(int donationId);
        Task<DonationDTO> GetDonationById(int donationId);
        Task<IEnumerable<DonationDTO>> GetAllDonations();
    }
}
