using MSProjectBackend.Models.AppModels;
using MSProjectBackend.Models.DomainModels;
using MSProjectBackend.Repositories.Interfaces;
using MSProjectBackend.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;

namespace MSProjectBackend.Services.Classes
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

        public async Task<int> UpdateVolunteerAsync(VolunteerModel volunteerModel)
        {
            Volunteer volunteer = ModelToEntity(volunteerModel);
            volunteer.Id = volunteerModel.Id;
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
            volunteer.RegistrationId = volunteerModel.RegistrationId;
            volunteer.Name = volunteerModel.Name;
            if(!string.IsNullOrEmpty(volunteerModel.DateOfBirth))
                volunteer.DateOfBirth = Convert.ToDateTime(volunteerModel.DateOfBirth);
            volunteer.CNIC = volunteerModel.CNIC;
            volunteer.ContactNo = volunteerModel.ContactNo;
            volunteer.Email = volunteerModel.Email;
            volunteer.Gender = volunteerModel.Gender;
            volunteer.Address = volunteerModel.Address;
            volunteer.ProvinceId = volunteerModel.ProvinceId;
            volunteer.CityId = volunteerModel.CityId;
            volunteer.EducationId = volunteerModel.EducationId;
            volunteer.About = volunteerModel.About;
            volunteer.Skills = volunteerModel.Skills;
            volunteer.AreasOfInterest = volunteerModel.AreasOfInterest;
            volunteer.Availability = volunteerModel.Availability;
            volunteer.IsIndependent = volunteerModel.IsIndependent;
            volunteer.NGOId = volunteerModel.NGOId;

            return volunteer;
        }

        private VolunteerModel EntityToModel(Volunteer volunteer)
        {
            VolunteerModel volunteerModel = new VolunteerModel();

            volunteerModel.Id = volunteer.Id;
            volunteerModel.Name = volunteer.Name;
            if(volunteer.DateOfBirth != null)
                volunteerModel.DateOfBirth = Convert.ToDateTime(volunteer.DateOfBirth).ToString("yyyy-MM-dd");
            volunteerModel.CNIC = volunteer.CNIC;
            volunteerModel.ContactNo = volunteer.ContactNo;
            volunteerModel.Email = volunteer.Email;
            volunteerModel.Gender = volunteer.Gender;
            volunteerModel.Address = volunteer.Address;
            volunteerModel.ProvinceId = volunteer.ProvinceId;
            volunteerModel.CityId = volunteer.CityId;
            volunteerModel.EducationId = volunteer.EducationId;
            volunteerModel.About = volunteer.About;
            volunteerModel.Skills = volunteer.Skills;
            volunteerModel.AreasOfInterest = volunteer.AreasOfInterest;
            volunteerModel.Availability = volunteer.Availability;
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
                if (volunteer.DateOfBirth != null)
                    volunteerModel.DateOfBirth = Convert.ToDateTime(volunteer.DateOfBirth).ToString("yyyy-MM-dd");
                volunteerModel.CNIC = volunteer.CNIC;
                volunteerModel.ContactNo = volunteer.ContactNo;
                volunteerModel.Email = volunteer.Email;
                volunteerModel.Gender = Convert.ToInt32(volunteer.Gender);
                volunteerModel.IsIndependent = Convert.ToBoolean(volunteer.IsIndependent);
                volunteerModel.NGOId = Convert.ToInt32(volunteer.NGOId);

                volunteerModels.Add(volunteerModel);
            }
            return volunteerModels;
        }
    }
}
