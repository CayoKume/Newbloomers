using Domain.LinxMicrovix.Outbound.WebService.Entities.LinxMicrovix;
using Domain.LinxMicrovix.Outbound.WebService.Entities.Parameters;

namespace Domain.LinxMicrovix.Outbound.WebService.Interfaces.Repositorys.LinxMicrovix
{
    public interface ILinxMovimentoDevolucoesItensRepository
    {
        public Task<bool> InsertRecord(LinxAPIParam jobParameter, LinxMovimentoDevolucoesItens? record);
        public bool BulkInsertIntoTableRaw(LinxAPIParam jobParameter, IList<LinxMovimentoDevolucoesItens> records);
        public Task<IEnumerable<LinxMovimentoDevolucoesItens>> GetRegistersExists(LinxAPIParam jobParameter, List<LinxMovimentoDevolucoesItens> registros);
    }
}
