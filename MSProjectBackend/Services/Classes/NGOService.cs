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
    public class NGOService : INGOService
    {
        private readonly INGORepository _ngoRepository;

        public NGOService(INGORepository ngoRepository)
        {
            _ngoRepository = ngoRepository;
        }

        public async Task<List<NGOModel>> GetAllNGOs()
        {
            List<NGO> ngoList = await _ngoRepository.GetAllAsync();
            return EntitiesToModels(ngoList);
        }

        public async Task<NGOModel> GetNGOById(int id)
        {
            NGO ngo = await _ngoRepository.GetByIdAsync(id);
            return EntityToModel(ngo);
        }

        public async Task<NGOModel> GetNGOByRegistrationId(string registrationId)
        {
            NGO ngo = await _ngoRepository.GetByRegistrationIdAsync(registrationId);
            return EntityToModel(ngo);
        }

        public async Task<int> CreateNGOAsync(NGOModel ngoModel)
        {
            NGO ngo = ModelToEntity(ngoModel);
            ngo.RegistrationId = ngoModel.RegistrationId;
            return await _ngoRepository.CreateAsync(ngo);
        }

        public async Task<int> UpdateNGOAsync(NGOModel ngoModel)
        {
            NGO ngo = ModelToEntity(ngoModel);
            ngo.Id = ngoModel.Id;
            return await _ngoRepository.UpdateAsync(ngo);
        }

        public async Task<int> DeleteNGOAsync(int id)
        {
            return await _ngoRepository.DeleteAsync(id);
        }

        private NGO ModelToEntity(NGOModel ngoModel)
        {
            NGO ngo = new NGO();

            ngo.Id = ngoModel.Id;
            ngo.Name = ngoModel.Name;
            ngo.Email = ngoModel.Email;
            ngo.RegistrationNumber = ngoModel.RegistrationId;
            if (!string.IsNullOrEmpty(ngoModel.RegistrationDate))
                ngo.RegistrationDate = Convert.ToDateTime(ngoModel.RegistrationDate);
            ngo.Address = ngoModel.Address;
            ngo.About = ngoModel.About;
            ngo.ProvinceId = ngoModel.ProvinceId;
            ngo.CityId = ngoModel.CityId;
            ngo.AreasOfWork = ngoModel.AreasOfWork;

            return ngo;
        }

        private NGOModel EntityToModel(NGO ngo)
        {
            NGOModel ngoModel = new NGOModel();

            ngoModel.Id = ngo.Id;
            ngoModel.RegistrationId = ngo.RegistrationId;
            ngoModel.Name = ngo.Name;
            ngoModel.Email = ngo.Email;
            ngoModel.RegistrationNumber = ngo.RegistrationId;
            if (ngo.RegistrationDate != null)
                ngoModel.RegistrationDate = Convert.ToDateTime(ngo.RegistrationDate).ToString("yyyy-MM-dd");
            ngoModel.Address = ngo.Address;
            ngoModel.About = ngo.About;
            ngoModel.ProvinceId = ngo.ProvinceId;
            ngoModel.CityId = ngo.CityId;
            ngoModel.AreasOfWork = ngo.AreasOfWork;

            return ngoModel;
        }

        private List<NGOModel> EntitiesToModels(List<NGO> ngos)
        {
            List<NGOModel> ngoModels = new List<NGOModel>();
            foreach (NGO ngo in ngos)
            {
                NGOModel ngoModel = new NGOModel();

                ngoModel.Id = ngo.Id;
                ngoModel.RegistrationId = ngo.RegistrationId;
                ngoModel.Name = ngo.Name;
                ngoModel.Email = ngo.Email;
                ngoModel.RegistrationNumber = ngo.RegistrationId;
                if (ngo.RegistrationDate != null)
                    ngoModel.RegistrationDate = Convert.ToDateTime(ngo.RegistrationDate).ToString("yyyy-MM-dd");
                ngoModel.Address = ngo.Address;
                ngoModel.About = ngo.About;
                ngoModel.ProvinceId = ngo.ProvinceId;
                ngoModel.CityId = ngo.CityId;
                ngoModel.AreasOfWork = ngo.AreasOfWork;

                ngoModels.Add(ngoModel);
            }
            return ngoModels;
        }

    }
}
