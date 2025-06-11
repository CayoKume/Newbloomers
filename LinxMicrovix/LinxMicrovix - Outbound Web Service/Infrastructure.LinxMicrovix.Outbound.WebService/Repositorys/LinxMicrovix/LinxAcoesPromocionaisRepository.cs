using Domain.LinxMicrovix.Outbound.WebService.Entities.Parameters;
using Domain.LinxMicrovix.Outbound.WebService.Interfaces.Repositorys.LinxMicrovix;
using Domain.LinxMicrovix.Outbound.WebService.Entities.LinxMicrovix;

namespace Infrastructure.LinxMicrovix.Outbound.WebService.Repository.LinxMicrovix
{
    public class LinxAcoesPromocionaisRepository : ILinxAcoesPromocionaisRepository
    {
        public LinxAcoesPromocionaisRepository()
        {

        }

        public bool BulkInsertIntoTableRaw(LinxAPIParam jobParameter, IList<LinxAcoesPromocionais> records)
        {
            throw new NotImplementedException();
        }

        public Task<List<LinxAcoesPromocionais>> GetRegistersExists(LinxAPIParam jobParameter, List<LinxAcoesPromocionais> registros)
        {
            throw new NotImplementedException();
        }

        public Task<bool> InsertRecord(LinxAPIParam jobParameter, LinxAcoesPromocionais? record)
        {
            throw new NotImplementedException();
        }
    }
}
