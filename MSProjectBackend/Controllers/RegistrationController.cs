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
        private readonly INGOService _ngoService;

        public RegistrationController(IRegistrationService registrationService, IVolunteerService volunteerService, INGOService ngoService)
        {
            _registrationService = registrationService;
            _volunteerService = volunteerService;
            _ngoService = ngoService;
        }

        [HttpPost]
        public async Task<IActionResult> SignUp([FromBody] SignUpModel signUpModel)
        {
            ResponseModel responseObject = new ResponseModel();

            try
            {
                int rowResults = await _registrationService.CreateAsync(signUpModel);

                if(rowResults > 0)
                {
                    if (signUpModel.RegistrationType == 1)
                    {
                        try
                        {
                            VolunteerModel volunteerModel = new VolunteerModel();
                            volunteerModel.RegistrationId = signUpModel.RegistrationId;
                            volunteerModel.Name = signUpModel.Name;

                            rowResults = await _volunteerService.CreateVolunteerAsync(volunteerModel);
                        }
                        catch(Exception ex)
                        {
                            await _registrationService.DeleteAsync(signUpModel.RegistrationId);
                            throw ex;
                        }
                    }
                    else
                    {
                        try
                        {
                            NGOModel ngoModel = new NGOModel();
                            ngoModel.RegistrationId = signUpModel.RegistrationId;
                            ngoModel.Name = signUpModel.Name;

                            rowResults = await _ngoService.CreateNGOAsync(ngoModel);
                        }
                        catch (Exception ex)
                        {
                            await _registrationService.DeleteAsync(signUpModel.RegistrationId);
                            throw ex;
                        }
                    }

                    if (rowResults > 0)
                    {
                        responseObject.Status = "1";
                        responseObject.Message = "Sign Up Successful.";
                        return StatusCode(StatusCodes.Status201Created, responseObject);
                    }
                    else
                    {
                        await _registrationService.DeleteAsync(signUpModel.RegistrationId);
                        responseObject.Status = "0";
                        responseObject.Message = "Sign Up Unsuccessful, please try again";
                        return StatusCode(StatusCodes.Status500InternalServerError, responseObject);
                    }

                }
                else
                {
                    responseObject.Status = "0";
                    responseObject.Message = "Sign Up Unsuccessful, please try again";
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
                            responseObject.Message = "Account Found Successfully, 1.";
                            responseObject.OtherInformation = volunteerModel;
                            return StatusCode(StatusCodes.Status200OK, responseObject);
                        }
                    }
                    else
                    {
                        NGOModel ngoModel = await _ngoService.GetNGOByRegistrationId(signInModel.RegistrationId);
                        if (ngoModel != null)
                        {
                            responseObject.Status = "1";
                            responseObject.Message = "Account Found Successfully, 1.";
                            responseObject.OtherInformation = ngoModel;
                            return StatusCode(StatusCodes.Status200OK, responseObject);
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
