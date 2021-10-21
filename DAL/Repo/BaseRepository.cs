using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Dal.Models;
using Contracts;
using DTO;
using Microsoft.EntityFrameworkCore;
using MyWebIpi.Contexts;

namespace DAL.Repo
{
    public class BaseRepository<T, TId, TDto> : ICrud<T, TId, TDto>
        where T : BaseEntity<TId>
    {
        protected CriptoCoinValueContext _context;
        protected IMapper _mapper;
        public BaseRepository(CriptoCoinValueContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
            //Create DB
            context.Database.EnsureCreated();
        }
        public async Task<List<TDto>> GetAsync()
        {
            var dbResult = await _context.Set<T>().ToListAsync();
            List<TDto> result = _mapper.Map<List<TDto>>(dbResult);
            return result;
        }

        public async Task<TDto> GetAsync(TId id)
        {
            var dbResult = await _context.Set<T>().FindAsync(id);
            TDto result = _mapper.Map<TDto>(dbResult);
            return result;
        }
        public async Task<TId> CreateAsync(TDto item)
        {
            T newDbItem = _mapper.Map<T>(item);
            _context.Set<T>().Add(newDbItem);
            await this._context.SaveChangesAsync();

            return newDbItem.ID;
        }

        public async Task<bool> DeleteAsync(TId id)
        {
            var deletedEntity = await _context.Set<T>().FindAsync(id);
            if (deletedEntity == null) {
                return false;
            };
            _context.Remove(deletedEntity);
            var result = await _context.SaveChangesAsync();
            return result == 1 ? true : false;
        }

        public async Task<bool> UpdateAsync(TDto item)
        {
            T updatedDbItem = _mapper.Map<T>(item);
            var dbResult = await _context.Set<T>().FindAsync(updatedDbItem.ID);
            if(dbResult != null)
            {
               _mapper.Map<TDto, T>(item, dbResult);
               _context.Update(dbResult);
                var result = await _context.SaveChangesAsync();
                if (result == 1) {
                    return true;
                }
            }
            return false;
        }
    }
}
