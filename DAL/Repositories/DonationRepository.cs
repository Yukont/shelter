using Microsoft.EntityFrameworkCore;
using shelter;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repositories
{
    public class DonationRepository : BaseRepository<Donation>
    {
        internal DonationRepository(DbContext dbContext) : base(dbContext)
        {
        }
    }
}
