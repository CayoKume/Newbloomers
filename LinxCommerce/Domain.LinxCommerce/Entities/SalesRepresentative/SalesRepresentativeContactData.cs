namespace Domain.LinxCommerce.Entities.SalesRepresentative
{
    public class SalesRepresentativeContactData
    {
        public int? SalesRepresentativeID { get; set; }
        public string? Email { get; set; }
        public string? Phone { get; set; }
        public string? CellPhone { get; set; }

        public static bool operator ==(SalesRepresentativeContactData a, SalesRepresentativeContactData b)
        {
            if (a is not null && b is not null)
                return a.Email == b.Email && a.Phone == b.Phone && a.CellPhone == b.CellPhone;
            else if (a is null && b is null)
                return true;

            return false;
        }

        public static bool operator !=(SalesRepresentativeContactData a, SalesRepresentativeContactData b)
        {
            return !(a == b);
        }
    }
}
