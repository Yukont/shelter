using Microsoft.EntityFrameworkCore;
using shelter;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repositories
{
    internal class UserRepository : BaseRepository<User>
    {
        protected UserRepository(DbContext dbContext) : base(dbContext)
        {
        }
    }
}
