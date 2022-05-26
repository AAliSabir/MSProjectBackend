using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using MSProjectBackend.Models.AppModels;
using MSProjectBackend.Services.Interfaces;

namespace MSProjectBackend.Controllers
{
    [EnableCors("CorsPolicy"), Route("api/[controller]/[action]")]
    [ApiController]
    public class RegistrationController : ControllerBase
    {
        private readonly IRegistrationService _registrationService;
        private readonly IVolunteerService _volunteerService;

        public RegistrationController(IRegistrationService registrationService, IVolunteerService volunteerService)
        {
            _registrationService = registrationService;
            _volunteerService = volunteerService;
        }

        [HttpPost]
        public async Task<IActionResult> AddVolunteer([FromBody] SignUpModel signUpModel)
        {
            ResponseModel responseObject = new ResponseModel();

            try
            {
                int rowResults = await _registrationService.CreateAsync(signUpModel);

                if (rowResults > 0)
                {
                    VolunteerModel volunteerModel = new VolunteerModel();
                    volunteerModel.RegistrationId = signUpModel.RegistrationId;
                    volunteerModel.Name = signUpModel.Name;

                    rowResults = await _volunteerService.CreateVolunteerAsync(volunteerModel);
                    if (rowResults > 0)
                    {
                        responseObject.Status = "1";
                        responseObject.Message = "User Created Successfully.";
                        return StatusCode(StatusCodes.Status201Created, responseObject);
                    }
                    else
                    {
                        await _registrationService.DeleteAsync(signUpModel.RegistrationId);

                        responseObject.Status = "0";
                        responseObject.Message = "User Creation Unsuccessful, please try again";
                        return StatusCode(StatusCodes.Status500InternalServerError, responseObject);
                    }
                }
                else
                {
                    responseObject.Status = "0";
                    responseObject.Message = "User Creation Unsuccessful, please try again";
                    return StatusCode(StatusCodes.Status500InternalServerError, responseObject);
                }
            }
            catch (Exception ex)
            {
                responseObject.Status = "-1";
                responseObject.Message = "An exception occurred. Exception: " + ex.Message;
                return StatusCode(StatusCodes.Status500InternalServerError, responseObject);
            }
        }

        [HttpPost]
        public async Task<IActionResult> SignIn([FromBody] SignInModel signInModel)
        {
            ResponseModel responseObject = new ResponseModel();

            try
            {
                int registrationType = await _registrationService.SignIn(signInModel);

                if (registrationType != -1)
                {
                    if (registrationType == 1)
                    {
                        VolunteerModel volunteerModel = await _volunteerService.GetVolunteerByRegistrationId(signInModel.RegistrationId);
                        if(volunteerModel != null)
                        {
                            responseObject.Status = "1";
                            responseObject.Message = "Account Found Successfully, Volunteer.";
                            responseObject.OtherInformation = volunteerModel;
                            return StatusCode(StatusCodes.Status302Found, responseObject);
                        }
                    }
                }

                responseObject.Status = "0";
                responseObject.Message = "Invalid Credentials.";
                return StatusCode(StatusCodes.Status400BadRequest, responseObject);
            }
            catch (Exception ex)
            {
                responseObject.Status = "-1";
                responseObject.Message = "An exception occurred. Exception: " + ex.Message;
                return StatusCode(StatusCodes.Status500InternalServerError, responseObject);
            }
        }

    }
}
