using Domain.LinxMicrovix.Outbound.WebService.Entities.LinxCommerce;
using Domain.LinxMicrovix.Outbound.WebService.Entities.Parameters;

namespace Domain.LinxMicrovix.Outbound.WebService.Interfaces.Repositorys.LinxCommerce
{
    public interface IB2CConsultaProdutosStatusRepository
    {
        public Task<bool> InsertRecord(LinxAPIParam jobParameter, B2CConsultaProdutosStatus? record);
        public bool BulkInsertIntoTableRaw(LinxAPIParam jobParameter, IList<B2CConsultaProdutosStatus> records);
        public Task<IEnumerable<string?>> GetRegistersExists(LinxAPIParam jobParameter, IList<B2CConsultaProdutosStatus> registros);
    }
}
