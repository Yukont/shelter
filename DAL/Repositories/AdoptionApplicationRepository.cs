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
    public class AdoptionApplicationRepository : BaseRepository<AdoptionApplication>, IAdoptionApplicationRepository
    {
        internal AdoptionApplicationRepository(DbContext dbContext) : base(dbContext)
        {
        }

        public async Task<IEnumerable<AdoptionApplication>> GetAllAsync()
        {
            return await _dbContext.Set<AdoptionApplication>()
                .Include(a => a.IdAnimalNavigation)
                .Include(a => a.IdUserNavigation)
                .Include(a => a.IdStatusNavigation)
                .ToListAsync();
        }

        public async Task<AdoptionApplication> GetAsync(int id)
        {
            return await _dbContext.Set<AdoptionApplication>()
                .Include(a => a.IdAnimalNavigation)
                .Include(a => a.IdUserNavigation)
                .Include(a => a.IdStatusNavigation)
                .FirstOrDefaultAsync(a => a.Id == id);
        }
    }
}
