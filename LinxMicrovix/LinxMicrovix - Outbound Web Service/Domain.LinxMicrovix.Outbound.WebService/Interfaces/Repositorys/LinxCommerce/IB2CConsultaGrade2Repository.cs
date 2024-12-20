using Domain.LinxMicrovix.Outbound.WebService.Entites.Parameters;
using Domain.LinxMicrovix.Outbound.WebService.Entites.LinxCommerce;

namespace Domain.LinxMicrovix.Outbound.WebService.Interfaces.Repositorys.LinxCommerce
{
    public interface IB2CConsultaGrade2Repository
    {
        public Task<bool> InsertRecord(LinxAPIParam jobParameter, B2CConsultaGrade2? record);
        public bool BulkInsertIntoTableRaw(LinxAPIParam jobParameter, IList<B2CConsultaGrade2> records);
        public Task<List<B2CConsultaGrade2>> GetRegistersExists(LinxAPIParam jobParameter, List<B2CConsultaGrade2> registros);
    }
}
