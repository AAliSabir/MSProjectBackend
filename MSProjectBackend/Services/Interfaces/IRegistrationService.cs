using MSProjectBackend.Models.AppModels;

namespace MSProjectBackend.Services.Interfaces
{
    public interface IRegistrationService
    {
        Task<int> CreateAsync(SignUpModel signUpModel);
        Task<int> DeleteAsync(string id);
    }
}
