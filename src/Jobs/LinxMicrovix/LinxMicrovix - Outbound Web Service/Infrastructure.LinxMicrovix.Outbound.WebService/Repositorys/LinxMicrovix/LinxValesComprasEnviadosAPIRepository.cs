using Domain.LinxMicrovix.Outbound.WebService.Entities.Parameters;
using Domain.LinxMicrovix.Outbound.WebService.Interfaces.Repositorys.LinxMicrovix;
using Domain.LinxMicrovix.Outbound.WebService.Models.LinxMicrovix;

namespace Infrastructure.LinxMicrovix.Outbound.WebService.Repository.LinxMicrovix
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

        public Task<IEnumerable<LinxValesComprasEnviadosAPI>> GetRegistersExists(LinxAPIParam jobParameter, List<LinxValesComprasEnviadosAPI> registros)
        {
            throw new NotImplementedException();
        }

        public Task<bool> InsertRecord(LinxAPIParam jobParameter, LinxValesComprasEnviadosAPI? record)
        {
            throw new NotImplementedException();
        }
    }
}
