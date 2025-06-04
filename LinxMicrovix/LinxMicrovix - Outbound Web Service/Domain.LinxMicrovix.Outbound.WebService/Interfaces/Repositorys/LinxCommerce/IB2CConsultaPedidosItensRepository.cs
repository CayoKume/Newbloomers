using Domain.LinxMicrovix.Outbound.WebService.Entities.LinxCommerce;
using Domain.LinxMicrovix.Outbound.WebService.Entities.Parameters;

namespace Domain.LinxMicrovix.Outbound.WebService.Interfaces.Repositorys.LinxCommerce
{
    public interface IB2CConsultaPedidosItensRepository
    {
        public Task<bool> InsertRecord(LinxAPIParam jobParameter, B2CConsultaPedidosItens? record);
        public bool BulkInsertIntoTableRaw(LinxAPIParam jobParameter, IList<B2CConsultaPedidosItens> records);
        public Task<List<string?>> GetRegistersExists(LinxAPIParam jobParameter, List<Int64?> registros);
    }
}
