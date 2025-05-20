using Domain.LinxMicrovix.Outbound.WebService.Entites.Parameters;
using Domain.LinxMicrovix.Outbound.WebService.Interfaces.Repositorys.LinxMicrovix;
using Domain.LinxMicrovix.Outbound.WebService.Entites.LinxMicrovix;

namespace Infrastructure.LinxMicrovix.Outbound.WebService.Repository.Dapper.LinxMicrovix
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

        public Task<List<LinxMovimentoRemessasAcertosItens>> GetRegistersExists(LinxAPIParam jobParameter, List<LinxMovimentoRemessasAcertosItens> registros)
        {
            throw new NotImplementedException();
        }

        public Task<bool> InsertRecord(LinxAPIParam jobParameter, LinxMovimentoRemessasAcertosItens? record)
        {
            throw new NotImplementedException();
        }
    }
}
