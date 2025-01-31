using Domain.LinxCommerce.Entities.Parameters;
using Domain.LinxCommerce.Interfaces.Repositorys.Base;
using Domain.LinxCommerce.Interfaces.Repositorys.SalesRepresentative;

namespace Infrastructure.LinxCommerce.Repositorys.SalesRepresentative
{
    public class SalesRepresentativeRepository : ISalesRepresentativeRepository
    {
        private readonly ILinxCommerceRepositoryBase _linxCommerceRepositoryBase;

        public SalesRepresentativeRepository(ILinxCommerceRepositoryBase linxCommerceRepositoryBase) =>
            _linxCommerceRepositoryBase = linxCommerceRepositoryBase;

        public bool BulkInsertIntoTableRaw(LinxCommerceJobParameter jobParameter, List<Domain.LinxCommerce.Entities.SalesRepresentative.SalesRepresentative> records)
        {
            try
            {
                var salesRepresentativeTable = _linxCommerceRepositoryBase.CreateSystemDataTable(jobParameter, new Domain.LinxCommerce.Entities.SalesRepresentative.SalesRepresentative());

                for (int i = 0; i < records.Count(); i++)
                {
                    salesRepresentativeTable.Rows.Add(records[i].SalesRepresentativeID);
                }

                _linxCommerceRepositoryBase.BulkInsertIntoTableRaw(
                    jobParameter: jobParameter,
                    dataTable: table,
                    dataTableRowsNumber: table.Rows.Count
                );

                return true;
            }
            catch
            {
                throw;
            }
        }

        public Task<List<Domain.LinxCommerce.Entities.SalesRepresentative.SalesRepresentative>> GetRegistersExists(List<string> ordersIds)
        {
            throw new NotImplementedException();
        }
    }
}
