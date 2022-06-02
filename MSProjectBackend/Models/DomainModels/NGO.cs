namespace MSProjectBackend.Models.DomainModels
{
    public class NGO : BaseEntity
    {
        public int Id { get; set; }
        public string RegistrationId { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string RegistrationNumber { get; set; }
        public DateTime? RegistrationDate { get; set; }
        public string About { get; set; }
        public string Address { get; set; }
        public int? ProvinceId { get; set; }
        public int? CityId { get; set; }
        public string AreasOfWork { get; set; }
        /*
        USE [NGODb]
        GO
        SET ANSI_NULLS ON
        GO
        SET QUOTED_IDENTIFIER ON
        GO

        CREATE TABLE[dbo].[NGO]
        (
	        [Id] [int] IDENTITY(1,1) NOT NULL,
	        [RegistrationId] [nvarchar](max) NOT NULL,
	        [Name] [nvarchar](100) NULL,
	        [Email] [nvarchar](50) NULL,
	        [RegistrationNumber] [nvarchar](100) NULL,    
            [RegistrationDate] [datetime] NULL,            
            [About] [nvarchar](max) NULL,
	        [Address] [nvarchar](500) NULL,
	        [ProvinceId] [int] NULL,
	        [CityId] [int] NULL,
	        [AreasOfWork] [nvarchar](50) NULL
        ) ON[PRIMARY]
        GO
         */
    }
}
