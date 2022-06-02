namespace MSProjectBackend.Models.AppModels
{
    public class NGOAppealModel
    {
        public int Id { get; set; }
        public int NGOId { get; set; }
        public string About { get; set; }
        public int? ProjectId { get; set; }
        public bool? IsVolunteerCall { get; set; }
        public int? VolunteersNeeded { get; set; }
        public bool? IsDonationsCall { get; set; }
        public int? DonationsTarget { get; set; }
    }
}
