namespace shelter.Models
{
    public class StatusOfHealthViewModel
    {
        public int Id { get; set; }

        public string Name { get; set; } = null!;
    }

    public class StatusOfHealthIndexModel
    {
        public IEnumerable<StatusOfHealthViewModel> statusOfHealthViewModel { get; set; }
    }
}

