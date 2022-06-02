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
    public class ProjectController : ControllerBase
    {
        private readonly IProjectService _projectService;

        public ProjectController(IProjectService projectService)
        {
            _projectService = projectService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllProjects()
        {
            ResponseModel responseObject = new ResponseModel();

            try
            {
                responseObject.Status = "1";
                responseObject.Message = "Success.";
                responseObject.OtherInformation = await _projectService.GetAllProjects();
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
        public async Task<IActionResult> GetProjectById([FromQuery]int projectId)
        {
            ResponseModel responseObject = new ResponseModel();

            try
            {
                ProjectModel projectModel = await _projectService.GetProjectById(projectId);

                responseObject.Status = "1";
                responseObject.Message = "Project retrieved successfully.";
                responseObject.OtherInformation = projectModel;
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
        public async Task<IActionResult> AddProject([FromBody]ProjectModel project)
        {
            ResponseModel responseObject = new ResponseModel();

            try
            {
                int rowResults = await _projectService.CreateProjectAsync(project);

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
        public async Task<IActionResult> UpdateProject([FromBody]ProjectModel projectModel)
        {
            ResponseModel responseObject = new ResponseModel();

            try
            {
                int rows = await _projectService.UpdateProjectAsync(projectModel);
                ProjectModel ProjectModelDb = await _projectService.GetProjectById(projectModel.Id);

                responseObject.Status = "1";
                responseObject.Message = "Project updated successfully.";
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
        public async Task<IActionResult> DeleteProject(int id)
        {
            ResponseModel responseObject = new ResponseModel();

            try
            {
                int rows = await _projectService.DeleteProjectAsync(id);
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
