using MSProjectBackend.Models.AppModels;
using MSProjectBackend.Models.DomainModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MSProjectBackend.Services.Interfaces
{
    public interface INGOService
    {
        Task<List<NGOModel>> GetAllNGOs();
        Task<NGOModel> GetNGOById(int id);
        Task<NGOModel> GetNGOByRegistrationId(string registrationId);
        Task<int> CreateNGOAsync(NGOModel ngoModel);
        Task<int> UpdateNGOAsync(NGOModel ngoModel);
        Task<int> DeleteNGOAsync(int id);
    }
}
