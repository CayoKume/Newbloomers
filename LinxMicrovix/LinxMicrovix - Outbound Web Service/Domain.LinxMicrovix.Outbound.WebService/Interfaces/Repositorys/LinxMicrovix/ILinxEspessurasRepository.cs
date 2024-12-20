using Domain.LinxMicrovix.Outbound.WebService.Entites.LinxMicrovix;
using Domain.LinxMicrovix.Outbound.WebService.Entites.Parameters;

namespace Domain.LinxMicrovix.Outbound.WebService.Interfaces.Repositorys.LinxMicrovix
{
    public interface ILinxEspessurasRepository
    {
        public Task<bool> InsertRecord(LinxAPIParam jobParameter, LinxEspessuras? record);
        public bool BulkInsertIntoTableRaw(LinxAPIParam jobParameter, IList<LinxEspessuras> records);
        public Task<List<LinxEspessuras>> GetRegistersExists(LinxAPIParam jobParameter, List<LinxEspessuras> registros);
    }
}
