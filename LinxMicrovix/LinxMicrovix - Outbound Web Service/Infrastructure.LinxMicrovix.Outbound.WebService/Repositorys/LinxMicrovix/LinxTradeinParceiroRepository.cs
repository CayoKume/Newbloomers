using Domain.LinxMicrovix.Outbound.WebService.Entities.Parameters;
using Domain.LinxMicrovix.Outbound.WebService.Interfaces.Repositorys.LinxMicrovix;
using Domain.LinxMicrovix.Outbound.WebService.Entities.LinxMicrovix;

namespace Infrastructure.LinxMicrovix.Outbound.WebService.Repository.LinxMicrovix
{
    public class LinxTradeinParceiroRepository : ILinxTradeinParceiroRepository
    {
        public LinxTradeinParceiroRepository()
        {

        }

        public bool BulkInsertIntoTableRaw(LinxAPIParam jobParameter, IList<LinxTradeinParceiro> records)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<LinxTradeinParceiro>> GetRegistersExists(LinxAPIParam jobParameter, List<LinxTradeinParceiro> registros)
        {
            throw new NotImplementedException();
        }

        public Task<bool> InsertRecord(LinxAPIParam jobParameter, LinxTradeinParceiro? record)
        {
            throw new NotImplementedException();
        }
    }
}
