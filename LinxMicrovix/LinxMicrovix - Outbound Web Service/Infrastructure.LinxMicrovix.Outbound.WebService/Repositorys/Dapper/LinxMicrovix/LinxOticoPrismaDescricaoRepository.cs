using Domain.LinxMicrovix.Outbound.WebService.Entites.Parameters;
using Domain.LinxMicrovix.Outbound.WebService.Interfaces.Repositorys.LinxMicrovix;
using Domain.LinxMicrovix.Outbound.WebService.Entites.LinxMicrovix;

namespace Infrastructure.LinxMicrovix.Outbound.WebService.Repository.Dapper.LinxMicrovix
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
