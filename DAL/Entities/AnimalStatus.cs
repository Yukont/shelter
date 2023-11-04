using System;
using System.Collections.Generic;

namespace shelter;

public partial class AnimalStatus
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public virtual ICollection<Animal> Animals { get; set; } = new List<Animal>();
}
