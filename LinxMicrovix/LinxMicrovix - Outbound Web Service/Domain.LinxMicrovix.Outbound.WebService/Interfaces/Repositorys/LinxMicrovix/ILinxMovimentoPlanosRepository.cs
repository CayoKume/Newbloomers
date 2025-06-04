using Domain.LinxMicrovix.Outbound.WebService.Entities.LinxMicrovix;
using Domain.LinxMicrovix.Outbound.WebService.Entities.Parameters;

namespace Domain.LinxMicrovix.Outbound.WebService.Interfaces.Repositorys.LinxMicrovix
{
    public interface ILinxMovimentoPlanosRepository
    {
        public Task<bool> InsertRecord(LinxAPIParam jobParameter, LinxMovimentoPlanos? record);
        public bool BulkInsertIntoTableRaw(LinxAPIParam jobParameter, IList<LinxMovimentoPlanos> records);
        public Task<List<string?>> GetRegistersExists(LinxAPIParam jobParameter, List<LinxMovimentoPlanos> registros);
    }
}
