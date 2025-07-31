using Domain.LinxMicrovix.Outbound.WebService.Entities.Parameters;
using Domain.LinxMicrovix.Outbound.WebService.Interfaces.Repositorys.LinxMicrovix;
using Domain.LinxMicrovix.Outbound.WebService.Models.LinxMicrovix;

namespace Infrastructure.LinxMicrovix.Outbound.WebService.Repository.LinxMicrovix
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

        public Task<IEnumerable<LinxValeOrdemServicoExterna>> GetRegistersExists(LinxAPIParam jobParameter, List<LinxValeOrdemServicoExterna> registros)
        {
            throw new NotImplementedException();
        }

        public Task<bool> InsertRecord(LinxAPIParam jobParameter, LinxValeOrdemServicoExterna? record)
        {
            throw new NotImplementedException();
        }
    }
}
