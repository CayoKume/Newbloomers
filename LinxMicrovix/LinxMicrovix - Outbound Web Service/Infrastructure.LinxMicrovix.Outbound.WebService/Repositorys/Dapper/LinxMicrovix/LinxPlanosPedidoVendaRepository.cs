using Domain.LinxMicrovix.Outbound.WebService.Entites.Parameters;
using Domain.LinxMicrovix.Outbound.WebService.Interfaces.Repositorys.LinxMicrovix;
using Domain.LinxMicrovix.Outbound.WebService.Entites.LinxMicrovix;

namespace Infrastructure.LinxMicrovix.Outbound.WebService.Repository.Dapper.LinxMicrovix
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
