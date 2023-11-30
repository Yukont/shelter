using System;
using System.Collections.Generic;

namespace DAL.Entities;

public partial class Review
{
    public int Id { get; set; }

    public DateTime DateOf { get; set; }

    public int IdUser { get; set; }

    public int Rating { get; set; }

    public string Review1 { get; set; } = null!;

    public virtual User IdUserNavigation { get; set; } = null!;
}
