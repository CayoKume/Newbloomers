using Domain.LinxMicrovix.Outbound.WebService.Entites.LinxCommerce;
using Domain.LinxMicrovix.Outbound.WebService.Entites.Parameters;

namespace Domain.LinxMicrovix.Outbound.WebService.Interfaces.Repositorys.LinxCommerce
{
    public interface IB2CConsultaImagensRepository
    {
        public Task<bool> InsertRecord(LinxAPIParam jobParameter, B2CConsultaImagens? record);
        public bool BulkInsertIntoTableRaw(LinxAPIParam jobParameter, IList<B2CConsultaImagens> records);
        public Task<List<B2CConsultaImagens>> GetRegistersExists(LinxAPIParam jobParameter, List<B2CConsultaImagens> registros);
    }
}
