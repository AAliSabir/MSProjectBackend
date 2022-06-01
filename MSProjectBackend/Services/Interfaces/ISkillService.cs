using MSProjectBackend.Models.DomainModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MSProjectBackend.Services.Interfaces
{
    public interface ISkillService
    {
        Task<List<Skill>> GetAllSkills();
        Task<Skill> GetSkillById(int id);
        Task<int> CreateSkillAsync(Skill skill);
        Task<int> UpdateSkillAsync(Skill skill);
        Task<int> DeleteSkillAsync(int id);
    }
}
