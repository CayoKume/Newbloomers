using Domain.LinxMicrovix.Outbound.WebService.Entites.LinxMicrovix;
using Domain.LinxMicrovix.Outbound.WebService.Entites.Parameters;

namespace Domain.LinxMicrovix.Outbound.WebService.Interfaces.Repositorys.LinxMicrovix
{
    public interface ILinxDadosOpticosDavRepository
    {
        public Task<bool> InsertRecord(LinxAPIParam jobParameter, LinxDadosOpticosDav? record);
        public bool BulkInsertIntoTableRaw(LinxAPIParam jobParameter, IList<LinxDadosOpticosDav> records);
        public Task<List<LinxDadosOpticosDav>> GetRegistersExists(LinxAPIParam jobParameter, List<LinxDadosOpticosDav> registros);
    }
}
