namespace Domain.LinxCommerce.Entities.Customer
{
    public class EmailConfirmation
    {
        public Int32? CustomerID { get; set; }

        public string? Status { get; set; }

        public DateTime? ConfirmationDate { get; set; }

        public EmailConfirmation() { }

        public EmailConfirmation(EmailConfirmation emailConfirmation, Int32? customerID)
        {
            this.Status = emailConfirmation.Status;
            this.ConfirmationDate = emailConfirmation.ConfirmationDate;
            this.CustomerID = customerID;
        }
    }
}
