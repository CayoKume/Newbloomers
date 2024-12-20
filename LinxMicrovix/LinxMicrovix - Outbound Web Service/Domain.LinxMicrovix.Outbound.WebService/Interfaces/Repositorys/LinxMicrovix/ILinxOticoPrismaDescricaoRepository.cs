using Domain.LinxMicrovix.Outbound.WebService.Entites.LinxMicrovix;
using Domain.LinxMicrovix.Outbound.WebService.Entites.Parameters;

namespace Domain.LinxMicrovix.Outbound.WebService.Interfaces.Repositorys.LinxMicrovix
{
    public interface ILinxOticoPrismaDescricaoRepository
    {
        public Task<bool> InsertRecord(LinxAPIParam jobParameter, LinxOticoPrismaDescricao? record);
        public bool BulkInsertIntoTableRaw(LinxAPIParam jobParameter, IList<LinxOticoPrismaDescricao> records);
        public Task<List<LinxOticoPrismaDescricao>> GetRegistersExists(LinxAPIParam jobParameter, List<LinxOticoPrismaDescricao> registros);
    }
}
