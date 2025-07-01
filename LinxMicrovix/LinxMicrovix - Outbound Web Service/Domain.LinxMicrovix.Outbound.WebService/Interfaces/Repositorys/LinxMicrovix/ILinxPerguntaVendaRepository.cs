using Domain.LinxMicrovix.Outbound.WebService.Entities.LinxMicrovix;
using Domain.LinxMicrovix.Outbound.WebService.Entities.Parameters;

namespace Domain.LinxMicrovix.Outbound.WebService.Interfaces.Repositorys.LinxMicrovix
{
    public interface ILinxPerguntaVendaRepository
    {
        public Task<bool> InsertRecord(LinxAPIParam jobParameter, LinxPerguntaVenda? record);
        public bool BulkInsertIntoTableRaw(LinxAPIParam jobParameter, IList<LinxPerguntaVenda> records);
        public Task<IEnumerable<LinxPerguntaVenda>> GetRegistersExists(LinxAPIParam jobParameter, List<LinxPerguntaVenda> registros);
    }
}
