namespace shelter.Models
{
    public class SpeciesViewModel
    {
        public int Id { get; set; }

        public string Name { get; set; } = null!;
    }

    public class SpeciesIndexModel
    {
        public IEnumerable<SpeciesViewModel> speciesViewModels { get; set; }
    }
}
