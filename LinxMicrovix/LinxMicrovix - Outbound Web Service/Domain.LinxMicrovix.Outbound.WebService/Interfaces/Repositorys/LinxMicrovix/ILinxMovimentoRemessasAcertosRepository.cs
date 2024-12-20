using Domain.LinxMicrovix.Outbound.WebService.Entites.LinxMicrovix;
using Domain.LinxMicrovix.Outbound.WebService.Entites.Parameters;

namespace Domain.LinxMicrovix.Outbound.WebService.Interfaces.Repositorys.LinxMicrovix
{
    public interface ILinxMovimentoRemessasAcertosRepository
    {
        public Task<bool> InsertRecord(LinxAPIParam jobParameter, LinxMovimentoRemessasAcertos? record);
        public bool BulkInsertIntoTableRaw(LinxAPIParam jobParameter, IList<LinxMovimentoRemessasAcertos> records);
        public Task<List<LinxMovimentoRemessasAcertos>> GetRegistersExists(LinxAPIParam jobParameter, List<LinxMovimentoRemessasAcertos> registros);
    }
}
