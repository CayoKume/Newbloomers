using Domain.LinxMicrovix.Outbound.WebService.Entites.LinxCommerce;
using Domain.LinxMicrovix.Outbound.WebService.Entites.Parameters;

namespace Domain.LinxMicrovix.Outbound.WebService.Interfaces.Repositorys.LinxCommerce
{
    public interface IB2CConsultaPlanosParcelasRepository
    {
        public Task<bool> InsertRecord(LinxAPIParam jobParameter, B2CConsultaPlanosParcelas? record);
        public bool BulkInsertIntoTableRaw(LinxAPIParam jobParameter, IList<B2CConsultaPlanosParcelas> records);
        public Task<List<B2CConsultaPlanosParcelas>> GetRegistersExists(LinxAPIParam jobParameter, List<B2CConsultaPlanosParcelas> registros);
    }
}
