namespace Domain.LinxCommerce.Entities.SalesRepresentative
{
    public class SalesRepresentativeComission
    {
        public int? SalesRepresentativeID { get; set; }
        public decimal? TotalCommission { get; set; }
        public decimal? DeliveryCommission { get; set; }

        public static bool operator ==(SalesRepresentativeComission a, SalesRepresentativeComission b)
        {
            if (a is not null && b is not null)
                return a.TotalCommission.Equals(b.TotalCommission) && a.DeliveryCommission.Equals(b.DeliveryCommission);
            else if (a is null && b is null)
                return true;
            
            return false;
        }

        public static bool operator !=(SalesRepresentativeComission a, SalesRepresentativeComission b)
        {
            return !(a == b);
        }
    }
}
