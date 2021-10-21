using Dal.Models;
using DTO;
using Contracts;

namespace DAL.Contracts
{
    public interface ICurrencyRepository : ICrud<CriptoCoinValue, int, CriptoCoinDto>
    {
    }
}
