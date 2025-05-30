using Domain.LinxMicrovix.Outbound.WebService.Entities.Parameters;
using Domain.LinxMicrovix.Outbound.WebService.Interfaces.Repositorys.LinxMicrovix;
using Domain.LinxMicrovix.Outbound.WebService.Entities.LinxMicrovix;

namespace Infrastructure.LinxMicrovix.Outbound.WebService.Repository.Dapper.LinxMicrovix
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
