using System;
using System.Collections.Generic;

namespace DAL.Entities;

public partial class Staff
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public int IdUserRole { get; set; }

    public string Contacts { get; set; } = null!;

    public string WorkSchedule { get; set; } = null!;

    public int IdAuth { get; set; }

    public virtual Auth IdAuthNavigation { get; set; } = null!;

    public virtual UserRole IdUserRoleNavigation { get; set; } = null!;

    public virtual ICollection<Veterinarian> Veterinarians { get; set; } = new List<Veterinarian>();
}
