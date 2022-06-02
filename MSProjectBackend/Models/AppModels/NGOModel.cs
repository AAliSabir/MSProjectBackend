namespace MSProjectBackend.Models.AppModels
{
    public class NGOModel
    {
        public int Id { get; set; }
        public string RegistrationId { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string RegistrationNumber { get; set; }
        public string RegistrationDate { get; set; }
        public string About { get; set; }
        public string Address { get; set; }
        public int? ProvinceId { get; set; }
        public int? CityId { get; set; }
        public string AreasOfWork { get; set; }
    }
}
