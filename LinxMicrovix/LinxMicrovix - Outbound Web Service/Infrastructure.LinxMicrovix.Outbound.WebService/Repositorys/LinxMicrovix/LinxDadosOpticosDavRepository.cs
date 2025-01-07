using Domain.LinxMicrovix.Outbound.WebService.Entites.Parameters;
using Domain.LinxMicrovix.Outbound.WebService.Interfaces.Repositorys.LinxMicrovix;

namespace Domain.LinxMicrovix.Outbound.WebService.Entites.LinxMicrovix
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

        public Task<List<LinxDadosOpticosDav>> GetRegistersExists(LinxAPIParam jobParameter, List<LinxDadosOpticosDav> registros)
        {
            throw new NotImplementedException();
        }

        public Task<bool> InsertRecord(LinxAPIParam jobParameter, LinxDadosOpticosDav? record)
        {
            throw new NotImplementedException();
        }
    }
}
