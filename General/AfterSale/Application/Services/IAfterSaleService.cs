namespace AfterSale;

public interface IAfterSaleService
{
    /* Me - Infos about your ecommerce */
    public Task<string> GetMe();

    /* Reverses - operations available to reverses */
    public Task<string> GetReversesStatus();
    public Task<string> GetReversesTransportations();
    public Task<string> GetReverses();
    public Task<string> GetReversesById(Int64 id);
    public Task<string> GetReversesCourierAttributes();
    public Task<string> ApproveReverseById(Int64 id);
    public Task<string> ReciveProductsById(Int64 id);
    public Task<string> ReturnedInvoiceById(Int64 id);
    public Task<string> ReversesInvoiceById(Int64 id);

    /* Refunds - operations available to refunds */
    public Task<string> GetRefundsStatus();
    public Task<string> GetRefundsActions();
    public Task<string> GetRefundsBanks();
    public Task<string> GetRefundsTypes();
    public Task<string> GetRefunds();
    public Task<string> GetRefundsById(Int64 id);
    public Task<string> ApproveRefundById(Int64 id);
    public Task<string> CancelRefundById(Int64 id);
    public Task<string> PayRefundById(Int64 id);
    public Task<string> ChangeTotalAmountRefundById(Int64 id);
}
