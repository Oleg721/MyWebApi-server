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
    public class CurrencyController : ControllerBase
    {
        ICurrencyHistoryService currencyHistoryService;
        ICurrencyService currencyService;
        IMapper mapper;
        public CurrencyController(ICurrencyHistoryService currencyHistoryService, ICurrencyService currencyService, IMapper mapper) 
        {
            this.currencyHistoryService = currencyHistoryService;
            this.currencyService = currencyService;
            this.mapper = mapper;
        }
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            Console.WriteLine(await currencyService.GetAsync());
            List<CurrencyDto> data = await currencyService.GetAsync();
            List<CurrencyVM> result = mapper.Map<List<CurrencyVM>>(data);
            return Ok(result);
        }

         [HttpGet]
        [Route("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            CurrencyDto data = await currencyService.GetAsync(id);
            CurrencyVM result = mapper.Map<CurrencyVM>(data);
            return Ok(result);
        }


        [HttpPost]
        public async Task<IActionResult> Post(CurrencyVM currencyValues)
        {
            CurrencyDto currencyDto = mapper.Map<CurrencyDto>(currencyValues);
            int resalt = await currencyService.CreateAsync(currencyDto);
            return Ok(resalt);
        }

        [HttpDelete]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await currencyService.DeleteAsync(id);
              return Ok(result);
        }

        [HttpPut]
        public async Task<IActionResult> Put(CurrencyVM currencyValues)
        {
            CurrencyDto currencyDto = mapper.Map<CurrencyDto>(currencyValues);
            var resalt = await currencyService.UpdateAsync(currencyDto);
            return Ok(resalt);
        }
    }

}

