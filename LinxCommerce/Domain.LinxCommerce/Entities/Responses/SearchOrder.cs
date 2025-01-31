namespace Domain.LinxCommerce.Entities.Responses
{
    public class SearchOrder
    {
        public class Root
        {
            public List<Result> Result { get; set; }
        }

        public class Result
        {
            public string? OrderID { get; set; }
            public string? CustomerID { get; set; }
        }
    }
}
