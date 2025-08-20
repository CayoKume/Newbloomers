using Domain.LinxMicrovix.Outbound.WebService.Entities.Parameters;
using Domain.LinxMicrovix.Outbound.WebService.Interfaces.Repositorys.LinxMicrovix;
using Domain.LinxMicrovix.Outbound.WebService.Models.LinxMicrovix;

namespace Infrastructure.LinxMicrovix.Outbound.WebService.Repository.LinxMicrovix
{
    public class LinxOrdemServicoExternaDavRepository : ILinxOrdemServicoExternaDavRepository
    {
        public LinxOrdemServicoExternaDavRepository()
        {

        }

        public bool BulkInsertIntoTableRaw(LinxAPIParam jobParameter, IList<LinxOrdemServicoExternaDav> records)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<LinxOrdemServicoExternaDav>> GetRegistersExists(LinxAPIParam jobParameter, List<LinxOrdemServicoExternaDav> registros)
        {
            throw new NotImplementedException();
        }

        public Task<bool> InsertRecord(LinxAPIParam jobParameter, LinxOrdemServicoExternaDav? record)
        {
            throw new NotImplementedException();
        }
    }
}
