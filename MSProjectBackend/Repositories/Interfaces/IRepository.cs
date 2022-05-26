using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MSProjectBackend.Models.DomainModels;

namespace MSProjectBackend.Repositories.Interfaces
{
    public interface IRepository<T> where T : BaseEntity
    {
        Task<List<T>> GetAllAsync();
        Task<T> GetByIdAsync(int id);
        Task<int> CreateAsync(T entity);
        Task<int> UpdateAsync(T entity);
        Task<int> DeleteAsync(dynamic id);
    }
}