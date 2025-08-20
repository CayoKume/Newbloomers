using Domain.LinxMicrovix.Outbound.WebService.Models.LinxMicrovix;
using Domain.LinxMicrovix.Outbound.WebService.Entities.Parameters;

namespace Domain.LinxMicrovix.Outbound.WebService.Interfaces.Repositorys.LinxMicrovix
{
    public interface ILinxProdutosInformacoesRepository
    {
        public Task<bool> InsertRecord(LinxAPIParam jobParameter, LinxProdutosInformacoes? record);
        public bool BulkInsertIntoTableRaw(LinxAPIParam jobParameter, IList<LinxProdutosInformacoes> records);
        public Task<IEnumerable<LinxProdutosInformacoes>> GetRegistersExists(LinxAPIParam jobParameter, List<LinxProdutosInformacoes> registros);
    }
}
