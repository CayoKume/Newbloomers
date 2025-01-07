using Domain.LinxMicrovix.Outbound.WebService.Entites.Parameters;
using Domain.LinxMicrovix.Outbound.WebService.Interfaces.Repositorys.LinxMicrovix;

namespace Domain.LinxMicrovix.Outbound.WebService.Entites.LinxMicrovix
{
    public class LinxMovimentoRemessasAcertosRepository : ILinxMovimentoRemessasAcertosRepository
    {
        public LinxMovimentoRemessasAcertosRepository()
        {
            
        }

        public bool BulkInsertIntoTableRaw(LinxAPIParam jobParameter, IList<LinxMovimentoRemessasAcertos> records)
        {
            throw new NotImplementedException();
        }

        public Task<List<LinxMovimentoRemessasAcertos>> GetRegistersExists(LinxAPIParam jobParameter, List<LinxMovimentoRemessasAcertos> registros)
        {
            throw new NotImplementedException();
        }

        public Task<bool> InsertRecord(LinxAPIParam jobParameter, LinxMovimentoRemessasAcertos? record)
        {
            throw new NotImplementedException();
        }
    }
}
