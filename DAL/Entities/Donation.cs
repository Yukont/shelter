using System;
using System.Collections.Generic;

namespace shelter;

public partial class Donation
{
    public int Id { get; set; }

    public DateTime DateOf { get; set; }

    public int IdUser { get; set; }

    public int Donation1 { get; set; }

    public virtual User IdUserNavigation { get; set; } = null!;
}
