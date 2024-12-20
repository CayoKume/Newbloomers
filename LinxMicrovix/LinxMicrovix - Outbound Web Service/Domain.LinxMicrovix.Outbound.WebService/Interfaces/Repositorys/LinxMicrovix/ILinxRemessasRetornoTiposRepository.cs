using Domain.LinxMicrovix.Outbound.WebService.Entites.LinxMicrovix;
using Domain.LinxMicrovix.Outbound.WebService.Entites.Parameters;

namespace Domain.LinxMicrovix.Outbound.WebService.Interfaces.Repositorys.LinxMicrovix
{
    public interface ILinxRemessasRetornoTiposRepository
    {
        public Task<bool> InsertRecord(LinxAPIParam jobParameter, LinxRemessasRetornoTipos? record);
        public bool BulkInsertIntoTableRaw(LinxAPIParam jobParameter, IList<LinxRemessasRetornoTipos> records);
        public Task<List<LinxRemessasRetornoTipos>> GetRegistersExists(LinxAPIParam jobParameter, List<LinxRemessasRetornoTipos> registros);
    }
}
