using Domain.LinxMicrovix.Outbound.WebService.Entites.Parameters;
using Domain.LinxMicrovix.Outbound.WebService.Interfaces.Repositorys.LinxMicrovix;

namespace Domain.LinxMicrovix.Outbound.WebService.Entites.LinxMicrovix
{
    public class LinxMovimentoTrocafoneRepository : ILinxMovimentoTrocafoneRepository
    {
        public LinxMovimentoTrocafoneRepository()
        {
            
        }

        public bool BulkInsertIntoTableRaw(LinxAPIParam jobParameter, IList<LinxMovimentoTrocafone> records)
        {
            throw new NotImplementedException();
        }

        public Task<List<LinxMovimentoTrocafone>> GetRegistersExists(LinxAPIParam jobParameter, List<LinxMovimentoTrocafone> registros)
        {
            throw new NotImplementedException();
        }

        public Task<bool> InsertRecord(LinxAPIParam jobParameter, LinxMovimentoTrocafone? record)
        {
            throw new NotImplementedException();
        }
    }
}
