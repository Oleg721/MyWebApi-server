using AutoMapper;
using Dal.Models;
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
            cfg.CreateMap<CurrencyVM, CurrencyDto>().ReverseMap();
            cfg.CreateMap<CurrencyHystoryVM, CurrencyHistoryDto>().ReverseMap();

        }
    }
}
