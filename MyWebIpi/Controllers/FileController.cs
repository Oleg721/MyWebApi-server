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
        IFileIOService<IFormFile, FileDto> _fileIOService;
        public FileController(IFileIOService<IFormFile, FileDto> fileIOService,IMapper mapper) 
        {
            this._fileIOService = fileIOService;
        }


        [HttpPost]
        public async Task<IActionResult> UploadFile(IFormFile uploadedFile)
        {
            Console.WriteLine("UPLOAD_FILE");
            if (uploadedFile != null)
            {
                String i = uploadedFile.FileName;
            }
            //   var resalt = await _fileIOService.SaveFileAsync(uploadedFile);
            return Ok(null);
        }


    }

}

