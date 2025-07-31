using Domain.LinxMicrovix.Outbound.WebService.Entities.Parameters;
using Domain.LinxMicrovix.Outbound.WebService.Interfaces.Repositorys.LinxMicrovix;
using Domain.LinxMicrovix.Outbound.WebService.Models.LinxMicrovix;

namespace Infrastructure.LinxMicrovix.Outbound.WebService.Repository.LinxMicrovix
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

        public Task<IEnumerable<LinxConfiguracoesTributariasEmpresas>> GetRegistersExists(LinxAPIParam jobParameter, List<LinxConfiguracoesTributariasEmpresas> registros)
        {
            throw new NotImplementedException();
        }

        public Task<bool> InsertRecord(LinxAPIParam jobParameter, LinxConfiguracoesTributariasEmpresas? record)
        {
            throw new NotImplementedException();
        }
    }
}
