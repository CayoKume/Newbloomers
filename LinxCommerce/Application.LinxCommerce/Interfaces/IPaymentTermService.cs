namespace Application.LinxCommerce.Interfaces
{
    public interface IPaymentTermService
    {
        public Task<string?> SearchPaymentTerm();
    }
}
