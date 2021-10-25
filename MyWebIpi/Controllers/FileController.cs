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
        ICurrentFileIOService _fileIOService;
        public FileController(IHttpContextAccessor httpContextAccessor, ICurrentFileIOService fileIOService, IMapper mapper)
        {
            this._httpContextAccessor = httpContextAccessor;
            this._fileIOService = fileIOService;
        }

        [HttpGet]
        public IActionResult Get()
        {
            List<FileDto> result = _fileIOService.Get();
            return Ok(result);
        }

        [HttpGet]
        [Route("convert")]
        public IActionResult convertFile()
        {
            List<FileDto> result = _fileIOService.Get();
            return Ok(result);
        }

        [HttpPost]
    //    [RequestSizeLimit(80_000_000)]
     //    [RequestFormLimits(ValueLengthLimit = 80_000_000, MultipartBodyLengthLimit = 80_000_000)]
        public async Task<IActionResult> AddFile(IFormFile uploadedFile)
        {
            await _fileIOService.CreateAsync(uploadedFile);
     
            return Ok("Index");
        }

    }

}

