using MSProjectBackend.Models.DomainModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MSProjectBackend.Services.Interfaces
{
    public interface ICityService
    {
        Task<List<City>> GetAllCities();
        Task<List<City>> GetCitiesByProvince(int provinceId);
        Task<City> GetCityById(int id);
        Task<int> CreateCityAsync(City city);
        Task<int> UpdateCityAsync(City city);
        Task<int> DeleteCityAsync(int id);
    }
}
