using MSProjectBackend.Models.AppModels;
using MSProjectBackend.Models.DomainModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MSProjectBackend.Services.Interfaces
{
    public interface IVolunteerService
    {
        Task<List<VolunteerModel>> GetAllVolunteers();
        Task<VolunteerModel> GetVolunteerById(int id);
        Task<VolunteerModel> GetVolunteerByRegistrationId(string id);
        Task<int> CreateVolunteerAsync(VolunteerModel volunteerModel);
        Task<int> UpdateVolunteerAsync(VolunteerModel volunteerModel);
        Task<int> DeleteVolunteerAsync(int id);
    }
}
