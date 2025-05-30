using Domain.LinxMicrovix.Outbound.WebService.Entities.LinxCommerce;
using Domain.LinxMicrovix.Outbound.WebService.Entities.Parameters;

namespace Domain.LinxMicrovix.Outbound.WebService.Interfaces.Repositorys.LinxCommerce
{
    public interface IB2CConsultaMarcasRepository
    {
        public Task<bool> InsertRecord(LinxAPIParam jobParameter, B2CConsultaMarcas? record);
        public bool BulkInsertIntoTableRaw(LinxAPIParam jobParameter, IList<B2CConsultaMarcas> records);
        public Task<List<B2CConsultaMarcas>> GetRegistersExists(LinxAPIParam jobParameter, List<B2CConsultaMarcas> registros);
    }
}
