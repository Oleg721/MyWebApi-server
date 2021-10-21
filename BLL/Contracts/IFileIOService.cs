using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Contracts
{
    public interface IFileIOService<TOut, TDto>
    {
        public Task<TDto> SaveFileAsync(TOut uploadFile);
    }
}
