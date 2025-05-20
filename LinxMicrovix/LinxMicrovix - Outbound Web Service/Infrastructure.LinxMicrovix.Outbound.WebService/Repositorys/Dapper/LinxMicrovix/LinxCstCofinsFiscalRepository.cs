using Domain.LinxMicrovix.Outbound.WebService.Entites.Parameters;
using Domain.LinxMicrovix.Outbound.WebService.Interfaces.Repositorys.LinxMicrovix;
using Domain.LinxMicrovix.Outbound.WebService.Entites.LinxMicrovix;

namespace Infrastructure.LinxMicrovix.Outbound.WebService.Repository.Dapper.LinxMicrovix
{
    public class LinxCstCofinsFiscalRepository : ILinxCstCofinsFiscalRepository
    {
        public LinxCstCofinsFiscalRepository()
        {

        }

        public bool BulkInsertIntoTableRaw(LinxAPIParam jobParameter, IList<LinxCstCofinsFiscal> records)
        {
            throw new NotImplementedException();
        }

        public Task<List<LinxCstCofinsFiscal>> GetRegistersExists(LinxAPIParam jobParameter, List<LinxCstCofinsFiscal> registros)
        {
            throw new NotImplementedException();
        }

        public Task<bool> InsertRecord(LinxAPIParam jobParameter, LinxCstCofinsFiscal? record)
        {
            throw new NotImplementedException();
        }
    }
}
