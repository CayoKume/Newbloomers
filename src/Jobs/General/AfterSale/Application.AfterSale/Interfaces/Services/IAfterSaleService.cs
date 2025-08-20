namespace Application.AfterSale.Interfaces.Services
{
    public interface IAfterSaleService
    {
        /* Me - Infos about your ecommerce */
        public Task<bool?> GetMe();

        /* ReverseSimplified - operations available to reverses */
        public Task<bool?> GetReversesStatus();
        public Task<bool?> GetReversesTransportations();
        public Task<bool?> GetReverses();
        public Task<bool?> GetReversesById(long id, string cnpj_emp);
        public Task<bool?> GetReversesCourierAttributes();
        public Task<bool?> ApproveReverseById(long id);
        public Task<bool?> ReciveProductsById(long id);
        public Task<bool?> ReturnedInvoiceById(long id);
        public Task<bool?> ReversesInvoiceById(long id);

        /* Refunds - operations available to refunds */
        public Task<bool?> GetRefundsStatus();
        public Task<bool?> GetRefundsActions();
        public Task<bool?> GetRefundsBanks();
        public Task<bool?> GetRefundsTypes();
        public Task<bool?> GetRefunds();
        public Task<bool?> GetRefundsById(long id);
        public Task<bool?> ApproveRefundById(long id);
        public Task<bool?> CancelRefundById(long id);
        public Task<bool?> PayRefundById(long id);
        public Task<bool?> ChangeTotalAmountRefundById(long id);
    }
}
