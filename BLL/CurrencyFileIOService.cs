using BLL.Contracts;
using DTO;
using System;
using System.IO;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Hosting;
using System.Collections.Generic;
using Contracts;
using DAL.Contracts;

namespace BLL
{
    public class CurrencyFileIOService : ICurrentFileIOService
    {
        IWebHostEnvironment _hostEnvironment;
        IHttpContextAccessor _httpContextAccessor;
        ICurrencyHistoryRepository _currencyRepository;
        String _filePath;
        public CurrencyFileIOService(IHttpContextAccessor httpContextAccessor, IWebHostEnvironment environment, ICurrencyHistoryRepository currencyRepository)
        {
            this._httpContextAccessor = httpContextAccessor;
            this._hostEnvironment = environment;
            this._currencyRepository = currencyRepository;
            this._filePath = this._hostEnvironment.ContentRootPath + "/Files/";
        }

        public async Task<bool> CreateAsync(IFormFile uploadedFile)
        {
            if (uploadedFile != null)
            {
                string path = Path.Combine(this._filePath, DateTime.Now.ToString("ddMMyyyy_hhmmss") + "_" + uploadedFile.FileName);
                using (var fileStream = new FileStream(path, FileMode.Create))
                {
                    await uploadedFile.CopyToAsync(fileStream);
                }
                return true;
            }
            return false;///TMP return
        }

        public Task<bool> DeleteAsync(int id)
        {
            throw new NotImplementedException();
        }

        public List<FileDto> Get()
        {
            Console.WriteLine(this._hostEnvironment);
            Console.WriteLine(this._filePath);
            string[] files = Directory.GetFiles(_filePath);
            List<FileDto> resultList = new List<FileDto> {};
            foreach(String file in files)
            {
                FileInfo fileInf = new FileInfo(file);
                FileDto fileDto = new FileDto{};
                fileDto.Id = 0;
                fileDto.Name = fileInf.Name;
                fileDto.size = fileInf.Length;
                fileDto.Path = file;
                resultList.Add(fileDto);
            }

            return resultList;
            //throw new NotImplementedException();
        }

        public FileDto Get(int id)
        {
            throw new NotImplementedException();
        }

        public Task<bool> ConvertFilesToDBAsinc()//////////
        {

            throw new NotImplementedException();
        }

        public Task<bool> UpdateAsync(FileDto item)
        {
            throw new NotImplementedException();
        }

    }
}

