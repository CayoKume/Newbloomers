using Domain.LinxMicrovix.Outbound.WebService.Entities.Parameters;
using Domain.LinxMicrovix.Outbound.WebService.Interfaces.Repositorys.LinxMicrovix;
using Domain.LinxMicrovix.Outbound.WebService.Entities.LinxMicrovix;

namespace Infrastructure.LinxMicrovix.Outbound.WebService.Repository.LinxMicrovix
{
    public class LinxTamanhosRepository : ILinxTamanhosRepository
    {
        public LinxTamanhosRepository()
        {

        }

        public bool BulkInsertIntoTableRaw(LinxAPIParam jobParameter, IList<LinxTamanhos> records)
        {
            throw new NotImplementedException();
        }

        public Task<List<LinxTamanhos>> GetRegistersExists(LinxAPIParam jobParameter, List<LinxTamanhos> registros)
        {
            throw new NotImplementedException();
        }

        public Task<bool> InsertRecord(LinxAPIParam jobParameter, LinxTamanhos? record)
        {
            throw new NotImplementedException();
        }
    }
}
