using MSProjectBackend.Models.DomainModels;
using MSProjectBackend.Repositories.Interfaces;
using MSProjectBackend.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MSProjectBackend.Services.Classes
{
    public class CityService : ICityService
    {
        private readonly ICityRepository _cityRepository;

        public CityService(ICityRepository cityRepository)
        {
            _cityRepository = cityRepository;
        }

        public async Task<List<City>> GetAllCities()
        {
            return await _cityRepository.GetAllAsync();
        }

        public async Task<List<City>> GetCitiesByProvince(int provinceId)
        {
            return await _cityRepository.GetByProvince(provinceId);
        }

        public async Task<City> GetCityById(int id)
        {
            return await _cityRepository.GetByIdAsync(id);
        }

        public async Task<int> CreateCityAsync(City city)
        {
            return await _cityRepository.CreateAsync(city);
        }

        public async Task<int> UpdateCityAsync(City city)
        {
            return await _cityRepository.UpdateAsync(city);
        }

        public async Task<int> DeleteCityAsync(int id)
        {
            return await _cityRepository.DeleteAsync(id);
        }

    }
}
