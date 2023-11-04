using System;
using System.Collections.Generic;

namespace shelter;

public partial class AdoptionApplication
{
    public int Id { get; set; }

    public int? IdUser { get; set; }

    public int? IdAnimal { get; set; }

    public int? IdStatus { get; set; }

    public virtual Animal? IdAnimalNavigation { get; set; }

    public virtual AdoptionStatus? IdStatusNavigation { get; set; }

    public virtual User? IdUserNavigation { get; set; }
}
