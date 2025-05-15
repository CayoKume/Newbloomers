using Domain.LinxMicrovix.Outbound.WebService.Entites.Parameters;
using Domain.LinxMicrovix.Outbound.WebService.Interfaces.Repositorys.LinxMicrovix;
using Domain.LinxMicrovix.Outbound.WebService.Entites.LinxMicrovix;

namespace Infrastructure.LinxMicrovix.Outbound.WebService.Repository.Dapper.LinxMicrovix
{
    public class LinxMovimentoExtensaoRepository : ILinxMovimentoExtensaoRepository
    {
        public LinxMovimentoExtensaoRepository()
        {
            
        }

        public bool BulkInsertIntoTableRaw(LinxAPIParam jobParameter, IList<LinxMovimentoExtensao> records)
        {
            throw new NotImplementedException();
        }

        public Task<List<LinxMovimentoExtensao>> GetRegistersExists(LinxAPIParam jobParameter, List<LinxMovimentoExtensao> registros)
        {
            throw new NotImplementedException();
        }

        public Task<bool> InsertRecord(LinxAPIParam jobParameter, LinxMovimentoExtensao? record)
        {
            throw new NotImplementedException();
        }
    }
}
