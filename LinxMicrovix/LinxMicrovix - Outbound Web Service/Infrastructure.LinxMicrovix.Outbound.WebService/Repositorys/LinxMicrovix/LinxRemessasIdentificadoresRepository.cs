using Domain.LinxMicrovix.Outbound.WebService.Entites.Parameters;
using Domain.LinxMicrovix.Outbound.WebService.Interfaces.Repositorys.LinxMicrovix;

namespace Domain.LinxMicrovix.Outbound.WebService.Entites.LinxMicrovix
{
    public class LinxRemessasIdentificadoresRepository : ILinxRemessasIdentificadoresRepository
    {
        public LinxRemessasIdentificadoresRepository()
        {
            
        }

        public bool BulkInsertIntoTableRaw(LinxAPIParam jobParameter, IList<LinxRemessasIdentificadores> records)
        {
            throw new NotImplementedException();
        }

        public Task<List<LinxRemessasIdentificadores>> GetRegistersExists(LinxAPIParam jobParameter, List<LinxRemessasIdentificadores> registros)
        {
            throw new NotImplementedException();
        }

        public Task<bool> InsertRecord(LinxAPIParam jobParameter, LinxRemessasIdentificadores? record)
        {
            throw new NotImplementedException();
        }
    }
}
