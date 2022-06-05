using MSProjectBackend.Models.DomainModels;

namespace MSProjectBackend.Repositories.Interfaces
{
    public interface INGORepository : IRepository<NGO>
    {
        public Task<NGO> GetByRegistrationIdAsync(string id);
    }
}
