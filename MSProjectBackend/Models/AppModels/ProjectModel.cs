namespace MSProjectBackend.Models.AppModels
{
    public class ProjectModel
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
    }
}
