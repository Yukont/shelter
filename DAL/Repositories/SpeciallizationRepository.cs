﻿using Microsoft.EntityFrameworkCore;
using shelter;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repositories
{
    internal class SpeciallizationRepository : BaseRepository<Speciallization>
    {
        protected SpeciallizationRepository(DbContext dbContext) : base(dbContext)
        {
        }
    }
}