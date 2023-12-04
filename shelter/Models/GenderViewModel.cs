namespace shelter.Models
{
    public class GenderViewModel
    {
        public int Id { get; set; }

        public string Name { get; set; } = null!;
    }

    public class GenderIndexModel
    {
        public IEnumerable<GenderViewModel> genderViewModels { get; set; }
    }
}
