using Microsoft.EntityFrameworkCore;
using shelter;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repositories
{
    public class AdoptionStatusRepository : BaseRepository<AdoptionStatus>
    {
        internal AdoptionStatusRepository(DbContext dbContext) : base(dbContext)
        {
        }
    }
}
