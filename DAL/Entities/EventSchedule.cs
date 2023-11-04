using System;
using System.Collections.Generic;

namespace shelter;

public partial class EventSchedule
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public DateTime DateOf { get; set; }

    public TimeSpan TimeOf { get; set; }

    public string LocationOfEvent { get; set; } = null!;

    public string Descriptions { get; set; } = null!;
}
