namespace Application.LinxCommerce.Interfaces.Sales
{
    public interface IPaymentTermService
    {
        public Task<string?> SearchPaymentTerm();
    }
}
