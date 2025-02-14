namespace Domain.LinxCommerce.Entities.SalesRepresentative
{
    public class SalesRepresentativeMaxDiscount
    {
        public string? Type { get; set; }
        public decimal? Amount { get; set; }
        public int? SalesRepresentativeID { get; set; }

        public static bool operator ==(SalesRepresentativeMaxDiscount a, SalesRepresentativeMaxDiscount b)
        {
            if (a is not null && b is not null)
                return a.Type == b.Type && a.Amount.Equals(b.Amount);
            else if (a is null && b is null)
                return true;

            return false;
        }

        public static bool operator !=(SalesRepresentativeMaxDiscount a, SalesRepresentativeMaxDiscount b)
        {
            return !(a == b);
        }
    }
}
