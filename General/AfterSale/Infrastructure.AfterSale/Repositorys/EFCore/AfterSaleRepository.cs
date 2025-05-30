using Domain.AfterSale.Entities;
using Domain.AfterSale.Interfaces.Repositorys;
using Infrastructure.AfterSale.Data;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.AfterSale.Repositorys.EFCore
{
    public class AfterSaleRepository : IAfterSaleRepository
    {
        private readonly AfterSaleTreatedDbContext _context;

        public AfterSaleRepository(AfterSaleTreatedDbContext context) =>
            _context = context;

        public async Task<Company?> GetCompany(string cnpj_emp)
        {
            try
            {
                var result = await _context
                    .Set<Parameters>()
                    .FirstOrDefaultAsync(x => x.doc_company == cnpj_emp);

                return new Company
                {
                    doc_company = result?.doc_company,
                    Token = result?.Token
                };
            }
            catch
            {
                throw;
            }
        }

        public async Task<IEnumerable<Company>> GetCompanys()
        {
            try
            {
                var result = await _context.Set<Parameters>().ToListAsync();

                var list = new List<Company>();

                foreach (var company in result)
                {
                    list.Add(new Company
                    {
                        doc_company = company.doc_company,
                        Token = company.Token
                    });
                }

                return list;
            }
            catch
            {
                throw;
            }
        }

        public async Task<bool> InsertIntoAfterSaleEcommerce(List<Ecommerce> data)
        {
            try
            {
                _context.AddRange(data);
                await _context.SaveChangesAsync();
                return true;
            }
            catch
            {
                throw;
            }
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

        public async Task<bool> InsertIntoAfterSaleReverses(List<Domain.AfterSale.Entities.Data> data)
        {
            try
            {
                _context.AddRange(data);
                await _context.SaveChangesAsync();
                return true;
            }
            catch
            {
                throw;
            }
        }

        public Task<bool> InsertIntoAfterSaleReversesCourierAttributes()
        {
            throw new NotImplementedException();
        }

        public async Task<bool> InsertIntoAfterSaleStatus(List<Status> data)
        {
            try
            {
                _context.AddRange(data);
                await _context.SaveChangesAsync();
                return true;
            }
            catch
            {
                throw;
            }
        }

        public async Task<bool> InsertIntoAfterSaleTransportations(Transportations transportations)
        {
            try
            {
                _context.AddRange(transportations);
                await _context.SaveChangesAsync();
                return true;
            }
            catch
            {
                throw;
            }
        }

        public async Task<bool> InsertIntoAfterSaleTransportations(List<Transportations> transportations)
        {
            try
            {
                _context.AddRange(transportations);
                await _context.SaveChangesAsync();
                return true;
            }
            catch
            {
                throw;
            }
        }
    }
}
