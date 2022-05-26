using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using MSProjectBackend.Models.AppModels;
using MSProjectBackend.Services.Interfaces;

namespace MSProjectBackend.Controllers
{
    [EnableCors("CorsPolicy"), Route("api/[controller]/[action]")]
    [ApiController]
    public class SignUpController : ControllerBase
    {
        private readonly IRegistrationService _signUpService;
        private readonly IVolunteerService _volunteerService;

        public SignUpController(IRegistrationService signUpService, IVolunteerService volunteerService)
        {
            _signUpService = signUpService;
            _volunteerService = volunteerService;
        }

        [HttpPost]
        public async Task<IActionResult> AddVolunteer([FromBody] SignUpModel signUpModel)
        {
            ResponseModel responseObject = new ResponseModel();

            try
            {
                int rowResults = await _signUpService.CreateAsync(signUpModel);

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
                        await _signUpService.DeleteAsync(signUpModel.RegistrationId);

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

    }
}
