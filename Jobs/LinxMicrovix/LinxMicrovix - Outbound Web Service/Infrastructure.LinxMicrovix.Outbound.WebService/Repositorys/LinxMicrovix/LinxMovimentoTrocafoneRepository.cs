using Domain.LinxMicrovix.Outbound.WebService.Entities.Parameters;
using Domain.LinxMicrovix.Outbound.WebService.Interfaces.Repositorys.LinxMicrovix;
using Domain.LinxMicrovix.Outbound.WebService.Models.LinxMicrovix;

namespace Infrastructure.LinxMicrovix.Outbound.WebService.Repository.LinxMicrovix
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

        public Task<IEnumerable<LinxMovimentoTrocafone>> GetRegistersExists(LinxAPIParam jobParameter, List<LinxMovimentoTrocafone> registros)
        {
            throw new NotImplementedException();
        }

        public Task<bool> InsertRecord(LinxAPIParam jobParameter, LinxMovimentoTrocafone? record)
        {
            throw new NotImplementedException();
        }
    }
}
