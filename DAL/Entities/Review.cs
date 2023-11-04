using System;
using System.Collections.Generic;

namespace shelter;

public partial class Review
{
    public int Id { get; set; }

    public DateTime DateOf { get; set; }

    public int? IdUser { get; set; }

    public int Rating { get; set; }

    public string Review1 { get; set; } = null!;

    public virtual User? IdUserNavigation { get; set; }
}
