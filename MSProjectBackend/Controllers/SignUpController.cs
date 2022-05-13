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
        private readonly ISignUpService _signUpService;
        
        public SignUpController(ISignUpService signUpService)
        {
            _signUpService = signUpService;
        }

        [HttpPost]
        public async Task<IActionResult> AddVolunteer([FromBody] SignUpModel signUpModel)
        {
            ResponseModel responseObject = new ResponseModel();

            try
            {
                int rowResults = await _signUpService.CreateVolunteerAsync(signUpModel);

                if (rowResults > 0)
                {
                    responseObject.Status = "1";
                    responseObject.Message = "User Created Successfully.";
                    return StatusCode(StatusCodes.Status201Created, responseObject);
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
