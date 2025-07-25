using Domain.LinxMicrovix.Outbound.WebService.Entities.Parameters;
using Domain.LinxMicrovix.Outbound.WebService.Interfaces.Repositorys.LinxMicrovix;
using Domain.LinxMicrovix.Outbound.WebService.Models.LinxMicrovix;

namespace Infrastructure.LinxMicrovix.Outbound.WebService.Repository.LinxMicrovix
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

        public Task<IEnumerable<LinxOrdensServico>> GetRegistersExists(LinxAPIParam jobParameter, List<LinxOrdensServico> registros)
        {
            throw new NotImplementedException();
        }

        public Task<bool> InsertRecord(LinxAPIParam jobParameter, LinxOrdensServico? record)
        {
            throw new NotImplementedException();
        }
    }
}
