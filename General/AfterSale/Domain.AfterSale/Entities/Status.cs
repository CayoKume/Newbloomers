namespace Domain.AfterSale.Entities
{
    public class Status
    {
        public int? id { get; set; }
        public string? name { get; set; }
        public string? description { get; set; }
    }

    public class ResponseStatus
    {
        public bool? success { get; set; }
        public List<Status> data { get; set; }
    }
}
