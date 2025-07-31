using Domain.LinxMicrovix.Outbound.WebService.Models.LinxMicrovix;
using Domain.LinxMicrovix.Outbound.WebService.Entities.Parameters;

namespace Domain.LinxMicrovix.Outbound.WebService.Interfaces.Repositorys.LinxMicrovix
{
    public interface ILinxServicosDetalhesRepository
    {
        public Task<bool> InsertRecord(LinxAPIParam jobParameter, LinxServicosDetalhes? record);
        public bool BulkInsertIntoTableRaw(LinxAPIParam jobParameter, IList<LinxServicosDetalhes> records);
        public Task<IEnumerable<LinxServicosDetalhes>> GetRegistersExists(LinxAPIParam jobParameter, List<LinxServicosDetalhes> registros);
    }
}
