using DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Interfaces
{
    internal interface IAdoptionApplicationRepository : IRepository<AdoptionApplication>
    {
        Task<IEnumerable<AdoptionApplication>> GetAllAsync();
        Task<AdoptionApplication> GetAsync(int id);
    }
}
