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
        public FileIOService(IWebHostEnvironment environment)
        {
            this._hostEnvironment = environment;
        }

        public async Task<FileDto> SaveFileAsync(IFormFile uploadedFile)
        {

            // путь к папке Files
            string path = "/Files/" + uploadedFile.FileName; /*+ "_" +  DateTime.Now.ToString("ddMMyyyy_hhmmss");*/
            // сохраняем файл в папку Files в каталоге wwwroot
            using (var fileStream = new FileStream(_hostEnvironment.WebRootPath + path, FileMode.Create))
            {
                await uploadedFile.CopyToAsync(fileStream);
            }
            return null;
        }
    }
}

