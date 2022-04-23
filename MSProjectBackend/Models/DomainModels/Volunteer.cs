using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Backend.Models.DomainModels
{
    public class Volunteer : BaseEntity
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
