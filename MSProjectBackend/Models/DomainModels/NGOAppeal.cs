namespace MSProjectBackend.Models.DomainModels
{
    public class NGOAppeal : BaseEntity
    {
        public int Id { get; set; }
        public int NGOId { get; set; }
        public string About { get; set; }
        public int? ProjectId { get; set; }
        public bool? IsVolunteerCall { get; set; }
        public int? VolunteersNeeded { get; set; }
        public bool? IsDonationsCall { get; set; }
        public int? DonationsTarget { get; set; }

        /*
        USE [NGODb]
        GO
        SET ANSI_NULLS ON
        GO
        SET QUOTED_IDENTIFIER ON
        GO

        CREATE TABLE[dbo].[NGOAppeal]
        (
            [Id] [int] IDENTITY(1,1) NOT NULL,
            [NGOId] [int] NOT NULL,
            [About] [nvarchar](max) NULL,
            [ProjectId] [int] NULL,
            [IsVolunteerCall] [bit] NULL,
            [VolunteersNeeded] [int] NULL,
            [IsDonationsCall] [bit] NULL,
            [DonationsTarget] [int] NULL
        ) ON[PRIMARY]
        GO
         */
    }
}
