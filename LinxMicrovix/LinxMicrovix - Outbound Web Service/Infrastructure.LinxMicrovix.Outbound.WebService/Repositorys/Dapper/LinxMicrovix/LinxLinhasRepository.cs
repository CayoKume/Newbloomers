using Domain.LinxMicrovix.Outbound.WebService.Entites.Parameters;
using Domain.LinxMicrovix.Outbound.WebService.Interfaces.Repositorys.LinxMicrovix;
using Domain.LinxMicrovix.Outbound.WebService.Entites.LinxMicrovix;

namespace Infrastructure.LinxMicrovix.Outbound.WebService.Repository.Dapper.LinxMicrovix
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

        public Task<List<LinxLinhas>> GetRegistersExists(LinxAPIParam jobParameter, List<LinxLinhas> registros)
        {
            throw new NotImplementedException();
        }

        public Task<bool> InsertRecord(LinxAPIParam jobParameter, LinxLinhas? record)
        {
            throw new NotImplementedException();
        }
    }
}
