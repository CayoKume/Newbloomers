using Domain.LinxMicrovix.Outbound.WebService.Entities.Parameters;
using Domain.LinxMicrovix.Outbound.WebService.Interfaces.Repositorys.LinxMicrovix;
using Domain.LinxMicrovix.Outbound.WebService.Entities.LinxMicrovix;

namespace Infrastructure.LinxMicrovix.Outbound.WebService.Repository.LinxMicrovix
{
    public class LinxCupomDescontoVendasRepository : ILinxCupomDescontoVendasRepository
    {
        public LinxCupomDescontoVendasRepository()
        {

        }

        public bool BulkInsertIntoTableRaw(LinxAPIParam jobParameter, IList<LinxCupomDescontoVendas> records)
        {
            throw new NotImplementedException();
        }

        public Task<List<LinxCupomDescontoVendas>> GetRegistersExists(LinxAPIParam jobParameter, List<LinxCupomDescontoVendas> registros)
        {
            throw new NotImplementedException();
        }

        public Task<bool> InsertRecord(LinxAPIParam jobParameter, LinxCupomDescontoVendas? record)
        {
            throw new NotImplementedException();
        }
    }
}
