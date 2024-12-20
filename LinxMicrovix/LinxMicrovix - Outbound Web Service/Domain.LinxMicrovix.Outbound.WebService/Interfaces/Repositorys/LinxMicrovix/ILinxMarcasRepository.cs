using Domain.LinxMicrovix.Outbound.WebService.Entites.LinxMicrovix;
using Domain.LinxMicrovix.Outbound.WebService.Entites.Parameters;

namespace Domain.LinxMicrovix.Outbound.WebService.Interfaces.Repositorys.LinxMicrovix
{
    public interface ILinxMarcasRepository
    {
        public Task<bool> InsertRecord(LinxAPIParam jobParameter, LinxMarcas? record);
        public bool BulkInsertIntoTableRaw(LinxAPIParam jobParameter, IList<LinxMarcas> records);
        public Task<List<LinxMarcas>> GetRegistersExists(LinxAPIParam jobParameter, List<LinxMarcas> registros);
    }
}
