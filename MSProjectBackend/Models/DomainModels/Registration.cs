namespace MSProjectBackend.Models.DomainModels
{
    public class Registration : BaseEntity
    {
        public string Id { get; set; }
        public string Password { get; set; }
        public int RegistrationType { get; set; }
    }
}
