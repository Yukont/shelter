using BLL.DTO;
using DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Mapping
{
    public class DonationMapper : BaseMapper<Donation, DonationDTO>
    {
        public DonationMapper()
        {
            CreateMap<Donation, DonationDTO>()
                .ForMember(dest => dest.UserName, opt => opt.MapFrom(src => src.IdUserNavigation.Name));
            CreateMap<DonationDTO, Donation>()
                .ForMember(dest => dest.IdUserNavigation, opt => opt.Ignore());
        }
    }
}
