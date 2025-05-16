using Domain.LinxMicrovix.Outbound.WebService.Entites.Parameters;
using Domain.LinxMicrovix.Outbound.WebService.Entites.LinxMicrovix;

namespace Domain.LinxMicrovix.Outbound.WebService.Interfaces.Repositorys.LinxMicrovix
{
    public interface ILinxUsuariosRepository
    {
        public bool BulkInsertIntoTableRaw(LinxAPIParam jobParameter, IList<LinxUsuarios> records);
        public Task<List<string?>> GetRegistersExists(LinxAPIParam jobParameter, List<int?> registros);
    }
}
