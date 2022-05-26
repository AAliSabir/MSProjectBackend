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
    public class VolunteerController : ControllerBase
    {
        private readonly IVolunteerService _volunteerService;

        public VolunteerController(IVolunteerService volunteerService)
        {
            _volunteerService = volunteerService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllVolunteers()
        {
            ResponseModel responseObject = new ResponseModel();

            try
            {
                //List<VolunteerModel>
                responseObject.Status = "1";
                responseObject.Message = "Success.";
                responseObject.OtherInformation = await _volunteerService.GetAllVolunteers();
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
        public async Task<IActionResult> GetVolunteerById([FromQuery]int volunteerId)
        {
            ResponseModel responseObject = new ResponseModel();

            try
            {
                VolunteerModel volunteerModel = await _volunteerService.GetVolunteerById(volunteerId);

                responseObject.Status = "1";
                responseObject.Message = "Volunteer profile retrieved successfully.";
                responseObject.OtherInformation =  volunteerModel;
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
        public async Task<IActionResult> AddVolunteer([FromBody]VolunteerModel volunteer)
        {
            ResponseModel responseObject = new ResponseModel();

            try
            {
                int rowResults = await _volunteerService.CreateVolunteerAsync(volunteer);

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
        public async Task<IActionResult> UpdateVolunteer([FromBody]VolunteerModel volunteerModel)
        {
            ResponseModel responseObject = new ResponseModel();

            try
            {
                int rows = await _volunteerService.UpdateVolunteerAsync(volunteerModel);
                VolunteerModel volunteerModelDb = await _volunteerService.GetVolunteerById(volunteerModel.Id);

                responseObject.Status = "1";
                responseObject.Message = "Volunteer profile updated successfully.";
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
        public async Task<IActionResult> DeleteVolunteer(int id)
        {
            ResponseModel responseObject = new ResponseModel();

            try
            {
                int rows = await _volunteerService.DeleteVolunteerAsync(id);
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

        //[HttpGet("{id}")]
        //[Route("GetCategoryById")]
        //public ActionResult<Category> GetCategoryById([FromQuery]int categoryId)
        //{
        //    return categoryService.GetCategoryById(categoryId);
        //}

        //[HttpGet]
        //[Route("GetAllCategories")]
        //public ActionResult<List<Category>> GetAllCategories()
        //{
        //    return categoryService.GetAllCategories();
        //}

        //[HttpDelete("{id}")]
        //[Route("DeleteCategory")]
        //public void DeleteCategory([FromQuery]int id)
        //{

        //    itemService.deleteCategoryItems(id);
        //    categoryService.DeleteCategory(id);
        //}

        //[HttpPut("{id}")]
        //[Route("/{id}")]
        //public ActionResult<Category> UpdateCategory(Category category)
        //{
        //    int id = Convert.ToInt32(this.RouteData.Values["id"]);

        //    Category updatedCategory = categoryService.UpdateCategory(id, category);
        //    updatedCategory.id = id;
        //    return updatedCategory;
        //}
    }
}
