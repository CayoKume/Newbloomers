using Domain.LinxMicrovix.Outbound.WebService.Entites.Parameters;
using Domain.LinxMicrovix.Outbound.WebService.Interfaces.Repositorys.LinxMicrovix;

namespace Domain.LinxMicrovix.Outbound.WebService.Entites.LinxMicrovix
{
    public class LinxOticoPrismaDescricaoRepository : ILinxOticoPrismaDescricaoRepository
    {
        public LinxOticoPrismaDescricaoRepository()
        {
            
        }

        public bool BulkInsertIntoTableRaw(LinxAPIParam jobParameter, IList<LinxOticoPrismaDescricao> records)
        {
            throw new NotImplementedException();
        }

        public Task<List<LinxOticoPrismaDescricao>> GetRegistersExists(LinxAPIParam jobParameter, List<LinxOticoPrismaDescricao> registros)
        {
            throw new NotImplementedException();
        }

        public Task<bool> InsertRecord(LinxAPIParam jobParameter, LinxOticoPrismaDescricao? record)
        {
            throw new NotImplementedException();
        }
    }
}
