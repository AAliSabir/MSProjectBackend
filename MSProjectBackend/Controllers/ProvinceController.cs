using MSProjectBackend.Models.AppModels;
using MSProjectBackend.Services.Interfaces;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Backend.Controllers
{
    [EnableCors("CorsPolicy"), Route("api/[controller]/[action]")]
    [ApiController]
    public class ProvinceController : ControllerBase
    {
        private readonly IProvinceService _provinceService;

        public ProvinceController(IProvinceService provinceService)
        {
            _provinceService = provinceService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllProvinces()
        {
            ResponseModel responseObject = new ResponseModel();

            try
            {
                responseObject.Status = "1";
                responseObject.Message = "Success.";
                responseObject.OtherInformation = await _provinceService.GetAllProvinces();
                return StatusCode(StatusCodes.Status200OK, responseObject);
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