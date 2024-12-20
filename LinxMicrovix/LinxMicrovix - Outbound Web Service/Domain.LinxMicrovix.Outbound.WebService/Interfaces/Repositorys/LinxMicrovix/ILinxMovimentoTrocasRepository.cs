using Domain.LinxMicrovix.Outbound.WebService.Entites.LinxMicrovix;
using Domain.LinxMicrovix.Outbound.WebService.Entites.Parameters;

namespace Domain.LinxMicrovix.Outbound.WebService.Interfaces.Repositorys.LinxMicrovix
{
    public interface ILinxMovimentoTrocasRepository
    {
        public Task<bool> InsertRecord(LinxAPIParam jobParameter, LinxMovimentoTrocas? record);
        public bool BulkInsertIntoTableRaw(LinxAPIParam jobParameter, IList<LinxMovimentoTrocas> records);
        public Task<List<LinxMovimentoTrocas>> GetRegistersExists(LinxAPIParam jobParameter, List<LinxMovimentoTrocas> registros);
    }
}
