using Domain.LinxMicrovix.Outbound.WebService.Entites.Parameters;
using Domain.LinxMicrovix.Outbound.WebService.Interfaces.Repositorys.LinxMicrovix;

namespace Domain.LinxMicrovix.Outbound.WebService.Entites.LinxMicrovix
{
    public class LinxCstPisFiscalRepository : ILinxCstPisFiscalRepository
    {
        public LinxCstPisFiscalRepository()
        {
            
        }

        public bool BulkInsertIntoTableRaw(LinxAPIParam jobParameter, IList<LinxCstPisFiscal> records)
        {
            throw new NotImplementedException();
        }

        public Task<List<LinxCstPisFiscal>> GetRegistersExists(LinxAPIParam jobParameter, List<LinxCstPisFiscal> registros)
        {
            throw new NotImplementedException();
        }

        public Task<bool> InsertRecord(LinxAPIParam jobParameter, LinxCstPisFiscal? record)
        {
            throw new NotImplementedException();
        }
    }
}
