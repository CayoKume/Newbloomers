using Domain.LinxMicrovix.Outbound.WebService.Models.LinxMicrovix;
using Domain.LinxMicrovix.Outbound.WebService.Entities.Parameters;

namespace Domain.LinxMicrovix.Outbound.WebService.Interfaces.Repositorys.LinxMicrovix
{
    public interface ILinxMovimentoRemessasAcertosRepository
    {
        public Task<bool> InsertRecord(LinxAPIParam jobParameter, LinxMovimentoRemessasAcertos? record);
        public bool BulkInsertIntoTableRaw(LinxAPIParam jobParameter, IList<LinxMovimentoRemessasAcertos> records);
        public Task<IEnumerable<LinxMovimentoRemessasAcertos>> GetRegistersExists(LinxAPIParam jobParameter, List<LinxMovimentoRemessasAcertos> registros);
    }
}
