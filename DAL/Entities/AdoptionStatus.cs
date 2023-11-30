using System;
using System.Collections.Generic;

namespace DAL.Entities;

public partial class AdoptionStatus
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public virtual ICollection<AdoptionApplication> AdoptionApplications { get; set; } = new List<AdoptionApplication>();
}
