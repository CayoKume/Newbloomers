using AfterSale.Domain.Entites.Company;
using AfterSale.Domain.Entites.Parameters;

namespace AfterSale;

public class AfterSaleRepository : IAfterSaleRepository
{
    public Task<bool> CreateTableAfterSaleParameters()
    {
        try
        {
            throw new NotImplementedException();
        }
        catch (Exception ex)
        {
            throw new Exception();
        }
    }

    public Task<bool> CreateTableAfterSaleRefunds()
    {
        throw new NotImplementedException();
    }

    public Task<bool> CreateTableAfterSaleRefundsActions()
    {
        throw new NotImplementedException();
    }

    public Task<bool> CreateTableAfterSaleRefundsBanks()
    {
        throw new NotImplementedException();
    }

    public Task<bool> CreateTableAfterSaleRefundsStatus()
    {
        throw new NotImplementedException();
    }

    public Task<bool> CreateTableAfterSaleRefundsTypes()
    {
        throw new NotImplementedException();
    }

    public Task<bool> CreateTableAfterSaleReverses()
    {
        throw new NotImplementedException();
    }

    public Task<bool> CreateTableAfterSaleReversesCourierAttributes()
    {
        throw new NotImplementedException();
    }

    public Task<bool> CreateTableAfterSaleReversesStatus()
    {
        throw new NotImplementedException();
    }

    public Task<bool> CreateTableAfterSaleReversesTransportations()
    {
        throw new NotImplementedException();
    }

    public Task<IEnumerable<Company>> GetCompanys()
    {
        throw new NotImplementedException();
    }

    public Task<Parameters> GetParameters(string? doc_company)
    {
        throw new NotImplementedException();
    }

    public Task<bool> InsertIntoAfterSaleRefunds()
    {
        throw new NotImplementedException();
    }

    public Task<bool> InsertIntoAfterSaleRefundsActions()
    {
        throw new NotImplementedException();
    }

    public Task<bool> InsertIntoAfterSaleRefundsBanks()
    {
        throw new NotImplementedException();
    }

    public Task<bool> InsertIntoAfterSaleRefundsStatus()
    {
        throw new NotImplementedException();
    }

    public Task<bool> InsertIntoAfterSaleRefundsTypes()
    {
        throw new NotImplementedException();
    }

    public Task<bool> InsertIntoAfterSaleReverses()
    {
        throw new NotImplementedException();
    }

    public Task<bool> InsertIntoAfterSaleReversesCourierAttributes()
    {
        throw new NotImplementedException();
    }

    public Task<bool> InsertIntoAfterSaleReversesStatus()
    {
        throw new NotImplementedException();
    }

    public Task<bool> InsertIntoAfterSaleReversesTransportations()
    {
        throw new NotImplementedException();
    }
}
