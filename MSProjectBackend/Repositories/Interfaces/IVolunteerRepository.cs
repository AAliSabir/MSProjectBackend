using MSProjectBackend.Models.DomainModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MSProjectBackend.Repositories.Interfaces
{
    public interface IVolunteerRepository : IRepository<Volunteer>
    {
        public Task<Volunteer> GetByRegistrationIdAsync(string id);

    }
}
