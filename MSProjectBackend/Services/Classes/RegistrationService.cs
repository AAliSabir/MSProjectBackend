using MSProjectBackend.Repositories.Interfaces;
using MSProjectBackend.Models.AppModels;
using MSProjectBackend.Services.Interfaces;
using MSProjectBackend.Models.DomainModels;

namespace MSProjectBackend.Services.Classes
{
    public class RegistrationService : IRegistrationService
    {
        private readonly IRegistrationRepository _registrationRepository;

        public RegistrationService(IRegistrationRepository registrationRepository)
        {
            _registrationRepository = registrationRepository;
        }

        public async Task<int> CreateAsync(SignUpModel signupModel)
        {
            Registration registration = ModelToEntity(signupModel);
            return await _registrationRepository.CreateAsync(registration);
        }

        public async Task<int> DeleteAsync(string id)
        {
            return await _registrationRepository.DeleteAsync(id);
        }

        private Registration ModelToEntity(SignUpModel signupModel)
        {
            Registration registration = new Registration();

            registration.Id = signupModel.RegistrationId;
            registration.Password = BCrypt.Net.BCrypt.HashPassword(signupModel.Password);
            registration.RegistrationType = signupModel.RegistrationType;

            return registration;
        }

    }
}
