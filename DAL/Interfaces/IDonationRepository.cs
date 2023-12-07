using DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Interfaces
{
    internal interface IDonationRepository : IRepository<Donation>
    {
        Task<IEnumerable<Donation>> GetAllAsync(params Expression<Func<Donation, object>>[] includes);
    }
}
