using Microsoft.EntityFrameworkCore;
using shelter;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repositories
{
    internal class AnimalStatusRepository : BaseRepository<AnimalStatus>
    {
        internal AnimalStatusRepository(DbContext dbContext) : base(dbContext)
        {
        }
    }
}
