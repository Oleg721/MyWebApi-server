using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Contracts;
using DAL.Contracts;


namespace BLL
{
    public class BaseService<T, TId, TDto>: ICrud<T, TId, TDto>
    {
        private ICrud<T, TId, TDto> _repository;
        public BaseService(ICrud<T, TId, TDto> baseRepository)
        {
            this._repository = baseRepository;
        }

        public async Task<List<TDto>> GetAsync()
        {
            var result = await _repository.GetAsync();
            return result;
        }

        public async Task<TDto> GetAsync(TId id)
        {
            var result = await _repository.GetAsync(id);
            return result;
        }

        public async Task<TId> CreateAsync(TDto item)
        {
            var result = await _repository.CreateAsync(item);
            return result;
        }

        public Task<bool> DeleteAsync(TId id)
        {
            throw new NotImplementedException();
        }

        public Task<bool> UpdateAsync(TDto item)
        {
            throw new NotImplementedException();
        }
    }
}
