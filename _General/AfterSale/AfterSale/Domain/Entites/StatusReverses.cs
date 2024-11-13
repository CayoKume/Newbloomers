namespace AfterSale.Domain.Entites.StatusReverses
{
    public class StatusReverses
    {
        public bool success { get; set; }
        public StatusReverse[] data { get; set; }
    }

    public class StatusReverse
    {
        public int id { get; set; }
        public string? name { get; set; }
        public string? description { get; set; }
    }
}
