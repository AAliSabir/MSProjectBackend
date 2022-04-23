using Backend.Models.AppModels;
using Backend.Models.DomainModels;
using Backend.Repositories.Interfaces;
using Backend.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;

namespace Backend.Services.Classes
{
    public class VolunteerService : IVolunteerService
    {
        private readonly IVolunteerRepository _volunteerRepository;

        public VolunteerService(IVolunteerRepository volunteerRepository)
        {
            _volunteerRepository = volunteerRepository;
        }

        public async Task<List<VolunteerModel>> GetAllVolunteers()
        {
            List<Volunteer> volunteers = await _volunteerRepository.GetAllAsync();
            return EntitiesToModels(volunteers);
        }

        public async Task<VolunteerModel> GetVolunteerById(int id)
        {
            Volunteer volunteer = await _volunteerRepository.GetByIdAsync(id);
            return EntityToModel(volunteer);
        }

        public async Task<int> CreateVolunteerAsync(VolunteerModel volunteerModel)
        {
            Volunteer volunteer = ModelToEntity(volunteerModel);
            return await _volunteerRepository.CreateAsync(volunteer);
        }

        public async Task<int> UpdateVolunteerAsync(int id, VolunteerModel volunteerModel)
        {
            Volunteer volunteer = ModelToEntity(volunteerModel);
            return await _volunteerRepository.UpdateAsync(volunteer);
        }

        public async Task<int> DeleteVolunteerAsync(int id)
        {
            return await _volunteerRepository.DeleteAsync(id);
        }

        private Volunteer ModelToEntity(VolunteerModel volunteerModel)
        {
            Volunteer volunteer = new Volunteer();

            volunteer.Id = volunteerModel.Id;
            volunteer.Name = volunteerModel.Name;
            volunteer.Age = volunteerModel.Age;
            volunteer.CNIC = volunteerModel.CNIC;
            volunteer.ContactNo = volunteerModel.ContactNo;
            volunteer.Email = volunteerModel.Email;
            volunteer.Gender = volunteerModel.Gender;
            volunteer.IsIndependent = volunteerModel.IsIndependent;
            volunteer.NGOId = volunteerModel.NGOId;

            return volunteer;
        }

        private VolunteerModel EntityToModel(Volunteer volunteer)
        {
            VolunteerModel volunteerModel = new VolunteerModel();

            volunteerModel.Id = volunteer.Id;
            volunteerModel.Name = volunteer.Name;
            volunteerModel.Age = volunteer.Age;
            volunteerModel.CNIC = volunteer.CNIC;
            volunteerModel.ContactNo = volunteer.ContactNo;
            volunteerModel.Email = volunteer.Email;
            volunteerModel.Gender = volunteer.Gender;
            volunteerModel.IsIndependent = volunteer.IsIndependent;
            volunteerModel.NGOId = volunteer.NGOId;

            return volunteerModel;
        }

        private List<VolunteerModel> EntitiesToModels(List<Volunteer> volunteers)
        {
            List<VolunteerModel> volunteerModels = new List<VolunteerModel>();
            foreach (Volunteer volunteer in volunteers)
            {
                VolunteerModel volunteerModel = new VolunteerModel();

                volunteerModel.Id = volunteer.Id;
                volunteerModel.Name = volunteer.Name;
                volunteerModel.Age = volunteer.Age;
                volunteerModel.CNIC = volunteer.CNIC;
                volunteerModel.ContactNo = volunteer.ContactNo;
                volunteerModel.Email = volunteer.Email;
                volunteerModel.Gender = volunteer.Gender;
                volunteerModel.IsIndependent = volunteer.IsIndependent;
                volunteerModel.NGOId = volunteer.NGOId;

                volunteerModels.Add(volunteerModel);
            }
            return volunteerModels;
        }
    }
}
