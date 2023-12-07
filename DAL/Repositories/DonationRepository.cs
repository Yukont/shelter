using DAL.Entities;
using DAL.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repositories
{
    public class DonationRepository : BaseRepository<Donation>, IDonationRepository
    {
        internal DonationRepository(DbContext dbContext) : base(dbContext)
        {
        }

        public async Task<IEnumerable<Donation>> GetAllAsync(params Expression<Func<Donation, object>>[] includes)
        {
            return await _dbContext.Set<Donation>()
                .Include(a => a.IdUserNavigation)
                .ToListAsync();
        }
    }
}
