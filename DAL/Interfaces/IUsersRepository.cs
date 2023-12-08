using DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Interfaces
{
    internal interface IUsersRepository : IRepository<User>
    {
        public Task<User> GetUserByIdAuth(int IdAuth);
        Task<User> GetAsync(int id);
        Task<IEnumerable<User>> GetAllAsync();
    }
}
