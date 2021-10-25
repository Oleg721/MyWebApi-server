using BLL.Contracts;
using DAL.Contracts;
using DTO;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;




namespace BLL
{
    public class CurrencyHistoryService : ICurrencyHistoryService
    {
        ICurrencyHistoryRepository _currencyHistoryRepository;
        ICurrencyService _currencyService;

        public CurrencyHistoryService(ICurrencyHistoryRepository currencyHistoryRepository, ICurrencyService currencyService)
        {
            this._currencyHistoryRepository = currencyHistoryRepository;
            this._currencyService = currencyService;
        }

        public async Task<List<CurrencyHistoryDto>> GetAsync()
        {
            var result = await _currencyHistoryRepository.GetAsync();
            return result;
        }

        public async Task<CurrencyHistoryDto> GetAsync(int id)
        {
            var result = await _currencyHistoryRepository.GetAsync(id);
            return result;
        }

        public async Task<int> CreateAsync(CurrencyHistoryDto item)
        {
            var result = await _currencyHistoryRepository.CreateAsync(item);
            return result;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var result = await _currencyHistoryRepository.DeleteAsync(id);
            return result;
        }

        public async Task<bool> UpdateAsync(CurrencyHistoryDto item)
        {
            var result = await _currencyHistoryRepository.UpdateAsync(item);
            return result;
        }

        public Task<bool> UploadFileAsync()
        {

          
            throw new NotImplementedException();
        }
    }
}

