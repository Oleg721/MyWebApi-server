using Dal.Models;
using DTO;
using Contracts;

namespace DAL.Contracts
{
    public interface ICurrencyRepository : ICrud<CurrencyValue, int, CurrencyDto>
    {
    }
}
