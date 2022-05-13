using MSProjectBackend.Repositories.Interfaces;
using MSProjectBackend.Models.AppModels;
using MSProjectBackend.Services.Interfaces;
using MSProjectBackend.Models.DomainModels;

namespace MSProjectBackend.Services.Classes
{
    public class SignUpService : ISignUpService
    {
        private readonly IVolunteerRepository _volunteerRepository;

        public SignUpService(IVolunteerRepository volunteerRepository)
        {
            _volunteerRepository = volunteerRepository;
        }

        public async Task<int> CreateVolunteerAsync(SignUpModel signupModel)
        {
            Volunteer volunteer = VolunteerModelToEntity(signupModel);
            return await _volunteerRepository.SignUpAsync(volunteer);
        }

        private Volunteer VolunteerModelToEntity(SignUpModel signupModel)
        {
            Volunteer volunteer = new Volunteer();

            volunteer.Name = signupModel.Name;
            volunteer.Email = signupModel.Email;
            volunteer.Password = signupModel.Password;
            
            return volunteer;
        }

    }
}
