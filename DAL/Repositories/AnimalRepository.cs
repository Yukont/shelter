using Microsoft.EntityFrameworkCore;
using shelter;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repositories
{
    internal class AnimalRepository : BaseRepository<Animal>
    {
        protected AnimalRepository(DbContext dbContext) : base(dbContext)
        {
        }
    }
}
