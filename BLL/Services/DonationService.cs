using AutoMapper;
using BLL.DTO;
using BLL.Interfaces;
using DAL.Entities;
using DAL.Interfaces;

namespace BLL.Services
{
    public class DonationService : IDonationService
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly IMapper mapper;

        public DonationService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            this.unitOfWork = unitOfWork;
            this.mapper = mapper;
        }
        public async Task AddDonation(DonationDTO donationDTO)
        {
            Donation donation = mapper.Map<DonationDTO, Donation>(donationDTO);
            await unitOfWork.Donation.CreateAsync(donation);
            unitOfWork.Save();
        }

        public void Dispose()
        {
            unitOfWork.Dispose();
        }

        public async Task<IEnumerable<DonationDTO>> GetAllDonations()
        {
            IEnumerable<Donation> donations = await unitOfWork.Donation.GetAllAsync();
            return mapper.Map<IEnumerable<Donation>, IEnumerable<DonationDTO>>(donations);
        }

        public async Task<DonationDTO> GetDonationById(int donationId)
        {
            Donation donation = await unitOfWork.Donation.GetAsync(donationId);
            return mapper.Map<Donation, DonationDTO>(donation);
        }

        public async Task RemoveDonation(int donationId)
        {
            await unitOfWork.Donation.DeleteAsync(donationId);
            unitOfWork.Save();
        }

        public async Task UpdateDonation(DonationDTO donationDTO)
        {
            Donation donation = mapper.Map<DonationDTO, Donation>(donationDTO);
            await unitOfWork.Donation.UpdateAsync(donation);
            unitOfWork.Save();
        }
    }
}
