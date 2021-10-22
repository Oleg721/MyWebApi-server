using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using BLL.Contracts;
using DTO;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MyWebApi.Models;


namespace MyWebIpi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class FileController : ControllerBase
    {
        IHttpContextAccessor _httpContextAccessor;
        IFileIOService<IFormFile, FileDto> _fileIOService;
        public FileController(IHttpContextAccessor httpContextAccessor,IFileIOService<IFormFile, FileDto> fileIOService,IMapper mapper) 
        {
            this._httpContextAccessor = httpContextAccessor;
            this._fileIOService = fileIOService;
        }

        [HttpPost]
        //  [RequestSizeLimit(5_000_000)]
        public async Task<IActionResult> AddFile(IFormFile uploadedFile)
        {
            await _fileIOService.SaveFileAsync(uploadedFile);
            return Ok("Index");
        }

    }

}

