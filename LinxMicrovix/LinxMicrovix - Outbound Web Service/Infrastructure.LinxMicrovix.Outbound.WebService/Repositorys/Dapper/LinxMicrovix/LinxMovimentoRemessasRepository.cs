using Domain.LinxMicrovix.Outbound.WebService.Entites.Parameters;
using Domain.LinxMicrovix.Outbound.WebService.Interfaces.Repositorys.LinxMicrovix;
using Domain.LinxMicrovix.Outbound.WebService.Entites.LinxMicrovix;

namespace Infrastructure.LinxMicrovix.Outbound.WebService.Repository.Dapper.LinxMicrovix
{
    public class LinxMovimentoRemessasRepository : ILinxMovimentoRemessasRepository
    {
        public LinxMovimentoRemessasRepository()
        {
            
        }

        public bool BulkInsertIntoTableRaw(LinxAPIParam jobParameter, IList<LinxMovimentoRemessas> records)
        {
            throw new NotImplementedException();
        }

        public Task<List<LinxMovimentoRemessas>> GetRegistersExists(LinxAPIParam jobParameter, List<LinxMovimentoRemessas> registros)
        {
            throw new NotImplementedException();
        }

        public Task<bool> InsertRecord(LinxAPIParam jobParameter, LinxMovimentoRemessas? record)
        {
            throw new NotImplementedException();
        }
    }
}
