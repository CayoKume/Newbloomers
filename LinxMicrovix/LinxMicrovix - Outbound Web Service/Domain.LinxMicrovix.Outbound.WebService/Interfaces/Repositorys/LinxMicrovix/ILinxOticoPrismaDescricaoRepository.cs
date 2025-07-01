using Domain.LinxMicrovix.Outbound.WebService.Entities.LinxMicrovix;
using Domain.LinxMicrovix.Outbound.WebService.Entities.Parameters;

namespace Domain.LinxMicrovix.Outbound.WebService.Interfaces.Repositorys.LinxMicrovix
{
    public interface ILinxOticoPrismaDescricaoRepository
    {
        public Task<bool> InsertRecord(LinxAPIParam jobParameter, LinxOticoPrismaDescricao? record);
        public bool BulkInsertIntoTableRaw(LinxAPIParam jobParameter, IList<LinxOticoPrismaDescricao> records);
        public Task<IEnumerable<LinxOticoPrismaDescricao>> GetRegistersExists(LinxAPIParam jobParameter, List<LinxOticoPrismaDescricao> registros);
    }
}
