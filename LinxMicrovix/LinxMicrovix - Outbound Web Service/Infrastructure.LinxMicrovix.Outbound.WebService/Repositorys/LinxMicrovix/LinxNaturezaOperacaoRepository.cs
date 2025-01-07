using Domain.LinxMicrovix.Outbound.WebService.Entites.Parameters;
using Domain.LinxMicrovix.Outbound.WebService.Interfaces.Repositorys.LinxMicrovix;

namespace Domain.LinxMicrovix.Outbound.WebService.Entites.LinxMicrovix
{
    public class LinxNaturezaOperacaoRepository : ILinxNaturezaOperacaoRepository
    {
        public LinxNaturezaOperacaoRepository()
        {
            
        }

        public bool BulkInsertIntoTableRaw(LinxAPIParam jobParameter, IList<LinxNaturezaOperacao> records)
        {
            throw new NotImplementedException();
        }

        public Task<List<LinxNaturezaOperacao>> GetRegistersExists(LinxAPIParam jobParameter, List<LinxNaturezaOperacao> registros)
        {
            throw new NotImplementedException();
        }

        public Task<bool> InsertRecord(LinxAPIParam jobParameter, LinxNaturezaOperacao? record)
        {
            throw new NotImplementedException();
        }
    }
}
