using Domain.LinxMicrovix.Outbound.WebService.Entities.Parameters;
using Domain.LinxMicrovix.Outbound.WebService.Interfaces.Repositorys.LinxMicrovix;
using Domain.LinxMicrovix.Outbound.WebService.Entities.LinxMicrovix;

namespace Infrastructure.LinxMicrovix.Outbound.WebService.Repository.LinxMicrovix
{
    public class LinxMovimentoRemessasAcertosItensRepository : ILinxMovimentoRemessasAcertosItensRepository
    {
        public LinxMovimentoRemessasAcertosItensRepository()
        {

        }

        public bool BulkInsertIntoTableRaw(LinxAPIParam jobParameter, IList<LinxMovimentoRemessasAcertosItens> records)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<LinxMovimentoRemessasAcertosItens>> GetRegistersExists(LinxAPIParam jobParameter, List<LinxMovimentoRemessasAcertosItens> registros)
        {
            throw new NotImplementedException();
        }

        public Task<bool> InsertRecord(LinxAPIParam jobParameter, LinxMovimentoRemessasAcertosItens? record)
        {
            throw new NotImplementedException();
        }
    }
}
