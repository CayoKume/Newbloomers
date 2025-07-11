using Domain.LinxMicrovix.Outbound.WebService.Entities.LinxCommerce;
using Domain.LinxMicrovix.Outbound.WebService.Entities.Parameters;

namespace Domain.LinxMicrovix.Outbound.WebService.Interfaces.Repositorys.LinxCommerce
{
    public interface IB2CConsultaProdutosCodebarRepository
    {
        public Task<bool> InsertRecord(LinxAPIParam jobParameter, B2CConsultaProdutosCodebar? record);
        public bool BulkInsertIntoTableRaw(LinxAPIParam jobParameter, IList<B2CConsultaProdutosCodebar> records);
        public Task<IEnumerable<string?>> GetRegistersExists(LinxAPIParam jobParameter, List<B2CConsultaProdutosCodebar> registros);
    }
}
