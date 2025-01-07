using Domain.LinxMicrovix.Outbound.WebService.Entites.Parameters;
using Domain.LinxMicrovix.Outbound.WebService.Interfaces.Repositorys.LinxMicrovix;

namespace Domain.LinxMicrovix.Outbound.WebService.Entites.LinxMicrovix
{
    public class LinxMovimentoObservacaoCFRepository : ILinxMovimentoObservacaoCFRepository
    {
        public LinxMovimentoObservacaoCFRepository()
        {
            
        }

        public bool BulkInsertIntoTableRaw(LinxAPIParam jobParameter, IList<LinxMovimentoObservacaoCF> records)
        {
            throw new NotImplementedException();
        }

        public Task<List<LinxMovimentoObservacaoCF>> GetRegistersExists(LinxAPIParam jobParameter, List<LinxMovimentoObservacaoCF> registros)
        {
            throw new NotImplementedException();
        }

        public Task<bool> InsertRecord(LinxAPIParam jobParameter, LinxMovimentoObservacaoCF? record)
        {
            throw new NotImplementedException();
        }
    }
}
