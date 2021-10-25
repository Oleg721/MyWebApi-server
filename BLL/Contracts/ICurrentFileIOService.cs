using System.Threading.Tasks;
using Contracts;
using DTO;
using Microsoft.AspNetCore.Http;

namespace BLL.Contracts
{
    public interface ICurrentFileIOService: IFileIO<IFormFile, int, FileDto>
    {
        Task<bool> ConvertFilesToDBAsinc();
    }
}
