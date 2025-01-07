using Domain.LinxMicrovix.Outbound.WebService.Entites.Parameters;
using Domain.LinxMicrovix.Outbound.WebService.Interfaces.Repositorys.LinxMicrovix;

namespace Domain.LinxMicrovix.Outbound.WebService.Entites.LinxMicrovix
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

        public Task<List<LinxTradeinParceiro>> GetRegistersExists(LinxAPIParam jobParameter, List<LinxTradeinParceiro> registros)
        {
            throw new NotImplementedException();
        }

        public Task<bool> InsertRecord(LinxAPIParam jobParameter, LinxTradeinParceiro? record)
        {
            throw new NotImplementedException();
        }
    }
}
