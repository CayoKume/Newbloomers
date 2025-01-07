using Domain.LinxMicrovix.Outbound.WebService.Entites.LinxMicrovix;
using Domain.LinxMicrovix.Outbound.WebService.Entites.Parameters;

namespace Domain.LinxMicrovix.Outbound.WebService.Interfaces.Repositorys.LinxMicrovix
{
    public interface ILinxCupomDescontoVendasRepository
    {
        public Task<bool> InsertRecord(LinxAPIParam jobParameter, LinxCupomDescontoVendas? record);
        public bool BulkInsertIntoTableRaw(LinxAPIParam jobParameter, IList<LinxCupomDescontoVendas> records);
        public Task<List<LinxCupomDescontoVendas>> GetRegistersExists(LinxAPIParam jobParameter, List<LinxCupomDescontoVendas> registros);
    }
}
