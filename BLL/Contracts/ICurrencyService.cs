using Dal.Models;
using DTO;
using Contracts;

namespace BLL.Contracts
{
    public interface ICurrencyService : ICrud<CriptoCoinValue, int, CriptoCoinDto>
    {
        public void GetFileInfo();
    }
}
