namespace Domain.LinxCommerce.Entities.Responses
{
    public class SearchOrderStatus
    {
        public class Root
        {
            public List<Result> Result { get; set; }
        }

        public class Result
        {
            public int? OrderStatusID { get; set; }
            public string? Status { get; set; }
            public string? Color { get; set; }
            public bool? IsDefault { get; set; }
            public string? IntegrationID { get; set; }
        }
    }
}
