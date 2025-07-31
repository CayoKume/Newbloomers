using Domain.AfterSale.Entities;

namespace Domain.AfterSale.Interfaces.Repositorys;

public interface IAfterSaleRepository
{
    /*Select in Database*/
    public Task<IEnumerable<Company?>> GetCompanys();
    public Task<Company?> GetCompany(string cnpj_emp);
    public Task<List<Reverse?>> GetReversesByIds(List<int?> reversesIds);

    /*Insert in Database*/
    public Task<bool> InsertIntoAfterSaleEcommerce(List<Ecommerce> data, Guid? parentExecutionGUID);
    public Task<bool> InsertIntoAfterSaleStatus(List<Status> data, Guid? parentExecutionGUID);
    public Task<bool> InsertIntoAfterSaleReverses(List<Data> data, Guid? parentExecutionGUID);
    public Task<bool> InsertIntoAfterSaleTransportations(List<Transportations> transportations, Guid? parentExecutionGUID);
    public Task<bool> InsertIntoAfterSaleTransportations(Transportations transportations, Guid? parentExecutionGUID);
    public Task<bool> InsertIntoAfterSaleReversesCourierAttributes();

    public Task<bool> InsertIntoAfterSaleRefundsStatus();
    public Task<bool> InsertIntoAfterSaleRefundsActions();
    public Task<bool> InsertIntoAfterSaleRefundsBanks();
    public Task<bool> InsertIntoAfterSaleRefundsTypes();
    public Task<bool> InsertIntoAfterSaleRefunds();

    /*Call Proc Merge*/
    //public Task<bool> CallProcMerge();
}
