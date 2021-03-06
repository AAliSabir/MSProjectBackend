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
    public class NGOController : ControllerBase
    {
        private readonly INGOService _ngoService;

        public NGOController(INGOService ngoService)
        {
            _ngoService = ngoService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllNGOs()
        {
            ResponseModel responseObject = new ResponseModel();

            try
            {
                responseObject.Status = "1";
                responseObject.Message = "Success.";
                responseObject.OtherInformation = await _ngoService.GetAllNGOs();
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
        public async Task<IActionResult> GetNGOById([FromQuery]int ngoId)
        {
            ResponseModel responseObject = new ResponseModel();

            try
            {
                NGOModel ngoModel = await _ngoService.GetNGOById(ngoId);

                responseObject.Status = "1";
                responseObject.Message = "NGO profile retrieved successfully.";
                responseObject.OtherInformation = ngoModel;
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
        public async Task<IActionResult> AddNGO([FromBody]NGOModel ngo)
        {
            ResponseModel responseObject = new ResponseModel();

            try
            {
                int rowResults = await _ngoService.CreateNGOAsync(ngo);

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
        public async Task<IActionResult> UpdateNGO([FromBody]NGOModel ngoModel)
        {
            ResponseModel responseObject = new ResponseModel();

            try
            {
                int rows = await _ngoService.UpdateNGOAsync(ngoModel);
                NGOModel NGOModelDb = await _ngoService.GetNGOById(ngoModel.Id);

                responseObject.Status = "1";
                responseObject.Message = "NGO profile updated successfully.";
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
        public async Task<IActionResult> DeleteNGO(int id)
        {
            ResponseModel responseObject = new ResponseModel();

            try
            {
                int rows = await _ngoService.DeleteNGOAsync(id);
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
