using Domain.LinxMicrovix.Outbound.WebService.Entities.LinxMicrovix;
using Domain.LinxMicrovix.Outbound.WebService.Entities.Parameters;

namespace Domain.LinxMicrovix.Outbound.WebService.Interfaces.Repositorys.LinxMicrovix
{
    public interface ILinxOrdensServicoRepository
    {
        public Task<bool> InsertRecord(LinxAPIParam jobParameter, LinxOrdensServico? record);
        public bool BulkInsertIntoTableRaw(LinxAPIParam jobParameter, IList<LinxOrdensServico> records);
        public Task<List<LinxOrdensServico>> GetRegistersExists(LinxAPIParam jobParameter, List<LinxOrdensServico> registros);
    }
}
