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
    public class CriptoController : ControllerBase
    {
        ICurrencyService currencyService;
        IMapper mapper;
        public CriptoController(ICurrencyService currencyService,IMapper mapper) 
        {
            this.currencyService = currencyService;
            this.mapper = mapper;
        }
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            List<CriptoCoinDto> data = await currencyService.GetAsync();
            List<CriptoCoinVM> result = mapper.Map<List<CriptoCoinVM>>(data);
            return Ok(result);
        }

         [HttpGet]
        [Route("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            CriptoCoinDto data = await currencyService.GetAsync(id);
            CriptoCoinVM result = mapper.Map<CriptoCoinVM>(data);
            return Ok(result);
        }


        [HttpPost]
        public async Task<IActionResult> Post(CriptoCoinVM criptoCoinValues)
        {
            CriptoCoinDto criptoCoinDto = mapper.Map<CriptoCoinDto>(criptoCoinValues);
            int resalt = await currencyService.CreateAsync(criptoCoinDto);
            return Ok(resalt);
        }

        [HttpDelete]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await currencyService.DeleteAsync(id);
              return Ok(result);
        }

        [HttpPut]
        public async Task<IActionResult> Put(CriptoCoinVM criptoCoinValues)
        {
            CriptoCoinDto criptoCoinDto = mapper.Map<CriptoCoinDto>(criptoCoinValues);
            var resalt = await currencyService.UpdateAsync(criptoCoinDto);
            return Ok(resalt);
        }

    }

}

