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
    public class NGOAppealController : ControllerBase
    {
        private readonly INGOAppealService _ngoAppealService;

        public NGOAppealController(INGOAppealService ngoAppealService)
        {
            _ngoAppealService = ngoAppealService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllNGOAppeals()
        {
            ResponseModel responseObject = new ResponseModel();

            try
            {
                //List<NGOModel>
                responseObject.Status = "1";
                responseObject.Message = "Success.";
                responseObject.OtherInformation = await _ngoAppealService.GetAllNGOAppeals();
                return StatusCode(StatusCodes.Status200OK, responseObject);
            }
            catch (Exception ex)
            {
                responseObject.Status = "-1";
                responseObject.Message = "An exception occurred. Exception: " + ex.Message;
                return StatusCode(StatusCodes.Status500InternalServerError, responseObject);
            }
        }

        
        [HttpGet]
        public async Task<IActionResult> GetNGOAppealById([FromQuery]int ngoAppealId)
        {
            ResponseModel responseObject = new ResponseModel();

            try
            {
                NGOAppealModel ngoAppealModel = await _ngoAppealService.GetNGOAppealById(ngoAppealId);

                responseObject.Status = "1";
                responseObject.Message = "NGO Appeal retrieved successfully.";
                responseObject.OtherInformation = ngoAppealModel;
                return StatusCode(StatusCodes.Status201Created, responseObject);
            }
            catch (Exception ex)
            {
                responseObject.Status = "-1";
                responseObject.Message = "An exception occurred. Exception: " + ex.Message;
                return StatusCode(StatusCodes.Status500InternalServerError, responseObject);
            }
        }
        
        [HttpPost]
        public async Task<IActionResult> AddNGOAppeal([FromBody]NGOAppealModel ngoAppeal)
        {
            ResponseModel responseObject = new ResponseModel();

            try
            {
                int rowResults = await _ngoAppealService.CreateNGOAppealAsync(ngoAppeal);

                if (rowResults > 0)
                    return Ok();
                else
                    return BadRequest();
            }
            catch (Exception ex)
            {
                responseObject.Status = "-1";
                responseObject.Message = "An exception occurred. Exception: " + ex.Message;
                return StatusCode(StatusCodes.Status500InternalServerError, responseObject);
            }            
        }


        [HttpPut]
        public async Task<IActionResult> UpdateNGOAppeal([FromBody]NGOAppealModel ngoAppealModel)
        {
            ResponseModel responseObject = new ResponseModel();

            try
            {
                int rows = await _ngoAppealService.UpdateNGOAppealAsync(ngoAppealModel);
                NGOAppealModel ngoAppealModelDb = await _ngoAppealService.GetNGOAppealById(ngoAppealModel.Id);

                responseObject.Status = "1";
                responseObject.Message = "NGO Appeal updated successfully.";
                return StatusCode(StatusCodes.Status200OK, responseObject);
            }
            catch (Exception ex)
            {
                responseObject.Status = "-1";
                responseObject.Message = "An exception occurred. Exception: " + ex.Message;
                return StatusCode(StatusCodes.Status500InternalServerError, responseObject);
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteNGOAppeal(int id)
        {
            ResponseModel responseObject = new ResponseModel();

            try
            {
                int rows = await _ngoAppealService.DeleteNGOAppealAsync(id);
                responseObject.Status = "1";
                responseObject.Message = "Deletion Successful";
                return StatusCode(StatusCodes.Status200OK, responseObject);
            }
            catch(Exception ex)
            {
                responseObject.Status = "-1";
                responseObject.Message = "An exception occurred. Exception: " + ex.Message;
                return StatusCode(StatusCodes.Status500InternalServerError, responseObject);
            }
        }
    }
}
