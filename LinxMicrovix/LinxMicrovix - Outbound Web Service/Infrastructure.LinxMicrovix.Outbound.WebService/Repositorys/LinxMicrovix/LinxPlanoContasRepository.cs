using Domain.LinxMicrovix.Outbound.WebService.Entities.Parameters;
using Domain.LinxMicrovix.Outbound.WebService.Interfaces.Repositorys.LinxMicrovix;
using Domain.LinxMicrovix.Outbound.WebService.Entities.LinxMicrovix;

namespace Infrastructure.LinxMicrovix.Outbound.WebService.Repository.LinxMicrovix
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

        public Task<IEnumerable<LinxPlanoContas>> GetRegistersExists(LinxAPIParam jobParameter, List<LinxPlanoContas> registros)
        {
            throw new NotImplementedException();
        }

        public Task<bool> InsertRecord(LinxAPIParam jobParameter, LinxPlanoContas? record)
        {
            throw new NotImplementedException();
        }
    }
}
