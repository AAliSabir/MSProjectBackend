namespace MSProjectBackend.Models.DomainModels
{
    public class Project : BaseEntity
    {
        public int Id { get; set; }
        public int NGOId { get; set; }
        public string Name { get; set; }
        public string About { get; set; }
        public int? ProvinceId { get; set; }
        public int? CityId { get; set; }
        public int? CategoryId { get; set; }
        public bool? IsSubproject { get; set; }
        public int? ParentProjectId { get; set; }
        public bool? IsActive { get; set; }

        /*
        USE [NGODb]
        GO
        SET ANSI_NULLS ON
        GO
        SET QUOTED_IDENTIFIER ON
        GO

        CREATE TABLE[dbo].[Project]
        (
            [Id] [int] IDENTITY(1,1) NOT NULL,
            [NGOId] [int] NOT NULL,
            [Name] [nvarchar](100) NULL,
            [About] [nvarchar](max) NULL,
            [ProvinceId] [int] NULL,
            [CityId] [int] NULL,
            [CategoryId] [int] NULL,
            [IsSubproject] [bit] NULL,
            [ParentProjectId] [int] NULL,
            [IsActive] [bit] NULL
        ) ON[PRIMARY]
        GO
         */

    }
}
