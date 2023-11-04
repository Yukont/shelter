using System;
using System.Collections.Generic;

namespace shelter;

public partial class StaffRole
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public virtual ICollection<Staff> Staff { get; set; } = new List<Staff>();
}
