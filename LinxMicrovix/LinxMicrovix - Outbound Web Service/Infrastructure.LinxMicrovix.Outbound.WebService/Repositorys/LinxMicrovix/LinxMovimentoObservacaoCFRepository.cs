using Domain.LinxMicrovix.Outbound.WebService.Entities.Parameters;
using Domain.LinxMicrovix.Outbound.WebService.Interfaces.Repositorys.LinxMicrovix;
using Domain.LinxMicrovix.Outbound.WebService.Entities.LinxMicrovix;

namespace Infrastructure.LinxMicrovix.Outbound.WebService.Repository.LinxMicrovix
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

        public Task<IEnumerable<LinxMovimentoObservacaoCF>> GetRegistersExists(LinxAPIParam jobParameter, List<LinxMovimentoObservacaoCF> registros)
        {
            throw new NotImplementedException();
        }

        public Task<bool> InsertRecord(LinxAPIParam jobParameter, LinxMovimentoObservacaoCF? record)
        {
            throw new NotImplementedException();
        }
    }
}
