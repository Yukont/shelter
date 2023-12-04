using System;
using System.Collections.Generic;

namespace DAL.Entities;

public partial class UsersGender
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public virtual ICollection<User> Users { get; set; } = new List<User>();
}
