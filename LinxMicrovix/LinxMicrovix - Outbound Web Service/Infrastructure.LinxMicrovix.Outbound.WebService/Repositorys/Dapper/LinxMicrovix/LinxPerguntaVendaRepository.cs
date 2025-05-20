using Domain.LinxMicrovix.Outbound.WebService.Entites.Parameters;
using Domain.LinxMicrovix.Outbound.WebService.Interfaces.Repositorys.LinxMicrovix;
using Domain.LinxMicrovix.Outbound.WebService.Entites.LinxMicrovix;

namespace Infrastructure.LinxMicrovix.Outbound.WebService.Repository.Dapper.LinxMicrovix
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

        public Task<List<LinxPerguntaVenda>> GetRegistersExists(LinxAPIParam jobParameter, List<LinxPerguntaVenda> registros)
        {
            throw new NotImplementedException();
        }

        public Task<bool> InsertRecord(LinxAPIParam jobParameter, LinxPerguntaVenda? record)
        {
            throw new NotImplementedException();
        }
    }
}
