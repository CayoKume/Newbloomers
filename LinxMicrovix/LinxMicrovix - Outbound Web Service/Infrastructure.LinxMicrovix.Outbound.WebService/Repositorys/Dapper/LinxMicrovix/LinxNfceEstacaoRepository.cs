using Domain.LinxMicrovix.Outbound.WebService.Entities.Parameters;
using Domain.LinxMicrovix.Outbound.WebService.Interfaces.Repositorys.LinxMicrovix;
using Domain.LinxMicrovix.Outbound.WebService.Entities.LinxMicrovix;

namespace Infrastructure.LinxMicrovix.Outbound.WebService.Repository.Dapper.LinxMicrovix
{
    public class LinxNfceEstacaoRepository : ILinxNfceEstacaoRepository
    {
        public LinxNfceEstacaoRepository()
        {

        }

        public bool BulkInsertIntoTableRaw(LinxAPIParam jobParameter, IList<LinxNfceEstacao> records)
        {
            throw new NotImplementedException();
        }

        public Task<List<LinxNfceEstacao>> GetRegistersExists(LinxAPIParam jobParameter, List<LinxNfceEstacao> registros)
        {
            throw new NotImplementedException();
        }

        public Task<bool> InsertRecord(LinxAPIParam jobParameter, LinxNfceEstacao? record)
        {
            throw new NotImplementedException();
        }
    }
}
