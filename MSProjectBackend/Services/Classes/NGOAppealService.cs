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
    public class NGOAppealService : INGOAppealService
    {
        private readonly INGOAppealRepository _ngoAppealRepository;

        public NGOAppealService(INGOAppealRepository ngoAppealRepository)
        {
            _ngoAppealRepository = ngoAppealRepository;
        }

        public async Task<List<NGOAppealModel>> GetAllNGOAppeals()
        {
            List<NGOAppeal> ngoAppealList = await _ngoAppealRepository.GetAllAsync();
            return EntitiesToModels(ngoAppealList);
        }

        public async Task<NGOAppealModel> GetNGOAppealById(int id)
        {
            NGOAppeal ngoAppeal = await _ngoAppealRepository.GetByIdAsync(id);
            return EntityToModel(ngoAppeal);
        }

        public async Task<int> CreateNGOAppealAsync(NGOAppealModel ngoAppealModel)
        {
            NGOAppeal ngoAppeal = ModelToEntity(ngoAppealModel);
            return await _ngoAppealRepository.CreateAsync(ngoAppeal);
        }

        public async Task<int> UpdateNGOAppealAsync(NGOAppealModel ngoAppealModel)
        {
            NGOAppeal ngoAppeal = ModelToEntity(ngoAppealModel);
            ngoAppeal.Id = ngoAppealModel.Id;
            return await _ngoAppealRepository.UpdateAsync(ngoAppeal);
        }

        public async Task<int> DeleteNGOAppealAsync(int id)
        {
            return await _ngoAppealRepository.DeleteAsync(id);
        }

        private NGOAppeal ModelToEntity(NGOAppealModel ngoAppealModel)
        {
            NGOAppeal ngoAppeal = new NGOAppeal();

            ngoAppeal.Id = ngoAppealModel.Id;
            ngoAppeal.NGOId = ngoAppealModel.NGOId;
            ngoAppeal.About = ngoAppealModel.About;
            ngoAppeal.ProjectId = ngoAppealModel.ProjectId;
            ngoAppeal.IsVolunteerCall = ngoAppealModel.IsVolunteerCall;
            ngoAppeal.VolunteersNeeded = ngoAppealModel.VolunteersNeeded;
            ngoAppeal.IsDonationsCall = ngoAppealModel.IsDonationsCall;
            ngoAppeal.DonationsTarget = ngoAppealModel.DonationsTarget;
            
            return ngoAppeal;
        }

        private NGOAppealModel EntityToModel(NGOAppeal ngoAppeal)
        {
            NGOAppealModel ngoAppealModel = new NGOAppealModel();

            ngoAppealModel.Id = ngoAppeal.Id;
            ngoAppealModel.NGOId = ngoAppeal.NGOId;
            ngoAppealModel.About = ngoAppeal.About;
            ngoAppealModel.ProjectId = ngoAppeal.ProjectId;
            ngoAppealModel.IsVolunteerCall = ngoAppeal.IsVolunteerCall;
            ngoAppealModel.VolunteersNeeded = ngoAppeal.VolunteersNeeded;
            ngoAppealModel.IsDonationsCall = ngoAppeal.IsDonationsCall;
            ngoAppealModel.DonationsTarget = ngoAppeal.DonationsTarget;

            return ngoAppealModel;
        }

        private List<NGOAppealModel> EntitiesToModels(List<NGOAppeal> ngoAppeals)
        {
            List<NGOAppealModel> ngoAppealModels = new List<NGOAppealModel>();
            foreach (NGOAppeal ngoAppeal in ngoAppeals)
            {
                NGOAppealModel ngoAppealModel = new NGOAppealModel();

                ngoAppealModel.Id = ngoAppeal.Id;
                ngoAppealModel.NGOId = ngoAppeal.NGOId;
                ngoAppealModel.About = ngoAppeal.About;
                ngoAppealModel.ProjectId = ngoAppeal.ProjectId;
                ngoAppealModel.IsVolunteerCall = ngoAppeal.IsVolunteerCall;
                ngoAppealModel.VolunteersNeeded = ngoAppeal.VolunteersNeeded;
                ngoAppealModel.IsDonationsCall = ngoAppeal.IsDonationsCall;
                ngoAppealModel.DonationsTarget = ngoAppeal.DonationsTarget;

                ngoAppealModels.Add(ngoAppealModel);
            }
            return ngoAppealModels;
        }

    }
}
