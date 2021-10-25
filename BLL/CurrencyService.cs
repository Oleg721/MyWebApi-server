using BLL.Contracts;
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

        public async Task<List<CurrencyDto>> GetAsync()
        {
            var result = await _currencyRepository.GetAsync();
            return result;
        }

        public async Task<CurrencyDto> GetAsync(int id)
        {
            var result = await _currencyRepository.GetAsync(id);
            return result;
        }

        public async Task<int> CreateAsync(CurrencyDto item)
        {
            var result = await _currencyRepository.CreateAsync(item);
            return result;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var result = await _currencyRepository.DeleteAsync(id);
            return result;
        }

        public async Task<bool> UpdateAsync(CurrencyDto item)
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

