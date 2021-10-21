using BLL.Contracts;
using Contracts;
using Dal.Models;
using DAL.Contracts;
using DTO;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;




namespace BLL
{
    public class CurrencyService : ICurrencyService
    {
        ICurrencyRepository _currencyRepository;

        public CurrencyService(ICurrencyRepository currencyRepository)
        {
            this._currencyRepository = currencyRepository;
        }

        public async Task<List<CriptoCoinDto>> GetAsync()
        {
            var result = await _currencyRepository.GetAsync();
            return result;
        }

        public async Task<CriptoCoinDto> GetAsync(int id)
        {
            var result = await _currencyRepository.GetAsync(id);
            return result;
        }

        public async Task<int> CreateAsync(CriptoCoinDto item)
        {
            var result = await _currencyRepository.CreateAsync(item);
            return result;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var result = await _currencyRepository.DeleteAsync(id);
            return result;
        }

        public async Task<bool> UpdateAsync(CriptoCoinDto item)
        {
            var result = await _currencyRepository.UpdateAsync(item);
            return result;
        }

        public Task<bool> UploadFileAsync()
        {

          
            throw new NotImplementedException();
        }
    }
}

