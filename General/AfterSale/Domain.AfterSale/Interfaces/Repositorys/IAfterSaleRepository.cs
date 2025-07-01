using Domain.AfterSale.Entities;

namespace Domain.AfterSale.Interfaces.Repositorys;

public interface IAfterSaleRepository
{
    /*Select in Database*/
    public Task<IEnumerable<Company>> GetCompanys();
    public Task<Company> GetCompany(string cnpj_emp);

    /*Insert in Database*/
    public bool InsertIntoAfterSaleEcommerce(List<Ecommerce> data);
    public bool InsertIntoAfterSaleStatus(List<Status> data);
    public bool InsertIntoAfterSaleReverses(List<Data> data);
    public bool InsertIntoAfterSaleTransportations(List<Transportations> transportations);
    public bool InsertIntoAfterSaleTransportations(Transportations transportations);
    public bool InsertIntoAfterSaleReversesCourierAttributes();

    public bool InsertIntoAfterSaleRefundsStatus();
    public bool InsertIntoAfterSaleRefundsActions();
    public bool InsertIntoAfterSaleRefundsBanks();
    public bool InsertIntoAfterSaleRefundsTypes();
    public bool InsertIntoAfterSaleRefunds();

    /*Call Proc Merge*/
    //public Task<bool> CallProcMerge();
}
