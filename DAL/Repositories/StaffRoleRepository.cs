using Microsoft.EntityFrameworkCore;
using shelter;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repositories
{
    public class StaffRoleRepository : BaseRepository<StaffRole>
    {
        internal StaffRoleRepository(DbContext dbContext) : base(dbContext)
        {
        }
    }
}
