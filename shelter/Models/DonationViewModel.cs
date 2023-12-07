namespace shelter.Models
{
    public class DonationViewModel
    {
        public int Id { get; set; }

        public DateTime DateOf { get; set; }

        public int IdUser { get; set; }

        public string UserName { get; set; } = null!;

        public int Donation1 { get; set; }
    }

    public class DonationIndexModel
    {
        public IEnumerable<DonationViewModel> donationViewModels { get; set; }
    }
}
