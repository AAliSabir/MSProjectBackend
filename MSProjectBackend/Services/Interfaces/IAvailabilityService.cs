using MSProjectBackend.Models.DomainModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MSProjectBackend.Services.Interfaces
{
    public interface IAvailabilityService
    {
        Task<List<Availability>> GetAllAvailabilities();
        Task<Availability> GetAvailabilityById(int id);
        Task<int> CreateAvailabilityAsync(Availability availability);
        Task<int> UpdateAvailabilityAsync(Availability availability);
        Task<int> DeleteAvailabilityAsync(int id);
    }
}
