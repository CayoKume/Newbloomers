using Domain.LinxMicrovix.Outbound.WebService.Entites.Parameters;
using Domain.LinxMicrovix.Outbound.WebService.Interfaces.Repositorys.LinxMicrovix;

namespace Domain.LinxMicrovix.Outbound.WebService.Entites.LinxMicrovix
{
    public class LinxValeOrdemServicoExternaRepository : ILinxValeOrdemServicoExternaRepository
    {
        public LinxValeOrdemServicoExternaRepository()
        {
            
        }

        public bool BulkInsertIntoTableRaw(LinxAPIParam jobParameter, IList<LinxValeOrdemServicoExterna> records)
        {
            throw new NotImplementedException();
        }

        public Task<List<LinxValeOrdemServicoExterna>> GetRegistersExists(LinxAPIParam jobParameter, List<LinxValeOrdemServicoExterna> registros)
        {
            throw new NotImplementedException();
        }

        public Task<bool> InsertRecord(LinxAPIParam jobParameter, LinxValeOrdemServicoExterna? record)
        {
            throw new NotImplementedException();
        }
    }
}
