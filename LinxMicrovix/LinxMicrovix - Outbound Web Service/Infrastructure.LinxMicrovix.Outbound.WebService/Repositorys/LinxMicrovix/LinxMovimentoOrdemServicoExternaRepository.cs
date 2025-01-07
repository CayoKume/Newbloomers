using Domain.LinxMicrovix.Outbound.WebService.Entites.Parameters;
using Domain.LinxMicrovix.Outbound.WebService.Interfaces.Repositorys.LinxMicrovix;

namespace Domain.LinxMicrovix.Outbound.WebService.Entites.LinxMicrovix
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
