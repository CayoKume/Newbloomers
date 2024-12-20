using Domain.LinxMicrovix.Outbound.WebService.Entites.LinxMicrovix;
using Domain.LinxMicrovix.Outbound.WebService.Entites.Parameters;

namespace Domain.LinxMicrovix.Outbound.WebService.Interfaces.Repositorys.LinxMicrovix
{
    public interface ILinxTrocaUnificadaResumoVendasItensRepository
    {
        public Task<bool> InsertRecord(LinxAPIParam jobParameter, LinxTrocaUnificadaResumoVendasItens? record);
        public bool BulkInsertIntoTableRaw(LinxAPIParam jobParameter, IList<LinxTrocaUnificadaResumoVendasItens> records);
        public Task<List<LinxTrocaUnificadaResumoVendasItens>> GetRegistersExists(LinxAPIParam jobParameter, List<LinxTrocaUnificadaResumoVendasItens> registros);
    }
}
