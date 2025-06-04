using Domain.LinxMicrovix.Outbound.WebService.Entities.LinxMicrovix;
using Domain.LinxMicrovix.Outbound.WebService.Entities.Parameters;

namespace Domain.LinxMicrovix.Outbound.WebService.Interfaces.Repositorys.LinxMicrovix
{
    public interface ILinxMovimentoReshopItensRepository
    {
        public Task<bool> InsertRecord(LinxAPIParam jobParameter, LinxMovimentoReshopItens? record);
        public bool BulkInsertIntoTableRaw(LinxAPIParam jobParameter, IList<LinxMovimentoReshopItens> records);
        public Task<List<LinxMovimentoReshopItens>> GetRegistersExists(LinxAPIParam jobParameter, List<LinxMovimentoReshopItens> registros);
    }
}
