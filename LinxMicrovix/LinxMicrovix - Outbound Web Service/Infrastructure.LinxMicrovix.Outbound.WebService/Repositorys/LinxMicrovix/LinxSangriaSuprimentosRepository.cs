using Domain.LinxMicrovix.Outbound.WebService.Entites.Parameters;
using Domain.LinxMicrovix.Outbound.WebService.Interfaces.Repositorys.LinxMicrovix;

namespace Domain.LinxMicrovix.Outbound.WebService.Entites.LinxMicrovix
{
    public class LinxSangriaSuprimentosRepository : ILinxSangriaSuprimentosRepository
    {
        public LinxSangriaSuprimentosRepository()
        {
            
        }

        public bool BulkInsertIntoTableRaw(LinxAPIParam jobParameter, IList<LinxSangriaSuprimentos> records)
        {
            throw new NotImplementedException();
        }

        public Task<List<LinxSangriaSuprimentos>> GetRegistersExists(LinxAPIParam jobParameter, List<LinxSangriaSuprimentos> registros)
        {
            throw new NotImplementedException();
        }

        public Task<bool> InsertRecord(LinxAPIParam jobParameter, LinxSangriaSuprimentos? record)
        {
            throw new NotImplementedException();
        }
    }
}
