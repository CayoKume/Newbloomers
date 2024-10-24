namespace AfterSale.Domain.Entites.CourierAttributes
{
    public class CourierAttributes
    {
        public bool success { get; set; }
        public CourierAttribute data { get; set; }
    }

    public class CourierAttribute
    {
        public int reverse { get; set; }
        public Fields[] fields { get; set; }
        public Fields fill_form_from_file { get; set; }
    }

    public class Reverse
    {
        public int id { get; set; }
    }

    public class Fields
    {
        public string id { get; set; }
        public string name { get; set; }
        public Validation validation { get; set; }
        public string type { get; set; }
    }

    public class Validation
    {
        public bool required { get; set; }
        public string mime { get; set; }
    }
}
