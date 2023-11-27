using Microsoft.EntityFrameworkCore;
using shelter;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repositories
{
    public class SpeciallizationRepository : BaseRepository<Speciallization>
    {
        internal SpeciallizationRepository(DbContext dbContext) : base(dbContext)
        {
        }
    }
}
