using Domain.LinxMicrovix.Outbound.WebService.Models.LinxMicrovix;
using Domain.LinxMicrovix.Outbound.WebService.Entities.Parameters;

namespace Domain.LinxMicrovix.Outbound.WebService.Interfaces.Repositorys.LinxMicrovix
{
    public interface ILinxPlanosPedidoVendaRepository
    {
        public Task<bool> InsertRecord(LinxAPIParam jobParameter, LinxPlanosPedidoVenda? record);
        public bool BulkInsertIntoTableRaw(LinxAPIParam jobParameter, IList<LinxPlanosPedidoVenda> records);
        public Task<IEnumerable<LinxPlanosPedidoVenda>> GetRegistersExists(LinxAPIParam jobParameter, List<LinxPlanosPedidoVenda> registros);
    }
}
