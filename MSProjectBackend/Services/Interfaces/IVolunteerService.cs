using Backend.Models.AppModels;
using Backend.Models.DomainModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Backend.Services.Interfaces
{
    public interface IVolunteerService
    {
        Task<List<VolunteerModel>> GetAllVolunteers();
        Task<VolunteerModel> GetVolunteerById(int id);
        Task<int> CreateVolunteerAsync(VolunteerModel volunteerModel);
        Task<int> UpdateVolunteerAsync(int id, VolunteerModel volunteerModel);
        Task<int> DeleteVolunteerAsync(int id);
    }
}
