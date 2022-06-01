using MSProjectBackend.Models.DomainModels;
using MSProjectBackend.Repositories.Interfaces;
using MSProjectBackend.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MSProjectBackend.Services.Classes
{
    public class ProvinceService : IProvinceService
    {
        private readonly IProvinceRepository _provinceRepository;

        public ProvinceService(IProvinceRepository provinceRepository)
        {
            _provinceRepository = provinceRepository;
        }

        public async Task<List<Province>> GetAllProvinces()
        {
            return await _provinceRepository.GetAllAsync();
        }

        public async Task<Province> GetProvinceById(int id)
        {
            return await _provinceRepository.GetByIdAsync(id);
        }

        public async Task<int> CreateProvinceAsync(Province province)
        {
            return await _provinceRepository.CreateAsync(province);
        }

        public async Task<int> UpdateProvinceAsync(Province province)
        {
            return await _provinceRepository.UpdateAsync(province);
        }

        public async Task<int> DeleteProvinceAsync(int id)
        {
            return await _provinceRepository.DeleteAsync(id);
        }

    }
}
