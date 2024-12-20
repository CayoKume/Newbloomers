using Domain.LinxMicrovix.Outbound.WebService.Entites.Parameters;
using Domain.LinxMicrovix.Outbound.WebService.Entites.LinxCommerce;

namespace Domain.LinxMicrovix.Outbound.WebService.Interfaces.Repositorys.LinxCommerce
{
    public interface IB2CConsultaProdutosTabelasPrecosRepository
    {
        public Task<bool> InsertRecord(LinxAPIParam jobParameter, B2CConsultaProdutosTabelasPrecos? record);
        public bool BulkInsertIntoTableRaw(LinxAPIParam jobParameter, IList<B2CConsultaProdutosTabelasPrecos> records);
        public Task<List<B2CConsultaProdutosTabelasPrecos>> GetRegistersExists(LinxAPIParam jobParameter, List<B2CConsultaProdutosTabelasPrecos> registros);
    }
}
