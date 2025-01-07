using Domain.LinxMicrovix.Outbound.WebService.Entites.Parameters;
using Domain.LinxMicrovix.Outbound.WebService.Interfaces.Repositorys.LinxMicrovix;

namespace Domain.LinxMicrovix.Outbound.WebService.Entites.LinxMicrovix
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

        public Task<List<LinxOrdemServicoExternaDav>> GetRegistersExists(LinxAPIParam jobParameter, List<LinxOrdemServicoExternaDav> registros)
        {
            throw new NotImplementedException();
        }

        public Task<bool> InsertRecord(LinxAPIParam jobParameter, LinxOrdemServicoExternaDav? record)
        {
            throw new NotImplementedException();
        }
    }
}
