namespace AfterSale.Domain.Entites.Actions
{
    public class Actions
    {
        public bool success { get; set; }
        public Action[] data { get; set; }
    }

    public class Action
    {
        public int id { get; set; }
        public string name { get; set; }
        public string description { get; set; }
    }
}
