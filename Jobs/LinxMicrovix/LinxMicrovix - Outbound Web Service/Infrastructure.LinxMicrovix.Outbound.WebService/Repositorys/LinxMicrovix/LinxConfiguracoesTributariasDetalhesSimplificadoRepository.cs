using Domain.LinxMicrovix.Outbound.WebService.Entities.Parameters;
using Domain.LinxMicrovix.Outbound.WebService.Interfaces.Repositorys.LinxMicrovix;
using Domain.LinxMicrovix.Outbound.WebService.Models.LinxMicrovix;

namespace Infrastructure.LinxMicrovix.Outbound.WebService.Repository.LinxMicrovix
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

        public Task<IEnumerable<LinxConfiguracoesTributariasDetalhesSimplificado>> GetRegistersExists(LinxAPIParam jobParameter, List<LinxConfiguracoesTributariasDetalhesSimplificado> registros)
        {
            throw new NotImplementedException();
        }

        public Task<bool> InsertRecord(LinxAPIParam jobParameter, LinxConfiguracoesTributariasDetalhesSimplificado? record)
        {
            throw new NotImplementedException();
        }
    }
}
