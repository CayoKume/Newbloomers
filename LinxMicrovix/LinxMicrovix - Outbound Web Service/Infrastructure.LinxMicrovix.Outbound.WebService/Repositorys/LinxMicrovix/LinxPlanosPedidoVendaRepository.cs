using Domain.LinxMicrovix.Outbound.WebService.Entites.Parameters;
using Domain.LinxMicrovix.Outbound.WebService.Interfaces.Repositorys.LinxMicrovix;

namespace Domain.LinxMicrovix.Outbound.WebService.Entites.LinxMicrovix
{
    public class LinxPlanosPedidoVendaRepository : ILinxPlanosPedidoVendaRepository
    {
        public LinxPlanosPedidoVendaRepository()
        {
            
        }

        public bool BulkInsertIntoTableRaw(LinxAPIParam jobParameter, IList<LinxPlanosPedidoVenda> records)
        {
            throw new NotImplementedException();
        }

        public Task<List<LinxPlanosPedidoVenda>> GetRegistersExists(LinxAPIParam jobParameter, List<LinxPlanosPedidoVenda> registros)
        {
            throw new NotImplementedException();
        }

        public Task<bool> InsertRecord(LinxAPIParam jobParameter, LinxPlanosPedidoVenda? record)
        {
            throw new NotImplementedException();
        }
    }
}
