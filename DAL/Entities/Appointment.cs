using System;
using System.Collections.Generic;

namespace DAL.Entities;

public partial class Appointment
{
    public int Id { get; set; }

    public int IdVeterinarian { get; set; }

    public int IdAnimal { get; set; }

    public string? Illnesses { get; set; }

    public string Descriptions { get; set; } = null!;

    public string? Prescriptions { get; set; }

    public DateTime DateOf { get; set; }

    public virtual Animal IdAnimalNavigation { get; set; } = null!;

    public virtual Veterinarian IdVeterinarianNavigation { get; set; } = null!;
}
