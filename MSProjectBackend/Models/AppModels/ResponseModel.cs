namespace MSProjectBackend.Models.AppModels
{
    public class ResponseModel
    {
        public string Status { get; set; }
        public string Message { get; set; }
        public dynamic OtherInformation { get; set; }
    }
}
