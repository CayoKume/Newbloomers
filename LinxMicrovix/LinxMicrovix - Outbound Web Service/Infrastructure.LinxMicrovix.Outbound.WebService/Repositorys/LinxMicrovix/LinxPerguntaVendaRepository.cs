using Domain.LinxMicrovix.Outbound.WebService.Entities.Parameters;
using Domain.LinxMicrovix.Outbound.WebService.Interfaces.Repositorys.LinxMicrovix;
using Domain.LinxMicrovix.Outbound.WebService.Models.LinxMicrovix;

namespace Infrastructure.LinxMicrovix.Outbound.WebService.Repository.LinxMicrovix
{
    public class LinxPerguntaVendaRepository : ILinxPerguntaVendaRepository
    {
        public LinxPerguntaVendaRepository()
        {

        }

        public bool BulkInsertIntoTableRaw(LinxAPIParam jobParameter, IList<LinxPerguntaVenda> records)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<LinxPerguntaVenda>> GetRegistersExists(LinxAPIParam jobParameter, List<LinxPerguntaVenda> registros)
        {
            throw new NotImplementedException();
        }

        public Task<bool> InsertRecord(LinxAPIParam jobParameter, LinxPerguntaVenda? record)
        {
            throw new NotImplementedException();
        }
    }
}
