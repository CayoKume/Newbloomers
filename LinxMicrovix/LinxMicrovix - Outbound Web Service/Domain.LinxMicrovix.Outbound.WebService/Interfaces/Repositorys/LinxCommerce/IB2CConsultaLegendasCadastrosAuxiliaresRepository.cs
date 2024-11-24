using Domain.IntegrationsCore.Entities.Parameters;
using Domain.LinxMicrovix.Outbound.WebService.Entites.LinxCommerce;

namespace Domain.LinxMicrovix.Outbound.WebService.Interfaces.Repositorys.LinxCommerce
{
    public interface IB2CConsultaLegendasCadastrosAuxiliaresRepository
    {
        public Task<bool> InsertParametersIfNotExists(LinxMicrovixJobParameter jobParameter);
        public Task<bool> CreateTableMerge(LinxMicrovixJobParameter jobParameter);
        public bool BulkInsertIntoTableRaw(LinxMicrovixJobParameter jobParameter, IList<B2CConsultaLegendasCadastrosAuxiliares> records);
        public Task<List<B2CConsultaLegendasCadastrosAuxiliares>> GetRegistersExists(LinxMicrovixJobParameter jobParameter, List<B2CConsultaLegendasCadastrosAuxiliares> registros);

    }
}
