using System;
using System.Collections.Generic;

namespace shelter;

public partial class ShelterInformation
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public string? Address { get; set; }

    public string? Email { get; set; }

    public string? Descriptions { get; set; }

    public string? Phone { get; set; }
}
