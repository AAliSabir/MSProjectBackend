namespace MSProjectBackend.Models.AppModels
{
    public class CityModel
    {
        public int Id { get; set; }
        public int ProvinceId { get; set; }
        public string Name { get; set; }
    }

    public class ProvinceModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }

    public class CategoryModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }

    public class SkillModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }

    public class AvailabilityModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
}
