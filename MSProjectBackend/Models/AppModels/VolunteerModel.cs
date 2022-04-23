using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Backend.Models.AppModels
{
    public class VolunteerModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }
        public string CNIC { get; set; }
        public string ContactNo { get; set; }
        public string Email { get; set; }
        public string Gender { get; set; }
        public bool IsIndependent { get; set; }
        public int NGOId { get; set; }
    }
}