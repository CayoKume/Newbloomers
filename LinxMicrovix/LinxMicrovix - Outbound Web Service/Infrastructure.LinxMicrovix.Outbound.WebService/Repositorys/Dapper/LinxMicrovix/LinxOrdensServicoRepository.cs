using Domain.LinxMicrovix.Outbound.WebService.Entites.Parameters;
using Domain.LinxMicrovix.Outbound.WebService.Interfaces.Repositorys.LinxMicrovix;
using Domain.LinxMicrovix.Outbound.WebService.Entites.LinxMicrovix;

namespace Infrastructure.LinxMicrovix.Outbound.WebService.Repository.Dapper.LinxMicrovix
{
    public class LinxOrdensServicoRepository : ILinxOrdensServicoRepository
    {
        public LinxOrdensServicoRepository()
        {

        }

        public bool BulkInsertIntoTableRaw(LinxAPIParam jobParameter, IList<LinxOrdensServico> records)
        {
            throw new NotImplementedException();
        }

        public Task<List<LinxOrdensServico>> GetRegistersExists(LinxAPIParam jobParameter, List<LinxOrdensServico> registros)
        {
            throw new NotImplementedException();
        }

        public Task<bool> InsertRecord(LinxAPIParam jobParameter, LinxOrdensServico? record)
        {
            throw new NotImplementedException();
        }
    }
}
