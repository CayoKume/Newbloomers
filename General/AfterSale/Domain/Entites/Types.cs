namespace AfterSale.Domain.Entites.Types
{
    public class Types
    {
        public bool success { get; set; }
        public Type[] data { get; set; }
    }

    public class Type
    {
        public string name { get; set; }
        public string description { get; set; }
    }
}
