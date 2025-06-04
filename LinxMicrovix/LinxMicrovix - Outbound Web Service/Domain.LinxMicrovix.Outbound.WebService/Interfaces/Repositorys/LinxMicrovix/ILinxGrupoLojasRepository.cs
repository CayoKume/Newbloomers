using Domain.LinxMicrovix.Outbound.WebService.Entities.LinxMicrovix;
using Domain.LinxMicrovix.Outbound.WebService.Entities.Parameters;

namespace Domain.LinxMicrovix.Outbound.WebService.Interfaces.Repositorys.LinxMicrovix
{
    public interface ILinxGrupoLojasRepository
    {
        public Task<bool> InsertRecord(LinxAPIParam jobParameter, LinxGrupoLojas? record);
        public bool BulkInsertIntoTableRaw(LinxAPIParam jobParameter, IList<LinxGrupoLojas> records);
        public Task<List<string?>> GetRegistersExists();
    }
}
