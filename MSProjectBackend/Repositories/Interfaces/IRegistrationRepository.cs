using MSProjectBackend.Models.DomainModels;

namespace MSProjectBackend.Repositories.Interfaces
{
    public interface IRegistrationRepository : IRepository<Registration>
    {
        public Task<Registration> SignIn(string id);
    }
}
