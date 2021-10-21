using AutoMapper;
using Dal.Models;
using DAL.Contracts;
using DTO;
using MyWebIpi.Contexts;

namespace DAL.Repo
{
    public class CurrencyRepository : BaseRepository<CriptoCoinValue, int, CriptoCoinDto>, ICurrencyRepository
    {
        public CurrencyRepository(CriptoCoinValueContext context, IMapper mapper) : base(context, mapper)
        {
        }
    }
}
