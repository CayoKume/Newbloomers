using Domain.LinxMicrovix.Outbound.WebService.Entites.Parameters;
using Domain.LinxMicrovix.Outbound.WebService.Interfaces.Repositorys.LinxMicrovix;

namespace Domain.LinxMicrovix.Outbound.WebService.Entites.LinxMicrovix
{
    public class LinxConfiguracoesTributariasDetalhesRepository : ILinxConfiguracoesTributariasDetalhesRepository
    {
        public LinxConfiguracoesTributariasDetalhesRepository()
        {
            
        }

        public bool BulkInsertIntoTableRaw(LinxAPIParam jobParameter, IList<LinxConfiguracoesTributariasDetalhes> records)
        {
            throw new NotImplementedException();
        }

        public Task<List<LinxConfiguracoesTributariasDetalhes>> GetRegistersExists(LinxAPIParam jobParameter, List<LinxConfiguracoesTributariasDetalhes> registros)
        {
            throw new NotImplementedException();
        }

        public Task<bool> InsertRecord(LinxAPIParam jobParameter, LinxConfiguracoesTributariasDetalhes? record)
        {
            throw new NotImplementedException();
        }
    }
}
