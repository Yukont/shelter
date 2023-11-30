using System;
using System.Collections.Generic;

namespace DAL.Entities;

public partial class Clinic
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public virtual ICollection<Veterinarian> Veterinarians { get; set; } = new List<Veterinarian>();
}
