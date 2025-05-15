using Domain.LinxMicrovix.Outbound.WebService.Entites.Parameters;
using Domain.LinxMicrovix.Outbound.WebService.Interfaces.Repositorys.LinxMicrovix;
using Domain.LinxMicrovix.Outbound.WebService.Entites.LinxMicrovix;

namespace Infrastructure.LinxMicrovix.Outbound.WebService.Repository.Dapper.LinxMicrovix
{
    public class LinxEspessurasRepository : ILinxEspessurasRepository
    {
        public LinxEspessurasRepository()
        {
            
        }

        public bool BulkInsertIntoTableRaw(LinxAPIParam jobParameter, IList<LinxEspessuras> records)
        {
            throw new NotImplementedException();
        }

        public Task<List<LinxEspessuras>> GetRegistersExists(LinxAPIParam jobParameter, List<LinxEspessuras> registros)
        {
            throw new NotImplementedException();
        }

        public Task<bool> InsertRecord(LinxAPIParam jobParameter, LinxEspessuras? record)
        {
            throw new NotImplementedException();
        }
    }
}
