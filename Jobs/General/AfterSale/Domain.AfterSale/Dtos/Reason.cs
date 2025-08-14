namespace Domain.AfterSale.Dtos
{
    public class Reason
    {
        public string? id { get; set; }
        public string? ecommerce_id { get; set; }
        public string? description { get; set; }
        public string? reason_category_id { get; set; }
        public string? action { get; set; }
        public string? should_approve { get; set; }
        public string? upload_image { get; set; }
        public string? show_product_grid { get; set; }
        public string? ord { get; set; }
        public string? created_at { get; set; }
        public string? updated_at { get; set; }
        public string? deleted_at { get; set; }
    }
}
