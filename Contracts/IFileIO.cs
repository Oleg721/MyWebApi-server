using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Contracts;

namespace Contracts
{
    public interface IFileIO<T, TId, TDto>
    {
        List<TDto> Get();
        TDto Get(TId id);
        Task<bool> DeleteAsync(TId id);
        Task<bool> UpdateAsync(TDto item);
        Task<bool> CreateAsync(T item);
    }
}
