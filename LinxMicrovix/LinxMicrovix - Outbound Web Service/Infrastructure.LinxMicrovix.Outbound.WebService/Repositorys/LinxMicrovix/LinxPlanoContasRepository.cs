using Domain.LinxMicrovix.Outbound.WebService.Entites.Parameters;
using Domain.LinxMicrovix.Outbound.WebService.Interfaces.Repositorys.LinxMicrovix;

namespace Domain.LinxMicrovix.Outbound.WebService.Entites.LinxMicrovix
{
    public class LinxPlanoContasRepository : ILinxPlanoContasRepository
    {
        public LinxPlanoContasRepository()
        {
            
        }

        public bool BulkInsertIntoTableRaw(LinxAPIParam jobParameter, IList<LinxPlanoContas> records)
        {
            throw new NotImplementedException();
        }

        public Task<List<LinxPlanoContas>> GetRegistersExists(LinxAPIParam jobParameter, List<LinxPlanoContas> registros)
        {
            throw new NotImplementedException();
        }

        public Task<bool> InsertRecord(LinxAPIParam jobParameter, LinxPlanoContas? record)
        {
            throw new NotImplementedException();
        }
    }
}
