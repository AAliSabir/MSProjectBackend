using MSProjectBackend.Models.AppModels;
using MSProjectBackend.Models.DomainModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MSProjectBackend.Services.Interfaces
{
    public interface IProjectService
    {
        Task<List<ProjectModel>> GetAllProjects();
        Task<ProjectModel> GetProjectById(int id);
        Task<int> CreateProjectAsync(ProjectModel projectModel);
        Task<int> UpdateProjectAsync(ProjectModel projectModel);
        Task<int> DeleteProjectAsync(int id);
    }
}
