using Domain.LinxMicrovix.Outbound.WebService.Entites.LinxMicrovix;
using Domain.LinxMicrovix.Outbound.WebService.Entites.Parameters;

namespace Domain.LinxMicrovix.Outbound.WebService.Interfaces.Repositorys.LinxMicrovix
{
    public interface ILinxNaturezaOperacaoRepository
    {
        public Task<bool> InsertRecord(LinxAPIParam jobParameter, LinxNaturezaOperacao? record);
        public bool BulkInsertIntoTableRaw(LinxAPIParam jobParameter, IList<LinxNaturezaOperacao> records);
        public Task<List<string?>> GetRegistersExists();
    }
}
