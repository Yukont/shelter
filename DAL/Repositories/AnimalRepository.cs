using DAL.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repositories
{
    public class AnimalRepository : BaseRepository<Animal>
    {
        internal AnimalRepository(DbContext dbContext) : base(dbContext)
        {
        }
    }
}
