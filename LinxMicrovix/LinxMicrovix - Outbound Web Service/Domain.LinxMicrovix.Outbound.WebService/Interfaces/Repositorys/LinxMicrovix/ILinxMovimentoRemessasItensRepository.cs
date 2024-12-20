using Domain.LinxMicrovix.Outbound.WebService.Entites.LinxMicrovix;
using Domain.LinxMicrovix.Outbound.WebService.Entites.Parameters;

namespace Domain.LinxMicrovix.Outbound.WebService.Interfaces.Repositorys.LinxMicrovix
{
    public interface ILinxMovimentoRemessasItensRepository
    {
        public Task<bool> InsertRecord(LinxAPIParam jobParameter, LinxMovimentoRemessasItens? record);
        public bool BulkInsertIntoTableRaw(LinxAPIParam jobParameter, IList<LinxMovimentoRemessasItens> records);
        public Task<List<LinxMovimentoRemessasItens>> GetRegistersExists(LinxAPIParam jobParameter, List<LinxMovimentoRemessasItens> registros);
    }
}
