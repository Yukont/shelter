using System;
using System.Collections.Generic;

namespace shelter;

public partial class Speciallization
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public virtual ICollection<Veterinarian> Veterinarians { get; set; } = new List<Veterinarian>();
}
