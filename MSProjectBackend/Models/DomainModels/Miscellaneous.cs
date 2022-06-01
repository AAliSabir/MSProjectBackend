namespace MSProjectBackend.Models.DomainModels
{
    public class City : BaseEntity
    {
        public int Id { get; set; }
        public int ProvinceId { get; set; }
        public string Name { get; set; }
    }

    public class Province : BaseEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
    
    public class Category : BaseEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }

    public class Skill : BaseEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }

    public class Availability : BaseEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }

    /*
        USE [NGODb]
        GO
        SET ANSI_NULLS ON
        GO
        SET QUOTED_IDENTIFIER ON
        GO
        CREATE TABLE[dbo].[Availability]
        (
            [Id] [int] IDENTITY(1,1) NOT NULL,
            [Name] [nvarchar](max) NOT NULL
        ) ON[PRIMARY]
        GO
    */
}
