using Domain.LinxMicrovix.Outbound.WebService.Entites.Parameters;
using Domain.LinxMicrovix.Outbound.WebService.Interfaces.Repositorys.LinxMicrovix;

namespace Domain.LinxMicrovix.Outbound.WebService.Entites.LinxMicrovix
{
    public class LinxConfiguracoesTributariasEmpresasRepository : ILinxConfiguracoesTributariasEmpresasRepository
    {
        public LinxConfiguracoesTributariasEmpresasRepository()
        {
            
        }

        public bool BulkInsertIntoTableRaw(LinxAPIParam jobParameter, IList<LinxConfiguracoesTributariasEmpresas> records)
        {
            throw new NotImplementedException();
        }

        public Task<List<LinxConfiguracoesTributariasEmpresas>> GetRegistersExists(LinxAPIParam jobParameter, List<LinxConfiguracoesTributariasEmpresas> registros)
        {
            throw new NotImplementedException();
        }

        public Task<bool> InsertRecord(LinxAPIParam jobParameter, LinxConfiguracoesTributariasEmpresas? record)
        {
            throw new NotImplementedException();
        }
    }
}
