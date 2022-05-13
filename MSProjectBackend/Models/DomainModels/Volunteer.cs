using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MSProjectBackend.Models.DomainModels
{
    public class Volunteer : BaseEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime? DateOfBirth { get; set; }
        public string CNIC { get; set; }
        public string ContactNo { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public int? Gender { get; set; }
        public string Address { get; set; }
        public int? ProvinceId { get; set; }
        public int? CityId { get; set; }
        public int? EducationId { get; set; }
        public string About { get; set; }
        public string Skills { get; set; }
        public string AreasOfInterest { get; set; }
        public string Availability { get; set; }
        public bool? IsIndependent { get; set; }
        public int? NGOId { get; set; }
        /*
         USE [PracticeDB]
        GO
        SET ANSI_NULLS ON
        GO
        SET QUOTED_IDENTIFIER ON
        GO

        CREATE TABLE[dbo].[Products]
        (

            [Id][int] NOT NULL,
            [Name] [nvarchar] (100) NULL,
	        [Age] [decimal](18, 0) NULL,
	        [Quantity] [int] NOT NULL

        ) ON[PRIMARY]
        GO
         */
    }
}
