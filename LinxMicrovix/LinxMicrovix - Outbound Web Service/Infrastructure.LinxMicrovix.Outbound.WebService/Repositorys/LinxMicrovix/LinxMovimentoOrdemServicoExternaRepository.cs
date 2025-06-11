using Domain.LinxMicrovix.Outbound.WebService.Entities.Parameters;
using Domain.LinxMicrovix.Outbound.WebService.Interfaces.Repositorys.LinxMicrovix;
using Domain.LinxMicrovix.Outbound.WebService.Entities.LinxMicrovix;

namespace Infrastructure.LinxMicrovix.Outbound.WebService.Repository.LinxMicrovix
{
    public class LinxMovimentoOrdemServicoExternaRepository : ILinxMovimentoOrdemServicoExternaRepository
    {
        public LinxMovimentoOrdemServicoExternaRepository()
        {

        }

        public bool BulkInsertIntoTableRaw(LinxAPIParam jobParameter, IList<LinxMovimentoOrdemServicoExterna> records)
        {
            throw new NotImplementedException();
        }

        public Task<List<LinxMovimentoOrdemServicoExterna>> GetRegistersExists(LinxAPIParam jobParameter, List<LinxMovimentoOrdemServicoExterna> registros)
        {
            throw new NotImplementedException();
        }

        public Task<bool> InsertRecord(LinxAPIParam jobParameter, LinxMovimentoOrdemServicoExterna? record)
        {
            throw new NotImplementedException();
        }
    }
}
