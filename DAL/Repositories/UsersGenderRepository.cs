﻿using Microsoft.EntityFrameworkCore;
using shelter;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repositories
{
    internal class UsersGenderRepository : BaseRepository<UsersGender>
    {
        internal UsersGenderRepository(DbContext dbContext) : base(dbContext)
        {
        }
    }
}
