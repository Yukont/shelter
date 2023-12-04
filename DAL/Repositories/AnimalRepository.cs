using DAL.Entities;
using Microsoft.EntityFrameworkCore;

namespace DAL.Repositories
{
    public class AnimalRepository : BaseRepository<Animal>
    {
        internal AnimalRepository(DbContext dbContext) : base(dbContext)
        {
        }
    }
}
