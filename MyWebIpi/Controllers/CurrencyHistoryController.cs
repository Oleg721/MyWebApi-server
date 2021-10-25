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
    public class CurrencyHistoryController : ControllerBase
    {
        ICurrencyHistoryService currencyHistoryService;
        ICurrencyService currencyService;
        IMapper mapper;
        public CurrencyHistoryController(ICurrencyHistoryService currencyHistoryService, ICurrencyService currencyService, IMapper mapper) 
        {
            this.currencyHistoryService = currencyHistoryService;
            this.currencyService = currencyService;
            this.mapper = mapper;
        }
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            List<CurrencyHistoryDto> data = await currencyHistoryService.GetAsync();
            List<CurrencyHystoryVM> result = mapper.Map<List<CurrencyHystoryVM>>(data);
            return Ok(result);
        }

         [HttpGet]
        [Route("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            CurrencyHistoryDto data = await currencyHistoryService.GetAsync(id);
            CurrencyHystoryVM result = mapper.Map<CurrencyHystoryVM>(data);
            return Ok(result);
        }


        [HttpPost]
        public async Task<IActionResult> Post(CurrencyHystoryVM criptoCoinValues)
        {
            CurrencyHistoryDto criptoCoinDto = mapper.Map<CurrencyHistoryDto>(criptoCoinValues);

            int resalt = await currencyHistoryService.CreateAsync(criptoCoinDto);
            return Ok(resalt);
        }

        [HttpDelete]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await currencyHistoryService.DeleteAsync(id);
              return Ok(result);
        }

        [HttpPut]
        public async Task<IActionResult> Put(CurrencyHystoryVM criptoCoinValues)
        {
            CurrencyHistoryDto criptoCoinDto = mapper.Map<CurrencyHistoryDto>(criptoCoinValues);
            var resalt = await currencyHistoryService.UpdateAsync(criptoCoinDto);
            return Ok(resalt);
        }
    }

}

