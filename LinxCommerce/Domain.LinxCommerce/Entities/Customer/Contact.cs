using Domain.LinxCommerce.Entities.SalesRepresentative;

namespace Domain.LinxCommerce.Entities.Customer
{
    public class Contact
    {
        public string? Phone { get; set; }
        public string? Phone2 { get; set; }
        public string? CellPhone { get; set; }
        public string? Fax { get; set; }
        public Int32? CustomerID { get; set; }

        public static bool operator ==(Contact a, Contact b)
        {
            if (a is not null && b is not null)
                return a.Phone == b.Phone && a.Phone2 == b.Phone2 && a.CellPhone == b.CellPhone && a.Fax == b.Fax;
            if (a is null && b is null)
                return true;

            return false;
        }

        public static bool operator !=(Contact a, Contact b)
        {
            return !(a == b);
        }
    }
}
