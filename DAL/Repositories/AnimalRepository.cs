using DAL.Entities;
using DAL.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace DAL.Repositories
{
    public class AnimalRepository : BaseRepository<Animal>, IAnimalRepository
    {
        internal AnimalRepository(DbContext dbContext) : base(dbContext)
        {
        }

        public async Task<IEnumerable<Animal>> GetAllAsync(params Expression<Func<Animal, object>>[] includes)
        {
            IQueryable<Animal> query = _dbContext.Set<Animal>();

            foreach (var include in includes)
            {
                query = query.Include(include);
            }

            return await query.ToListAsync();
        }

        public async Task<Animal> GetAsync(int id)
        {
            return await _dbContext.Set<Animal>()
                .Include(a => a.IdAnimalStatusNavigation)
                .Include(a => a.IdGenderNavigation)
                .Include(a => a.IdSpeciesNavigation)
                .Include(a => a.IdStatusOfHealthNavigation)
                .Include(a => a.AdoptionApplications)
                .Include(a => a.Appointments)
                .FirstOrDefaultAsync(a => a.Id == id);
        }
    }
}
