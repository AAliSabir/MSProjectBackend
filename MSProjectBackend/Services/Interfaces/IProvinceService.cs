using MSProjectBackend.Models.DomainModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MSProjectBackend.Services.Interfaces
{
    public interface IProvinceService
    {
        Task<List<Province>> GetAllProvinces();
        Task<Province> GetProvinceById(int id);
        Task<int> CreateProvinceAsync(Province province);
        Task<int> UpdateProvinceAsync(Province province);
        Task<int> DeleteProvinceAsync(int id);
    }
}
