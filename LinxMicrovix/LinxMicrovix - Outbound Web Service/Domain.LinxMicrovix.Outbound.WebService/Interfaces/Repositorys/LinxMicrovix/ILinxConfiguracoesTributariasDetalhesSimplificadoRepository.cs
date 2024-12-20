using Domain.LinxMicrovix.Outbound.WebService.Entites.LinxMicrovix;
using Domain.LinxMicrovix.Outbound.WebService.Entites.Parameters;

namespace Domain.LinxMicrovix.Outbound.WebService.Interfaces.Repositorys.LinxMicrovix
{
    public interface ILinxConfiguracoesTributariasDetalhesSimplificadoRepository
    {
        public Task<bool> InsertRecord(LinxAPIParam jobParameter, LinxConfiguracoesTributariasDetalhesSimplificado? record);
        public bool BulkInsertIntoTableRaw(LinxAPIParam jobParameter, IList<LinxConfiguracoesTributariasDetalhesSimplificado> records);
        public Task<List<LinxConfiguracoesTributariasDetalhesSimplificado>> GetRegistersExists(LinxAPIParam jobParameter, List<LinxConfiguracoesTributariasDetalhesSimplificado> registros);
    }
}
