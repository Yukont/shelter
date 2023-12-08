using DAL.Entities;
using DAL.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repositories
{
    public class UserRepository : BaseRepository<User>, IUsersRepository
    {
        internal UserRepository(DbContext dbContext) : base(dbContext)
        {
        }

        public async Task<User> GetUserByIdAuth(int IdAuth)
        {
            var user = await FindAsync(c => c.IdAuth == IdAuth);
            return user.FirstOrDefault();
        }
        public async Task<User> GetAsync(int id)
        {
            return await _dbContext.Set<User>()
                .Include(a => a.IdUserGenderNavigation)
                .FirstOrDefaultAsync(a => a.Id == id);
        }
        public async Task<IEnumerable<User>> GetAllAsync()
        {
            return await _dbContext.Set<User>()
                .Include(a => a.IdUserGenderNavigation)
                .ToListAsync();
        }
    }
}
