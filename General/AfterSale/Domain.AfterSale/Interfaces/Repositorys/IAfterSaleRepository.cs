using Domain.AfterSale.Entites.Company;
using Domain.AfterSale.Entities;

namespace Domain.AfterSale.Interfaces.Repositorys;

public interface IAfterSaleRepository
{
    /*Select in Database*/
    public Task<IEnumerable<Company>> GetCompanys();
    public Task<Company> GetCompany(string cnpj_emp);

    /*Insert in Database*/
    public Task<bool> InsertIntoAfterSaleReversesStatus(List<Status> data);
    public Task<bool> InsertIntoAfterSaleReverses();
    public Task<bool> InsertIntoAfterSaleReversesTransportations();
    public Task<bool> InsertIntoAfterSaleReversesCourierAttributes();

    public Task<bool> InsertIntoAfterSaleRefundsStatus();
    public Task<bool> InsertIntoAfterSaleRefundsActions();
    public Task<bool> InsertIntoAfterSaleRefundsBanks();
    public Task<bool> InsertIntoAfterSaleRefundsTypes();
    public Task<bool> InsertIntoAfterSaleRefunds();
}
