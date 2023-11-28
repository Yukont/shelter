using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace shelter.Mapping
{
    internal class BaseMapper<TSource, TDestination> : Profile
    {
        public BaseMapper()
        {
            CreateMap<TSource, TDestination>();
            CreateMap<TDestination, TSource>();
        }
    }
}
