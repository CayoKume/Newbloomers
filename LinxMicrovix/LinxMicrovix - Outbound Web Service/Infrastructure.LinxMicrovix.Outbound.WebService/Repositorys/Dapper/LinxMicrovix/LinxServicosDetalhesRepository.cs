using Domain.LinxMicrovix.Outbound.WebService.Entites.Parameters;
using Domain.LinxMicrovix.Outbound.WebService.Interfaces.Repositorys.LinxMicrovix;
using Domain.LinxMicrovix.Outbound.WebService.Entites.LinxMicrovix;

namespace Infrastructure.LinxMicrovix.Outbound.WebService.Repository.Dapper.LinxMicrovix
{
    public class LinxServicosDetalhesRepository : ILinxServicosDetalhesRepository
    {
        public LinxServicosDetalhesRepository()
        {
            
        }

        public bool BulkInsertIntoTableRaw(LinxAPIParam jobParameter, IList<LinxServicosDetalhes> records)
        {
            throw new NotImplementedException();
        }

        public Task<List<LinxServicosDetalhes>> GetRegistersExists(LinxAPIParam jobParameter, List<LinxServicosDetalhes> registros)
        {
            throw new NotImplementedException();
        }

        public Task<bool> InsertRecord(LinxAPIParam jobParameter, LinxServicosDetalhes? record)
        {
            throw new NotImplementedException();
        }
    }
}
