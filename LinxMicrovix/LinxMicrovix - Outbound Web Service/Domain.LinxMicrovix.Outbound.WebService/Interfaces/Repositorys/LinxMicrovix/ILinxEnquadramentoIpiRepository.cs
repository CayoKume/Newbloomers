using Domain.LinxMicrovix.Outbound.WebService.Entities.LinxMicrovix;
using Domain.LinxMicrovix.Outbound.WebService.Entities.Parameters;

namespace Domain.LinxMicrovix.Outbound.WebService.Interfaces.Repositorys.LinxMicrovix
{
    public interface ILinxEnquadramentoIpiRepository
    {
        public Task<bool> InsertRecord(LinxAPIParam jobParameter, LinxEnquadramentoIpi? record);
        public bool BulkInsertIntoTableRaw(LinxAPIParam jobParameter, IList<LinxEnquadramentoIpi> records);
        public Task<IEnumerable<LinxEnquadramentoIpi>> GetRegistersExists(LinxAPIParam jobParameter, List<LinxEnquadramentoIpi> registros);
    }
}
