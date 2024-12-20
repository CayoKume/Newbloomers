using Domain.LinxMicrovix.Outbound.WebService.Entites.LinxMicrovix;
using Domain.LinxMicrovix.Outbound.WebService.Entites.Parameters;

namespace Domain.LinxMicrovix.Outbound.WebService.Interfaces.Repositorys.LinxMicrovix
{
    public interface ILinxSeriesRepository
    {
        public Task<bool> InsertRecord(LinxAPIParam jobParameter, LinxSeries? record);
        public bool BulkInsertIntoTableRaw(LinxAPIParam jobParameter, IList<LinxSeries> records);
        public Task<List<LinxSeries>> GetRegistersExists(LinxAPIParam jobParameter, List<LinxSeries> registros);
    }
}
