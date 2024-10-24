using AfterSale.Domain.Entites.Company;
using AfterSale.Domain.Entites.Parameters;

namespace AfterSale;

public interface IAfterSaleRepository
{
    /*Set Database Tables*/
    public Task<bool> CreateTableAfterSaleParameters();

    public Task<bool> CreateTableAfterSaleReversesStatus();
    public Task<bool> CreateTableAfterSaleReverses();
    public Task<bool> CreateTableAfterSaleReversesTransportations();
    public Task<bool> CreateTableAfterSaleReversesCourierAttributes();

    public Task<bool> CreateTableAfterSaleRefundsStatus();
    public Task<bool> CreateTableAfterSaleRefundsActions();
    public Task<bool> CreateTableAfterSaleRefundsBanks();
    public Task<bool> CreateTableAfterSaleRefundsTypes();
    public Task<bool> CreateTableAfterSaleRefunds();

    /*Select in Database*/
    public Task<Parameters> GetParameters(string doc_company);
    public Task<IEnumerable<Company>> GetCompanys();

    /*Insert in Database*/
    public Task<bool> InsertIntoAfterSaleReversesStatus();
    public Task<bool> InsertIntoAfterSaleReverses();
    public Task<bool> InsertIntoAfterSaleReversesTransportations();
    public Task<bool> InsertIntoAfterSaleReversesCourierAttributes();

    public Task<bool> InsertIntoAfterSaleRefundsStatus();
    public Task<bool> InsertIntoAfterSaleRefundsActions();
    public Task<bool> InsertIntoAfterSaleRefundsBanks();
    public Task<bool> InsertIntoAfterSaleRefundsTypes();
    public Task<bool> InsertIntoAfterSaleRefunds();
}
