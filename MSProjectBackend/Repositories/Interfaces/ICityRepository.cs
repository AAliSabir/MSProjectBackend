using MSProjectBackend.Models.DomainModels;

namespace MSProjectBackend.Repositories.Interfaces
{
    public interface ICityRepository : IRepository<City>
    {
        public Task<List<City>> GetByProvince(int provinceId);

    }
}
