namespace shelter.Models
{
    public class AdoptionStatusViewModel
    {
        public int Id { get; set; }

        public string Name { get; set; } = null!;
    }

    public class AdoptionStatusIndexModel
    {
        public IEnumerable<AdoptionStatusViewModel> adoptionStatusIndexModels { get; set; }
    }
}
