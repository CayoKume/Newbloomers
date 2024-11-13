namespace LinxCommerce.Application.Services.Sales.PaymentTerm
{
    public interface IPaymentTermService
    {
        public Task<string?> SearchPaymentTerm();
    }
}
