namespace Application.AfterSale.Interfaces
{
    public interface IAfterSaleService
    {
        /* Me - Infos about your ecommerce */
        public Task<bool?> GetMe();

        /* ReverseSimplified - operations available to reverses */
        public Task<bool?> GetReversesStatus();
        public Task<bool?> GetReversesTransportations();
        public Task<bool?> GetReverses();
        public Task<bool?> GetReversesById(Int64 id, string cnpj_emp);
        public Task<bool?> GetReversesCourierAttributes();
        public Task<bool?> ApproveReverseById(Int64 id);
        public Task<bool?> ReciveProductsById(Int64 id);
        public Task<bool?> ReturnedInvoiceById(Int64 id);
        public Task<bool?> ReversesInvoiceById(Int64 id);

        /* Refunds - operations available to refunds */
        public Task<bool?> GetRefundsStatus();
        public Task<bool?> GetRefundsActions();
        public Task<bool?> GetRefundsBanks();
        public Task<bool?> GetRefundsTypes();
        public Task<bool?> GetRefunds();
        public Task<bool?> GetRefundsById(Int64 id);
        public Task<bool?> ApproveRefundById(Int64 id);
        public Task<bool?> CancelRefundById(Int64 id);
        public Task<bool?> PayRefundById(Int64 id);
        public Task<bool?> ChangeTotalAmountRefundById(Int64 id);
    }
}
