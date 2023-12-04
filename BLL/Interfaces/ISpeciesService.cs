using BLL.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Interfaces
{
    public interface ISpeciesService : IDisposable
    {
        Task AddSpecies(SpeciesDTO speciesDTO);
        Task UpdateSpecies(SpeciesDTO speciesDTO);
        Task RemoveSpecies(int speciesId);
        Task<SpeciesDTO> GetSpeciesId(int speciesId);
        Task<IEnumerable<SpeciesDTO>> GetAllSpeciess();
    }
}
