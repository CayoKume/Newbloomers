using Domain.LinxMicrovix.Outbound.WebService.Entities.Parameters;
using Domain.LinxMicrovix.Outbound.WebService.Interfaces.Repositorys.LinxMicrovix;
using Domain.LinxMicrovix.Outbound.WebService.Entities.LinxMicrovix;

namespace Infrastructure.LinxMicrovix.Outbound.WebService.Repository.LinxMicrovix
{
    public class LinxDadosOpticosDavRepository : ILinxDadosOpticosDavRepository
    {
        public LinxDadosOpticosDavRepository()
        {

        }

        public bool BulkInsertIntoTableRaw(LinxAPIParam jobParameter, IList<LinxDadosOpticosDav> records)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<LinxDadosOpticosDav>> GetRegistersExists(LinxAPIParam jobParameter, List<LinxDadosOpticosDav> registros)
        {
            throw new NotImplementedException();
        }

        public Task<bool> InsertRecord(LinxAPIParam jobParameter, LinxDadosOpticosDav? record)
        {
            throw new NotImplementedException();
        }
    }
}
