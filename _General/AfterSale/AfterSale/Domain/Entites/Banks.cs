namespace AfterSale.Domain.Entites.Banks
{
    public class Banks
    {
        public bool success { get; set; }
        public Bank[] data { get; set; }
    }

    public class Bank
    {
        public int id { get; set; }
        public string? name { get; set; }
        public string? description { get; set; }
    }
}
