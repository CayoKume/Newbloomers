using Domain.LinxMicrovix.Outbound.WebService.Models.LinxMicrovix;
using Domain.LinxMicrovix.Outbound.WebService.Entities.Parameters;

namespace Domain.LinxMicrovix.Outbound.WebService.Interfaces.Repositorys.LinxMicrovix
{
    public interface ILinxConfiguracoesTributariasEmpresasRepository
    {
        public Task<bool> InsertRecord(LinxAPIParam jobParameter, LinxConfiguracoesTributariasEmpresas? record);
        public bool BulkInsertIntoTableRaw(LinxAPIParam jobParameter, IList<LinxConfiguracoesTributariasEmpresas> records);
        public Task<IEnumerable<LinxConfiguracoesTributariasEmpresas>> GetRegistersExists(LinxAPIParam jobParameter, List<LinxConfiguracoesTributariasEmpresas> registros);
    }
}
