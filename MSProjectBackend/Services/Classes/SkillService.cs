using MSProjectBackend.Models.DomainModels;
using MSProjectBackend.Repositories.Interfaces;
using MSProjectBackend.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MSProjectBackend.Services.Classes
{
    public class SkillService : ISkillService
    {
        private readonly ISkillRepository _skillRepository;

        public SkillService(ISkillRepository skillRepository)
        {
            _skillRepository = skillRepository;
        }

        public async Task<List<Skill>> GetAllSkills()
        {
            return await _skillRepository.GetAllAsync();
        }

        public async Task<Skill> GetSkillById(int id)
        {
            return await _skillRepository.GetByIdAsync(id);
        }

        public async Task<int> CreateSkillAsync(Skill skill)
        {
            return await _skillRepository.CreateAsync(skill);
        }

        public async Task<int> UpdateSkillAsync(Skill skill)
        {
            return await _skillRepository.UpdateAsync(skill);
        }

        public async Task<int> DeleteSkillAsync(int id)
        {
            return await _skillRepository.DeleteAsync(id);
        }
    }
}
