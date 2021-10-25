using Dal.Models;
using DTO;
using Contracts;

namespace DAL.Contracts
{
    public interface ICurrencyHistoryRepository : ICrud<CurrencyHistoryValue, int, CurrencyHistoryDto>
    {
    }
}
