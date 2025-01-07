using Domain.LinxMicrovix.Outbound.WebService.Entites.Parameters;
using Domain.LinxMicrovix.Outbound.WebService.Interfaces.Repositorys.LinxMicrovix;

namespace Domain.LinxMicrovix.Outbound.WebService.Entites.LinxMicrovix
{
    public class LinxValesComprasEnviadosAPIRepository : ILinxValesComprasEnviadosAPIRepository
    {
        public LinxValesComprasEnviadosAPIRepository()
        {
            
        }

        public bool BulkInsertIntoTableRaw(LinxAPIParam jobParameter, IList<LinxValesComprasEnviadosAPI> records)
        {
            throw new NotImplementedException();
        }

        public Task<List<LinxValesComprasEnviadosAPI>> GetRegistersExists(LinxAPIParam jobParameter, List<LinxValesComprasEnviadosAPI> registros)
        {
            throw new NotImplementedException();
        }

        public Task<bool> InsertRecord(LinxAPIParam jobParameter, LinxValesComprasEnviadosAPI? record)
        {
            throw new NotImplementedException();
        }
    }
}
