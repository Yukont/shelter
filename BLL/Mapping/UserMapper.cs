using BLL.DTO;
using DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Mapping
{
    public class UserMapper : BaseMapper<User, UserDTO>
    {
        public UserMapper()
        {
            CreateMap<User, UserDTO>()
                .ForMember(dest => dest.UserGenders, opt => opt.MapFrom(src => src.IdUserGenderNavigation.Name));
        }   
    }
}
