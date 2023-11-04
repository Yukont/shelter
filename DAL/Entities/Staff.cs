using System;
using System.Collections.Generic;

namespace shelter;

public partial class Staff
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public int? IdStaffRole { get; set; }

    public string Contacts { get; set; } = null!;

    public string WorkSchedule { get; set; } = null!;

    public virtual StaffRole? IdStaffRoleNavigation { get; set; }

    public virtual ICollection<Veterinarian> Veterinarians { get; set; } = new List<Veterinarian>();
}
