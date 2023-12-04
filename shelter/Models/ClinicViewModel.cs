namespace shelter.Models
{
    public class ClinicViewModel
    {
        public int Id { get; set; }

        public string Name { get; set; } = null!;
    }

    public class ClinicIndexModel
    {
        public IEnumerable<ClinicViewModel> clinicViewModels { get; set; }
    }
}
