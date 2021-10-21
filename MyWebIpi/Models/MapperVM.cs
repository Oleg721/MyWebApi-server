using AutoMapper;
using DTO;
using MyWebApi.Models;

namespace DAL
{
    class MapperVM: Profile
    {
        public MapperVM()
        {
            MapConfig(this);
        }

        private static void MapConfig(IProfileExpression cfg)
        {
            cfg.CreateMap<CriptoCoinVM, CriptoCoinDto>().ReverseMap();
        }
    }
}
