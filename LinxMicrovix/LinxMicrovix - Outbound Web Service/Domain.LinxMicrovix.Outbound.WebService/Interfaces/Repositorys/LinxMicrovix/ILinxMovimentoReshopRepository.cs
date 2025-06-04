using Domain.LinxMicrovix.Outbound.WebService.Entities.LinxMicrovix;
using Domain.LinxMicrovix.Outbound.WebService.Entities.Parameters;

namespace Domain.LinxMicrovix.Outbound.WebService.Interfaces.Repositorys.LinxMicrovix
{
    public interface ILinxMovimentoReshopRepository
    {
        public Task<bool> InsertRecord(LinxAPIParam jobParameter, LinxMovimentoReshop? record);
        public bool BulkInsertIntoTableRaw(LinxAPIParam jobParameter, IList<LinxMovimentoReshop> records);
        public Task<List<LinxMovimentoReshop>> GetRegistersExists(LinxAPIParam jobParameter, List<LinxMovimentoReshop> registros);
    }
}
