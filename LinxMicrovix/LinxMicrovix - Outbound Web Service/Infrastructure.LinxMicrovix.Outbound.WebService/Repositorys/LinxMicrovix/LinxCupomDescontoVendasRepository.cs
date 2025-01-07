using Domain.LinxMicrovix.Outbound.WebService.Entites.Parameters;
using Domain.LinxMicrovix.Outbound.WebService.Interfaces.Repositorys.LinxMicrovix;

namespace Domain.LinxMicrovix.Outbound.WebService.Entites.LinxMicrovix
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
