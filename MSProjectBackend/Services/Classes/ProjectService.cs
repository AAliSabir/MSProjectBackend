using MSProjectBackend.Models.AppModels;
using MSProjectBackend.Models.DomainModels;
using MSProjectBackend.Repositories.Interfaces;
using MSProjectBackend.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MSProjectBackend.Services.Classes
{
    public class ProjectService : IProjectService
    {
        private readonly IProjectRepository _projectRepository;

        public ProjectService(IProjectRepository projectRepository)
        {
            _projectRepository = projectRepository;
        }

        public async Task<List<ProjectModel>> GetAllProjects()
        {
            List<Project> projectList = await _projectRepository.GetAllAsync();
            return EntitiesToModels(projectList);
        }

        public async Task<ProjectModel> GetProjectById(int id)
        {
            Project project = await _projectRepository.GetByIdAsync(id);
            return EntityToModel(project);
        }

        public async Task<int> CreateProjectAsync(ProjectModel projectModel)
        {
            Project project = ModelToEntity(projectModel);
            return await _projectRepository.CreateAsync(project);
        }

        public async Task<int> UpdateProjectAsync(ProjectModel projectModel)
        {
            Project project = ModelToEntity(projectModel);
            project.Id = projectModel.Id;
            return await _projectRepository.UpdateAsync(project);
        }

        public async Task<int> DeleteProjectAsync(int id)
        {
            return await _projectRepository.DeleteAsync(id);
        }

        private Project ModelToEntity(ProjectModel projectModel)
        {
            Project project = new Project();

            project.Id = projectModel.Id;
            project.NGOId = projectModel.NGOId;
            project.Name = projectModel.Name;
            project.About = projectModel.About;
            project.ProvinceId = projectModel.ProvinceId;
            project.CityId = projectModel.CityId;
            project.CategoryId = projectModel.CategoryId;
            project.IsSubproject = projectModel.IsSubproject;
            project.ParentProjectId = projectModel.ParentProjectId;

            return project;
        }

        private ProjectModel EntityToModel(Project project)
        {
            ProjectModel projectModel = new ProjectModel();

            projectModel.Id = project.Id;
            projectModel.NGOId = project.NGOId;
            projectModel.Name = project.Name;
            projectModel.About = project.About;
            projectModel.ProvinceId = project.ProvinceId;
            projectModel.CityId = project.CityId;
            projectModel.CategoryId = project.CategoryId;
            projectModel.IsSubproject = project.IsSubproject;
            projectModel.ParentProjectId = project.ParentProjectId;

            return projectModel;
        }

        private List<ProjectModel> EntitiesToModels(List<Project> projects)
        {
            List<ProjectModel> projectModels = new List<ProjectModel>();
            foreach (Project project in projects)
            {
                ProjectModel projectModel = new ProjectModel();

                projectModel.Id = project.Id;
                projectModel.NGOId = project.NGOId;
                projectModel.Name = project.Name;
                projectModel.About = project.About;
                projectModel.ProvinceId = project.ProvinceId;
                projectModel.CityId = project.CityId;
                projectModel.CategoryId = project.CategoryId;
                projectModel.IsSubproject = project.IsSubproject;
                projectModel.ParentProjectId = project.ParentProjectId;

                projectModels.Add(projectModel);
            }
            return projectModels;
        }
    }
}
