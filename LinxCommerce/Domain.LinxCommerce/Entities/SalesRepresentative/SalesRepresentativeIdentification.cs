namespace Domain.LinxCommerce.Entities.SalesRepresentative
{
    public class SalesRepresentativeIdentification
    {
        public int? SalesRepresentativeID { get; set; }
        public string? Type { get; set; }
        public string? DocumentNumber { get; set; }

        public static bool operator == (SalesRepresentativeIdentification a, SalesRepresentativeIdentification b)
        {
            if (a is not null && b is not null)
                return a.Type == b.Type && a.DocumentNumber == b.DocumentNumber;
            if (a is null && b is null)
                return true;

            return false;
        }

        public static bool operator != (SalesRepresentativeIdentification a, SalesRepresentativeIdentification b)
        {
            return !(a == b);
        }
    }
}
