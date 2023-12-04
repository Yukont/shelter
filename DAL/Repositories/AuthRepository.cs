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
    public class AuthRepository : BaseRepository<Auth>, IAuthRepository
    {
        internal AuthRepository(DbContext dbContext) : base(dbContext)
        {
        }
        public async Task<Auth> GetLastAsync()
        {
            var entity = await _dbContext.Set<Auth>().OrderByDescending(x => x.Id).FirstOrDefaultAsync();
            return entity;
        }
        public async Task<Auth> GetByLoginAsync(string login)
        {
            var customers = await FindAsync(c => c.Login == login);
            return customers.FirstOrDefault();
        }
    }
}
