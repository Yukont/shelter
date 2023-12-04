namespace shelter.Models
{
    public class AnimalStatusViewModel
    {
        public int Id { get; set; }

        public string Name { get; set; } = null!;
    }

    public class AnimalStatusIndexModel
    {
        public IEnumerable<AnimalStatusViewModel> animalStatusIndexModels { get; set; }
    }
}
