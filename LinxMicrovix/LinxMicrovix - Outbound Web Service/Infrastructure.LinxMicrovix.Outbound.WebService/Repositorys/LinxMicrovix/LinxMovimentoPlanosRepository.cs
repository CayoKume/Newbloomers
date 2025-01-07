using Domain.LinxMicrovix.Outbound.WebService.Entites.Parameters;
using Domain.LinxMicrovix.Outbound.WebService.Interfaces.Repositorys.LinxMicrovix;

namespace Domain.LinxMicrovix.Outbound.WebService.Entites.LinxMicrovix
{
    public class LinxMovimentoPlanosRepository : ILinxMovimentoPlanosRepository
    {
        public LinxMovimentoPlanosRepository()
        {
            
        }

        public bool BulkInsertIntoTableRaw(LinxAPIParam jobParameter, IList<LinxMovimentoPlanos> records)
        {
            throw new NotImplementedException();
        }

        public Task<List<LinxMovimentoPlanos>> GetRegistersExists(LinxAPIParam jobParameter, List<LinxMovimentoPlanos> registros)
        {
            throw new NotImplementedException();
        }

        public Task<bool> InsertRecord(LinxAPIParam jobParameter, LinxMovimentoPlanos? record)
        {
            throw new NotImplementedException();
        }
    }
}
