namespace Domain.LinxCommerce.Entities.Order
{
    public class OrderTag
    {
        public Int32? TagID { get; set; }
        public string? Alias { get; set; }
        public string? Name { get; set; }
        public bool? IsSystem { get; set; }
        public bool? IsDeleted { get; set; }
        public Guid? OrderID { get; set; }
    }
}
