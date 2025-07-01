using Domain.LinxMicrovix.Outbound.WebService.Entities.Parameters;
using Domain.LinxMicrovix.Outbound.WebService.Interfaces.Repositorys.LinxMicrovix;
using Domain.LinxMicrovix.Outbound.WebService.Entities.LinxMicrovix;

namespace Infrastructure.LinxMicrovix.Outbound.WebService.Repository.LinxMicrovix
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

        public Task<IEnumerable<LinxCstPisFiscal>> GetRegistersExists(LinxAPIParam jobParameter, List<LinxCstPisFiscal> registros)
        {
            throw new NotImplementedException();
        }

        public Task<bool> InsertRecord(LinxAPIParam jobParameter, LinxCstPisFiscal? record)
        {
            throw new NotImplementedException();
        }
    }
}
