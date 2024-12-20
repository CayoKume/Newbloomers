using Domain.LinxMicrovix.Outbound.WebService.Entites.Parameters;
using Domain.LinxMicrovix.Outbound.WebService.Entites.LinxCommerce;

namespace Domain.LinxMicrovix.Outbound.WebService.Interfaces.Repositorys.LinxCommerce
{
    public interface IB2CConsultaCNPJsChaveRepository
    {
        public Task<bool> InsertRecord(LinxAPIParam jobParameter, B2CConsultaCNPJsChave? record);
        public bool BulkInsertIntoTableRaw(LinxAPIParam jobParameter, IList<B2CConsultaCNPJsChave> records);
        public Task<List<B2CConsultaCNPJsChave>> GetRegistersExists(LinxAPIParam jobParameter, List<B2CConsultaCNPJsChave> registros);
    }
}
