using Domain.LinxMicrovix.Outbound.WebService.Entities.LinxMicrovix;
using Domain.LinxMicrovix.Outbound.WebService.Entities.Parameters;

namespace Domain.LinxMicrovix.Outbound.WebService.Interfaces.Repositorys.LinxMicrovix
{
    public interface ILinxListagemBalancoRepository
    {
        public Task<bool> InsertRecord(LinxAPIParam jobParameter, LinxListagemBalanco? record);
        public bool BulkInsertIntoTableRaw(LinxAPIParam jobParameter, IList<LinxListagemBalanco> records);
        public Task<List<LinxListagemBalanco>> GetRegistersExists(LinxAPIParam jobParameter, List<LinxListagemBalanco> registros);
    }
}
