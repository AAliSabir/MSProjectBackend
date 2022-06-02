using MSProjectBackend.Models.AppModels;
using MSProjectBackend.Models.DomainModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MSProjectBackend.Services.Interfaces
{
    public interface INGOAppealService
    {
        Task<List<NGOAppealModel>> GetAllNGOAppeals();
        Task<NGOAppealModel> GetNGOAppealById(int id);
        Task<int> CreateNGOAppealAsync(NGOAppealModel ngoAppealModel);
        Task<int> UpdateNGOAppealAsync(NGOAppealModel ngoAppealModel);
        Task<int> DeleteNGOAppealAsync(int id);
    }
}
