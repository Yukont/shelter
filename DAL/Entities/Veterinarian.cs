using System;
using System.Collections.Generic;

namespace shelter;

public partial class Veterinarian
{
    public int Id { get; set; }

    public int IdStaff { get; set; }

    public int IdPosition { get; set; }

    public int IdClinic { get; set; }

    public int IdSpeciallization { get; set; }

    public int Experience { get; set; }

    public virtual ICollection<Appointment> Appointments { get; set; } = new List<Appointment>();

    public virtual Clinic IdClinicNavigation { get; set; } = null!;

    public virtual Position IdPositionNavigation { get; set; } = null!;

    public virtual Speciallization IdSpeciallizationNavigation { get; set; } = null!;

    public virtual Staff IdStaffNavigation { get; set; } = null!;
}
