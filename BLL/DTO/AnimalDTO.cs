using DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.DTO
{
    public class AnimalDTO
    {
        public int Id { get; set; }

        public string Name { get; set; } = null!;

        public int IdSpecies { get; set; }

        public string? SpeciesName { get; set;} = null!;

        public int Age { get; set; }

        public int IdGender { get; set; }

        public string? GenderName { get; set; } = null!;

        public string DescriptionOfAnimal { get; set; } = null!;

        public string? Photo { get; set; }

        public int IdAnimalStatus { get; set; }

        public string? AnimalStatusName { get; set; } = null!;

        public DateTime DateOf { get; set; }

        public int IdStatusOfHealth { get; set; }

        public string? StatusOfHealthName { get; set; } = null!;

        public IEnumerable<AdoptionApplicationDTO>? adoptionApplicationViewModels { get; set; }
    }
}
