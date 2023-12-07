using BLL.DTO;
using DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Mapping
{
    public class AdoptionApplicationMapper : BaseMapper<AdoptionApplication, AdoptionApplicationDTO>
    {
        public AdoptionApplicationMapper()
        {
            CreateMap<AdoptionApplication, AdoptionApplicationDTO>()
                .ForMember(dest => dest.AnimalName, opt => opt.MapFrom(src => src.IdAnimalNavigation.Name))
                .ForMember(dest => dest.UserName, opt => opt.MapFrom(src => src.IdUserNavigation.Name))
                .ForMember(dest => dest.StatusName, opt => opt.MapFrom(src => src.IdStatusNavigation.Name));
            CreateMap<AdoptionApplicationDTO, AdoptionApplication>()
                .ForMember(dest => dest.IdAnimalNavigation, opt => opt.Ignore())
                .ForMember(dest => dest.IdUserNavigation, opt => opt.Ignore())
                .ForMember(dest => dest.IdStatusNavigation, opt => opt.Ignore());
        }
    }
}
