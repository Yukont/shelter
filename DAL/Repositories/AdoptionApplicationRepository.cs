using Microsoft.EntityFrameworkCore;
using shelter;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repositories
{
    public class AdoptionApplicationRepository : BaseRepository<AdoptionApplication>
    {
        internal AdoptionApplicationRepository(DbContext dbContext) : base(dbContext)
        {
        }
    }
}
