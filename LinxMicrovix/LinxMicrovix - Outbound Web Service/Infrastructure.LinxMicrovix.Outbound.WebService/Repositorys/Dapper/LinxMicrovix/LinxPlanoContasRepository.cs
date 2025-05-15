using Domain.LinxMicrovix.Outbound.WebService.Entites.Parameters;
using Domain.LinxMicrovix.Outbound.WebService.Interfaces.Repositorys.LinxMicrovix;
using Domain.LinxMicrovix.Outbound.WebService.Entites.LinxMicrovix;

namespace Infrastructure.LinxMicrovix.Outbound.WebService.Repository.Dapper.LinxMicrovix
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
