using System;
using System.Collections.Generic;

namespace shelter;

public partial class Animal
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public int IdSpecies { get; set; }

    public int Age { get; set; }

    public int IdGender { get; set; }

    public string DescriptionOfAnimal { get; set; } = null!;

    public string? Photo { get; set; }

    public int IdAnimalStatus { get; set; }

    public string DateOf { get; set; } = null!;

    public int IdStatusOfHealth { get; set; }

    public virtual ICollection<AdoptionApplication> AdoptionApplications { get; set; } = new List<AdoptionApplication>();

    public virtual ICollection<Appointment> Appointments { get; set; } = new List<Appointment>();

    public virtual AnimalStatus IdAnimalStatusNavigation { get; set; } = null!;

    public virtual Gender IdGenderNavigation { get; set; } = null!;

    public virtual Species IdSpeciesNavigation { get; set; } = null!;

    public virtual StatusOfHealth IdStatusOfHealthNavigation { get; set; } = null!;
}
