using Domain.LinxMicrovix.Outbound.WebService.Entities.LinxMicrovix;
using Domain.LinxMicrovix.Outbound.WebService.Entities.Parameters;

namespace Domain.LinxMicrovix.Outbound.WebService.Interfaces.Repositorys.LinxMicrovix
{
    public interface ILinxValesComprasEnviadosAPIRepository
    {
        public Task<bool> InsertRecord(LinxAPIParam jobParameter, LinxValesComprasEnviadosAPI? record);
        public bool BulkInsertIntoTableRaw(LinxAPIParam jobParameter, IList<LinxValesComprasEnviadosAPI> records);
        public Task<IEnumerable<LinxValesComprasEnviadosAPI>> GetRegistersExists(LinxAPIParam jobParameter, List<LinxValesComprasEnviadosAPI> registros);

    }
}
