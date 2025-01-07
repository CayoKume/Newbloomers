using Domain.LinxMicrovix.Outbound.WebService.Entites.Parameters;
using Domain.LinxMicrovix.Outbound.WebService.Interfaces.Repositorys.LinxMicrovix;

namespace Domain.LinxMicrovix.Outbound.WebService.Entites.LinxMicrovix
{
    public class LinxConfiguracoesTributariasDetalhesSimplificadoRepository : ILinxConfiguracoesTributariasDetalhesSimplificadoRepository
    {
        public LinxConfiguracoesTributariasDetalhesSimplificadoRepository()
        {
            
        }

        public bool BulkInsertIntoTableRaw(LinxAPIParam jobParameter, IList<LinxConfiguracoesTributariasDetalhesSimplificado> records)
        {
            throw new NotImplementedException();
        }

        public Task<List<LinxConfiguracoesTributariasDetalhesSimplificado>> GetRegistersExists(LinxAPIParam jobParameter, List<LinxConfiguracoesTributariasDetalhesSimplificado> registros)
        {
            throw new NotImplementedException();
        }

        public Task<bool> InsertRecord(LinxAPIParam jobParameter, LinxConfiguracoesTributariasDetalhesSimplificado? record)
        {
            throw new NotImplementedException();
        }
    }
}
