using DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Interfaces
{
    internal interface IAnimalRepository : IRepository<Animal>
    {
        Task<IEnumerable<Animal>> GetAllAsync(params Expression<Func<Animal, object>>[] includes);
        Task<Animal> GetAsync(int id, params Expression<Func<Animal, object>>[] includes);
    }
}
