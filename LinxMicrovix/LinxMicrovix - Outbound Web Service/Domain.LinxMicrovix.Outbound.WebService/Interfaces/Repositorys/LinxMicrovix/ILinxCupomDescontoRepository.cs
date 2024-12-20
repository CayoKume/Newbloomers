using Domain.LinxMicrovix.Outbound.WebService.Entites.LinxMicrovix;
using Domain.LinxMicrovix.Outbound.WebService.Entites.Parameters;

namespace Domain.LinxMicrovix.Outbound.WebService.Interfaces.Repositorys.LinxMicrovix
{
    public interface ILinxCupomDescontoRepository
    {
        public Task<bool> InsertRecord(LinxAPIParam jobParameter, LinxCupomDesconto? record);
        public bool BulkInsertIntoTableRaw(LinxAPIParam jobParameter, IList<LinxCupomDesconto> records);
        public Task<List<LinxCupomDesconto>> GetRegistersExists(LinxAPIParam jobParameter, List<LinxCupomDesconto> registros);
    }
}
