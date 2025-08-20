using Domain.LinxMicrovix.Outbound.WebService.Entities.Parameters;
using Domain.LinxMicrovix.Outbound.WebService.Interfaces.Repositorys.LinxMicrovix;
using Domain.LinxMicrovix.Outbound.WebService.Models.LinxMicrovix;

namespace Infrastructure.LinxMicrovix.Outbound.WebService.Repository.LinxMicrovix
{
    public class LinxLinhasRepository : ILinxLinhasRepository
    {
        public LinxLinhasRepository()
        {

        }

        public bool BulkInsertIntoTableRaw(LinxAPIParam jobParameter, IList<LinxLinhas> records)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<LinxLinhas>> GetRegistersExists(LinxAPIParam jobParameter, List<LinxLinhas> registros)
        {
            throw new NotImplementedException();
        }

        public Task<bool> InsertRecord(LinxAPIParam jobParameter, LinxLinhas? record)
        {
            throw new NotImplementedException();
        }
    }
}
