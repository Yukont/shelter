using System;
using System.Collections.Generic;

namespace DAL.Entities;

public partial class Species
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public virtual ICollection<Animal> Animals { get; set; } = new List<Animal>();
}
