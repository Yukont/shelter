using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace shelter.Models
{
    public class AnimalViewModel
    {
        public int Id { get; set; }

        public string Name { get; set; } = null!;

        public int IdSpecies { get; set; }

        public string? SpeciesName { get; set; }

        public int Age { get; set; }

        public int IdGender { get; set; }

        public string? GenderName { get; set; }

        public string DescriptionOfAnimal { get; set; } = null!;

        public string? Photo { get; set; }

        public int IdAnimalStatus { get; set; }

        public string? AnimalStatusName { get; set; }

        [BindProperty, DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime DateOf { get; set; }

        public int IdStatusOfHealth { get; set; }

        public string? StatusOfHealthName { get; set; } 

        public IEnumerable<SpeciesViewModel>? speciesViewModels { get; set; }
        public IEnumerable<GenderViewModel>? genderViewModels { get; set; }
        public IEnumerable<AnimalStatusViewModel>? animalStatusViewModels { get; set; }
        public IEnumerable<StatusOfHealthViewModel>? statusOfHealthViewModels { get; set; }

    }

    public class AnimalIndexModel
    {
        public IEnumerable<AnimalViewModel> animalViewModels { get; set; }
    }
}
