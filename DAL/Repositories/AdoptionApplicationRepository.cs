using DAL.Entities;
using DAL.Interfaces;
using Microsoft.EntityFrameworkCore;

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

        public async Task UpdateStatusAsync(AdoptionApplication adoptionApplication)
        {
            var entity = await _dbContext.Set<AdoptionApplication>().FindAsync(adoptionApplication.Id);

            if (entity != null)
            {
                entity.IdStatus = adoptionApplication.IdStatus;
                await _dbContext.SaveChangesAsync();
            }

        }
        public async Task<IEnumerable<AdoptionApplication>> GetAllByAnimalIdAsync(int id)
        {
            return await _dbContext.Set<AdoptionApplication>()
                .Include(a => a.IdAnimalNavigation)
                .Include(a => a.IdUserNavigation)
                .Include(a => a.IdStatusNavigation)
                .Where(a => a.IdAnimal == id)
                .ToListAsync();
        }
    }
}
