using System.Threading.Tasks;
using AutoMapper;
using Dal.Models;
using DAL.Contracts;
using DTO;
using MyWebIpi.Contexts;

namespace DAL.Repo
{
    public class CurrencyHistoryRepository : BaseRepository<CurrencyHistoryValue, int, CurrencyHistoryDto>, ICurrencyHistoryRepository
    {
        ICurrencyRepository _currencyRepository;
        public CurrencyHistoryRepository(CurrencyContext context, ICurrencyRepository currencyRepository, IMapper mapper) : base(context, mapper)
        {
            this._currencyRepository = currencyRepository;
        }
        public override async Task<int> CreateAsync(CurrencyHistoryDto item)
        {
            int currencyId = item.CurrencyID;
            CurrencyDto currencyDto = await _currencyRepository.GetAsync(currencyId);
            if (currencyDto != null)
            {
                CurrencyHistoryValue newDbItem = _mapper.Map<CurrencyHistoryValue>(item);
                CurrencyValue currencyValue = _mapper.Map<CurrencyValue>(currencyDto);
                newDbItem.Currency = currencyValue;
                _context.Set<CurrencyHistoryValue>().Add(newDbItem);
                await this._context.SaveChangesAsync();
                return newDbItem.ID;
            }
            return -1;
        }
    }
    
}
