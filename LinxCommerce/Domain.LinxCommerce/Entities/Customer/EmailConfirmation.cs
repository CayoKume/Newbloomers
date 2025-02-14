using Domain.LinxCommerce.Entities.SalesRepresentative;

namespace Domain.LinxCommerce.Entities.Customer
{
    public class EmailConfirmation
    {
        public string? CustomerID { get; set; }
        public string? Status { get; set; }
        public DateTime? ConfirmationDate { get; set; }

        public static bool operator ==(EmailConfirmation a, EmailConfirmation b)
        {
            if (a is not null && b is not null)
                return a.Status == b.Status && a.ConfirmationDate == b.ConfirmationDate;
            if (a is null && b is null)
                return true;

            return false;
        }

        public static bool operator !=(EmailConfirmation a, EmailConfirmation b)
        {
            return !(a == b);
        }
    }
}
