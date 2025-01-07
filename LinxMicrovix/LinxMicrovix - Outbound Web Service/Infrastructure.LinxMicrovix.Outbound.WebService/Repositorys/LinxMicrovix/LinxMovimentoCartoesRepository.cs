using Domain.LinxMicrovix.Outbound.WebService.Entites.Parameters;
using Domain.LinxMicrovix.Outbound.WebService.Interfaces.Repositorys.LinxMicrovix;

namespace Domain.LinxMicrovix.Outbound.WebService.Entites.LinxMicrovix
{
    public class LinxMovimentoCartoesRepository : ILinxMovimentoCartoesRepository
    {
        public LinxMovimentoCartoesRepository()
        {
            
        }

        public bool BulkInsertIntoTableRaw(LinxAPIParam jobParameter, IList<LinxMovimentoCartoes> records)
        {
            throw new NotImplementedException();
        }

        public Task<List<LinxMovimentoCartoes>> GetRegistersExists(LinxAPIParam jobParameter, List<LinxMovimentoCartoes> registros)
        {
            throw new NotImplementedException();
        }

        public Task<bool> InsertRecord(LinxAPIParam jobParameter, LinxMovimentoCartoes? record)
        {
            throw new NotImplementedException();
        }
    }
}
