using System;
using System.Collections.Generic;

namespace shelter;

public partial class User
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public int? IdUserRole { get; set; }

    public string? Address { get; set; }

    public string? Email { get; set; }

    public int IdUserGender { get; set; }

    public int Experience { get; set; }

    public string Phone { get; set; } = null!;

    public virtual ICollection<AdoptionApplication> AdoptionApplications { get; set; } = new List<AdoptionApplication>();

    public virtual ICollection<Donation> Donations { get; set; } = new List<Donation>();

    public virtual UsersGender IdUserGenderNavigation { get; set; } = null!;

    public virtual UserRole? IdUserRoleNavigation { get; set; }

    public virtual ICollection<Review> Reviews { get; set; } = new List<Review>();
}
