using DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Interfaces
{
    internal interface IAuthRepository : IRepository<Auth>
    {
        public Task<Auth> GetLastAsync();
        public Task<Auth> GetByLoginAsync(string login);
    }
}
