using Domain.LinxMicrovix.Outbound.WebService.Entites.Parameters;
using Domain.LinxMicrovix.Outbound.WebService.Entites.LinxCommerce;

namespace Domain.LinxMicrovix.Outbound.WebService.Interfaces.Repositorys.LinxCommerce
{
    public interface IB2CConsultaClassificacaoRepository
    {
        public Task<bool> InsertRecord(LinxAPIParam jobParameter, B2CConsultaClassificacao? record);
        public bool BulkInsertIntoTableRaw(LinxAPIParam jobParameter, IList<B2CConsultaClassificacao> records);
        public Task<List<B2CConsultaClassificacao>> GetRegistersExists(LinxAPIParam jobParameter, List<B2CConsultaClassificacao> registros);
    }
}
