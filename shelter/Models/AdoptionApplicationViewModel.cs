namespace shelter.Models
{
    public class AdoptionApplicationViewModel
    {
        public int Id { get; set; }

        public int IdUser { get; set; }

        public string UserName { get; set; } = null!;

        public int IdAnimal { get; set; }

        public string AnimalName { get; set; } = null!;

        public int IdStatus { get; set; }

        public string StatusName { get; set; } = null!;

        public IEnumerable<AdoptionStatusViewModel>? adoptionStatusViewModels { get; set; }
    }

    public class AdoptionApplicationIndexModel
    {
        public IEnumerable<AdoptionApplicationViewModel> adoptionApplicationViewModels { get; set; }
    }
}
