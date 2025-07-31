using Domain.LinxMicrovix.Outbound.WebService.Entities.Parameters;
using Domain.LinxMicrovix.Outbound.WebService.Interfaces.Repositorys.LinxMicrovix;
using Domain.LinxMicrovix.Outbound.WebService.Models.LinxMicrovix;

namespace Infrastructure.LinxMicrovix.Outbound.WebService.Repository.LinxMicrovix
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

        public Task<IEnumerable<LinxRemessasIdentificadores>> GetRegistersExists(LinxAPIParam jobParameter, List<LinxRemessasIdentificadores> registros)
        {
            throw new NotImplementedException();
        }

        public Task<bool> InsertRecord(LinxAPIParam jobParameter, LinxRemessasIdentificadores? record)
        {
            throw new NotImplementedException();
        }
    }
}
