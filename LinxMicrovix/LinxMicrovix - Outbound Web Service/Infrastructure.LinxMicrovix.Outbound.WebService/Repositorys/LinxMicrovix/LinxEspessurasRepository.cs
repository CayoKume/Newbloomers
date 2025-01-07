using Domain.LinxMicrovix.Outbound.WebService.Entites.Parameters;
using Domain.LinxMicrovix.Outbound.WebService.Interfaces.Repositorys.LinxMicrovix;

namespace Domain.LinxMicrovix.Outbound.WebService.Entites.LinxMicrovix
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
