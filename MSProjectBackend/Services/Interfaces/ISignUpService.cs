using MSProjectBackend.Models.AppModels;

namespace MSProjectBackend.Services.Interfaces
{
    public interface ISignUpService
    {
        Task<int> CreateVolunteerAsync(SignUpModel signUpModel);
    }
}
