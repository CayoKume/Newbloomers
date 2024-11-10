
using System.Threading.Channels;

namespace AfterSale;

public class AfterSaleService : IAfterSaleService
{
    private readonly IAPICall _apiCall;
    private readonly IAfterSaleRepository _afterSaleRepository;

    public AfterSaleService(IAPICall apiCall, IAfterSaleRepository afterSaleRepository) =>
        (_apiCall, _afterSaleRepository) = (apiCall, afterSaleRepository);

    #region Me - Infos about your ecommerce
    /// <summary>
    /// return infos about ecommerce
    /// </summary>
    public Task<string?> GetMe()
    {
        throw new NotImplementedException();
    }
    #endregion

    #region Refunds - Operations available to refunds
    /// <summary>
    /// returns all refunds
    /// </summary>
    public Task<string?> GetRefunds()
    {
        throw new NotImplementedException();
    }

    /// <summary>
    /// returns the possible actions of a reverse
    /// </summary>
    public Task<string?> GetRefundsActions()
    {
        throw new NotImplementedException();
    }

    /// <summary>
    /// returns the possible banks of a refund
    /// </summary>
    public Task<string?> GetRefundsBanks()
    {
        throw new NotImplementedException();
    }

    /// <summary>
    /// get a refund
    /// </summary>
    public Task<string?> GetRefundsById(Int64 id)
    {
        throw new NotImplementedException();
    }

    /// <summary>
    /// returns the possible status of a refund
    /// </summary>
    public Task<string?> GetRefundsStatus()
    {
        throw new NotImplementedException();
    }

    /// <summary>
    /// returns the possible types of a refund
    /// </summary>
    public Task<string?> GetRefundsTypes()
    {
        throw new NotImplementedException();
    }

    /// <summary>
    /// cancel reverse
    /// </summary>
    public Task<string?> CancelRefundById(Int64 id)
    {
        throw new NotImplementedException();
    }

    /// <summary>
    /// change total amount of refund
    /// </summary>
    public Task<string?> ChangeTotalAmountRefundById(Int64 id)
    {
        throw new NotImplementedException();
    }

    /// <summary>
    /// pay refund
    /// </summary>
    public Task<string?> PayRefundById(Int64 id)
    {
        throw new NotImplementedException();
    }

    /// <summary>
    /// approve reverse
    /// </summary>
    /// <param name="id"></param>
    public Task<string?> ApproveRefundById(Int64 id)
    {
        throw new NotImplementedException();
    }
    #endregion

    #region Reverses - Operations available to reverses
    /// <summary>
    /// returns all reverses
    /// </summary>
    public Task<string?> GetReverses()
    {
        throw new NotImplementedException();
    }

    /// <summary>
    /// get a reverse
    /// </summary>
    /// <param name="id"></param>
    public Task<string?> GetReversesById(Int64 id)
    {
        throw new NotImplementedException();
    }

    /// <summary>
    /// get courier data fields needed to process the reverse
    /// </summary>
    public Task<string?> GetReversesCourierAttributes()
    {
        throw new NotImplementedException();
    }

    /// <summary>
    /// returns the possible status of a reverse
    /// </summary>
    public Task<string?> GetReversesStatus()
    {
        throw new NotImplementedException();
    }

    /// <summary>
    /// returns the possible transportations
    /// </summary>
    public Task<string?> GetReversesTransportations()
    {
        throw new NotImplementedException();
    }

    /// <summary>
    /// receive products by reverse ID
    /// </summary>
    /// <param name="id"></param>
    public Task<string?> ReciveProductsById(Int64 id)
    {
        throw new NotImplementedException();
    }

    /// <summary>
    /// update recived invoice in reverse products. Need pass the products id and the returned invoice
    /// </summary>
    /// <param name="id"></param>
    public Task<string?> ReturnedInvoiceById(Int64 id)
    {
        throw new NotImplementedException();
    }

    /// <summary>
    /// set reverse courier data and process/generate code
    /// </summary>
    /// <param name="id"></param>
    public Task<string?> ReversesInvoiceById(Int64 id)
    {
        throw new NotImplementedException();
    }

    /// <summary>
    /// approve products by reverse ID
    /// </summary>
    /// <param name="id"></param>
    public Task<string?> ApproveReverseById(Int64 id)
    {
        throw new NotImplementedException();
    } 
    #endregion
}
