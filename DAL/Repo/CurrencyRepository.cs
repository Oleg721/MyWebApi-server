using AutoMapper;
using Dal.Models;
using DAL.Contracts;
using DTO;
using MyWebIpi.Contexts;

namespace DAL.Repo
{
    public class CurrencyRepository : BaseRepository<CurrencyValue, int, CurrencyDto>, ICurrencyRepository
    {
        public CurrencyRepository(CurrencyContext context, IMapper mapper) : base(context, mapper)
        {
        }
    }
}
