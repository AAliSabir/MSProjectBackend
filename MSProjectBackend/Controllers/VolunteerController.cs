using Backend.Models.AppModels;
using Backend.Services.Interfaces;
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
        public async Task<List<VolunteerModel>> GetAllVolunteers()
        {
            try
            {
                return await _volunteerService.GetAllVolunteers();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        
        [HttpGet("{volunteerId}")]
        public async Task<VolunteerModel> GetVolunteerById(int volunteerId)
        {
            try
            {
                return await _volunteerService.GetVolunteerById(volunteerId);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        
        [HttpPost]
        public async Task<IActionResult> AddVolunteer(VolunteerModel volunteer)
        {
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
                throw ex;
            }            
        }

        
        [HttpPut("{id}")]
        public async Task<VolunteerModel> UpdateVolunteer(VolunteerModel volunteerModel)
        {
            try
            {
                int id = Convert.ToInt32(this.RouteData.Values["id"]);

                int rows = await _volunteerService.UpdateVolunteerAsync(id, volunteerModel);
                VolunteerModel volunteerModelDb = await _volunteerService.GetVolunteerById(id);

                return volunteerModelDb;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        [HttpDelete("{id}")]
        public async void DeleteCategory(int id)
        {
            try
            {
                int rows = await _volunteerService.DeleteVolunteerAsync(id);
            }
            catch(Exception ex)
            {
                throw ex;
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
