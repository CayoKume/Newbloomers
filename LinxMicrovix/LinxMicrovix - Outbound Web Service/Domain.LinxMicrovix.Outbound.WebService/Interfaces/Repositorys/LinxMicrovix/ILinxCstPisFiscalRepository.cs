using Domain.LinxMicrovix.Outbound.WebService.Entities.LinxMicrovix;
using Domain.LinxMicrovix.Outbound.WebService.Entities.Parameters;

namespace Domain.LinxMicrovix.Outbound.WebService.Interfaces.Repositorys.LinxMicrovix
{
    public interface ILinxCstPisFiscalRepository
    {
        public Task<bool> InsertRecord(LinxAPIParam jobParameter, LinxCstPisFiscal? record);
        public bool BulkInsertIntoTableRaw(LinxAPIParam jobParameter, IList<LinxCstPisFiscal> records);
        public Task<IEnumerable<LinxCstPisFiscal>> GetRegistersExists(LinxAPIParam jobParameter, List<LinxCstPisFiscal> registros);
    }
}
