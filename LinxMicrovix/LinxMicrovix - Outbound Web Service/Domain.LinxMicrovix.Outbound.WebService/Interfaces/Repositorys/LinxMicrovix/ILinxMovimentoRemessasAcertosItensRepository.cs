using Domain.LinxMicrovix.Outbound.WebService.Entites.LinxMicrovix;
using Domain.LinxMicrovix.Outbound.WebService.Entites.Parameters;

namespace Domain.LinxMicrovix.Outbound.WebService.Interfaces.Repositorys.LinxMicrovix
{
    public interface ILinxMovimentoRemessasAcertosItensRepository
    {
        public Task<bool> InsertRecord(LinxAPIParam jobParameter, LinxMovimentoRemessasAcertosItens? record);
        public bool BulkInsertIntoTableRaw(LinxAPIParam jobParameter, IList<LinxMovimentoRemessasAcertosItens> records);
        public Task<List<LinxMovimentoRemessasAcertosItens>> GetRegistersExists(LinxAPIParam jobParameter, List<LinxMovimentoRemessasAcertosItens> registros);
    }
}
