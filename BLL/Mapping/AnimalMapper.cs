using BLL.DTO;
using DAL.Entities;

namespace BLL.Mapping
{
    public class AnimalMapper : BaseMapper<Animal, AnimalDTO>
    {
        public AnimalMapper()
        {
            CreateMap<Animal, AnimalDTO>()
                .ForMember(dest => dest.SpeciesName, opt => opt.MapFrom(src => src.IdSpeciesNavigation.Name))
                .ForMember(dest => dest.GenderName, opt => opt.MapFrom(src => src.IdSpeciesNavigation.Name))
                .ForMember(dest => dest.AnimalStatusName, opt => opt.MapFrom(src => src.IdAnimalStatusNavigation.Name))
                .ForMember(dest => dest.StatusOfHealthName, opt => opt.MapFrom(src => src.IdStatusOfHealthNavigation.Name));
            CreateMap<AnimalDTO, Animal>()
                .ForMember(dest => dest.IdSpeciesNavigation, opt => opt.Ignore())
                .ForMember(dest => dest.IdSpeciesNavigation, opt => opt.Ignore())
                .ForMember(dest => dest.IdAnimalStatusNavigation, opt => opt.Ignore())
                .ForMember(dest => dest.IdStatusOfHealthNavigation, opt => opt.Ignore());
        }
    }
}
