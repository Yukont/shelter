using AutoMapper;
using BLL.DTO;
using BLL.Interfaces;
using DAL.Entities;
using DAL.Interfaces;

namespace BLL.Services
{
    public class SpeciesService : ISpeciesService
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly IMapper mapper;

        public SpeciesService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            this.unitOfWork = unitOfWork;
            this.mapper = mapper;
        }
        public async Task AddSpecies(SpeciesDTO speciesDTO)
        {
            Species species = mapper.Map<SpeciesDTO, Species>(speciesDTO);
            await unitOfWork.Species.CreateAsync(species);
            unitOfWork.Save();
        }

        public void Dispose()
        {
            unitOfWork.Dispose();
        }

        public async Task<IEnumerable<SpeciesDTO>> GetAllSpeciess()
        {
            IEnumerable<Species> species = await unitOfWork.Species.GetAllAsync();
            return mapper.Map<IEnumerable<Species>, IEnumerable<SpeciesDTO>>(species);
        }

        public async Task<SpeciesDTO> GetSpeciesId(int speciesId)
        {
            Species species = await unitOfWork.Species.GetAsync(speciesId);
            return mapper.Map<Species, SpeciesDTO>(species);
        }

        public async Task RemoveSpecies(int speciesId)
        {
            await unitOfWork.Species.DeleteAsync(speciesId);
            unitOfWork.Save();
        }

        public async Task UpdateSpecies(SpeciesDTO speciesDTO)
        {
            Species species = mapper.Map<SpeciesDTO, Species>(speciesDTO);
            await unitOfWork.Species.UpdateAsync(species);
            unitOfWork.Save();
        }
    }
}
