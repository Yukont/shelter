using Microsoft.EntityFrameworkCore;
using shelter;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repositories
{
    public class VeterinarianRepository : BaseRepository<Veterinarian>
    {
        internal VeterinarianRepository(DbContext dbContext) : base(dbContext)
        {
        }
    }
}
