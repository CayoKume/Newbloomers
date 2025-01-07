using Domain.LinxMicrovix.Outbound.WebService.Entites.Parameters;
using Domain.LinxMicrovix.Outbound.WebService.Interfaces.Repositorys.LinxMicrovix;

namespace Domain.LinxMicrovix.Outbound.WebService.Entites.LinxMicrovix
{
    public class LinxSeriesRepository : ILinxSeriesRepository
    {
        public LinxSeriesRepository()
        {
            
        }

        public bool BulkInsertIntoTableRaw(LinxAPIParam jobParameter, IList<LinxSeries> records)
        {
            throw new NotImplementedException();
        }

        public Task<List<LinxSeries>> GetRegistersExists(LinxAPIParam jobParameter, List<LinxSeries> registros)
        {
            throw new NotImplementedException();
        }

        public Task<bool> InsertRecord(LinxAPIParam jobParameter, LinxSeries? record)
        {
            throw new NotImplementedException();
        }
    }
}
