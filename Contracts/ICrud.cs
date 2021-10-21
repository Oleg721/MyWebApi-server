using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contracts
{
    public interface ICrud<T,TId,TDto>
    {
        Task<List<TDto>> GetAsync();
        Task<TDto> GetAsync(TId id);
        Task<bool> DeleteAsync(TId id);
        Task<bool> UpdateAsync(TDto item);
        Task<TId> CreateAsync(TDto item);
    }
}
