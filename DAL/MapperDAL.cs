using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Dal.Models;
using DTO;

namespace DAL
{
    public class MapperDAL : Profile
    {
        public MapperDAL()
        {
            MapConfig(this);
        }

        private static void MapConfig(IProfileExpression cfg)
        {
            cfg.CreateMap<CriptoCoinValue, CriptoCoinDto>().ReverseMap();
        }
    }
}
