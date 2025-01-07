using Domain.LinxMicrovix.Outbound.WebService.Entites.Parameters;
using Domain.LinxMicrovix.Outbound.WebService.Interfaces.Repositorys.LinxMicrovix;

namespace Domain.LinxMicrovix.Outbound.WebService.Entites.LinxMicrovix
{
    public class LinxGrupoLojasRepository : ILinxGrupoLojasRepository
    {
        public LinxGrupoLojasRepository()
        {
            
        }

        public bool BulkInsertIntoTableRaw(LinxAPIParam jobParameter, IList<LinxGrupoLojas> records)
        {
            throw new NotImplementedException();
        }

        public Task<List<LinxGrupoLojas>> GetRegistersExists(LinxAPIParam jobParameter, List<LinxGrupoLojas> registros)
        {
            throw new NotImplementedException();
        }

        public Task<bool> InsertRecord(LinxAPIParam jobParameter, LinxGrupoLojas? record)
        {
            throw new NotImplementedException();
        }
    }
}