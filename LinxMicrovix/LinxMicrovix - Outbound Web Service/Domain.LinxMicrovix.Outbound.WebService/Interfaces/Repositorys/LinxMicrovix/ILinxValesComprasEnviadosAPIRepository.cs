using Domain.LinxMicrovix.Outbound.WebService.Entites.LinxMicrovix;
using Domain.LinxMicrovix.Outbound.WebService.Entites.Parameters;

namespace Domain.LinxMicrovix.Outbound.WebService.Interfaces.Repositorys.LinxMicrovix
{
    public interface ILinxValesComprasEnviadosAPIRepository
    {
        public Task<bool> InsertRecord(LinxAPIParam jobParameter, LinxValesComprasEnviadosAPI? record);
        public bool BulkInsertIntoTableRaw(LinxAPIParam jobParameter, IList<LinxValesComprasEnviadosAPI> records);
        public Task<List<LinxValesComprasEnviadosAPI>> GetRegistersExists(LinxAPIParam jobParameter, List<LinxValesComprasEnviadosAPI> registros);

    }
}
