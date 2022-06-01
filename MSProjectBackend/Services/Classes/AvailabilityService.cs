using MSProjectBackend.Models.DomainModels;
using MSProjectBackend.Repositories.Interfaces;
using MSProjectBackend.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MSProjectBackend.Services.Classes
{
    public class AvailabilityService : IAvailabilityService
    {
        private readonly IAvailabilityRepository _availabilityRepository;

        public AvailabilityService(IAvailabilityRepository availabilityRepository)
        {
            _availabilityRepository = availabilityRepository;
        }

        public async Task<List<Availability>> GetAllAvailabilities()
        {
            return await _availabilityRepository.GetAllAsync();
        }

        public async Task<Availability> GetAvailabilityById(int id)
        {
            return await _availabilityRepository.GetByIdAsync(id);
        }

        public async Task<int> CreateAvailabilityAsync(Availability availability)
        {
            return await _availabilityRepository.CreateAsync(availability);
        }

        public async Task<int> UpdateAvailabilityAsync(Availability availability)
        {
            return await _availabilityRepository.UpdateAsync(availability);
        }

        public async Task<int> DeleteAvailabilityAsync(int id)
        {
            return await _availabilityRepository.DeleteAsync(id);
        }
    }
}
