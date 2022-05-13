using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MSProjectBackend.Models.AppModels
{
    public class VolunteerModel
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? DateOfBirth { get; set; }
        public string? CNIC { get; set; }
        public string? ContactNo { get; set; }
        public string? Email { get; set; }
        public int? Gender { get; set; }
        public string? Address { get; set; }
        public int? ProvinceId { get; set; }
        public int? CityId { get; set; }
        public int? EducationId { get; set; }
        public string? About { get; set; }
        public string? Skills { get; set; }
        public string? AreasOfInterest { get; set; }
        public string? Availability { get; set; }
        public bool? IsIndependent { get; set; }
        public int? NGOId { get; set; }
    }
}