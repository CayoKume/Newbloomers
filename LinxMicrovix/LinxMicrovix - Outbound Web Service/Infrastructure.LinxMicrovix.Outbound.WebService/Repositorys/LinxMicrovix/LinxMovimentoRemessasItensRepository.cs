using Domain.LinxMicrovix.Outbound.WebService.Entities.Parameters;
using Domain.LinxMicrovix.Outbound.WebService.Interfaces.Repositorys.LinxMicrovix;
using Domain.LinxMicrovix.Outbound.WebService.Entities.LinxMicrovix;

namespace Infrastructure.LinxMicrovix.Outbound.WebService.Repository.LinxMicrovix
{
    public class LinxMovimentoRemessasItensRepository : ILinxMovimentoRemessasItensRepository
    {
        public LinxMovimentoRemessasItensRepository()
        {

        }

        public bool BulkInsertIntoTableRaw(LinxAPIParam jobParameter, IList<LinxMovimentoRemessasItens> records)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<LinxMovimentoRemessasItens>> GetRegistersExists(LinxAPIParam jobParameter, List<LinxMovimentoRemessasItens> registros)
        {
            throw new NotImplementedException();
        }

        public Task<bool> InsertRecord(LinxAPIParam jobParameter, LinxMovimentoRemessasItens? record)
        {
            throw new NotImplementedException();
        }
    }
}
