using Domain.LinxMicrovix.Outbound.WebService.Entites.LinxMicrovix;
using Domain.LinxMicrovix.Outbound.WebService.Entites.Parameters;

namespace Domain.LinxMicrovix.Outbound.WebService.Interfaces.Repositorys.LinxMicrovix
{
    public interface ILinxMovimentoRemessasRepository
    {
        public Task<bool> InsertRecord(LinxAPIParam jobParameter, LinxMovimentoRemessas? record);
        public bool BulkInsertIntoTableRaw(LinxAPIParam jobParameter, IList<LinxMovimentoRemessas> records);
        public Task<List<LinxMovimentoRemessas>> GetRegistersExists(LinxAPIParam jobParameter, List<LinxMovimentoRemessas> registros);
    }
}
