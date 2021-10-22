using BLL.Contracts;
using DTO;
using System;
using System.IO;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Hosting;

namespace BLL
{
    public class FileIOService : IFileIOService<IFormFile, FileDto>
    {
        IWebHostEnvironment _hostEnvironment;
        IHttpContextAccessor _httpContextAccessor;
        public FileIOService(IHttpContextAccessor httpContextAccessor, IWebHostEnvironment environment )
        {
            this._httpContextAccessor = httpContextAccessor;
            this._hostEnvironment = environment;
        }

        public async Task<FileDto> SaveFileAsync(IFormFile uploadedFile)
        {
            string path = Path.Combine("/Files/", DateTime.Now.ToString("ddMMyyyy_hhmmss") + "_" + uploadedFile.FileName);
            using (var fileStream = new FileStream(_hostEnvironment.ContentRootPath + path, FileMode.Create))
            {
                await uploadedFile.CopyToAsync(fileStream);
            }
            return null;
        }
    }
}

