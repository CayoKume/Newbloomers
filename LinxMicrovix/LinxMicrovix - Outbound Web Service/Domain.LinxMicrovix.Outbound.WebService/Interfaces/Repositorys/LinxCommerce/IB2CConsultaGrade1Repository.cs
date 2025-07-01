using Domain.LinxMicrovix.Outbound.WebService.Entities.LinxCommerce;
using Domain.LinxMicrovix.Outbound.WebService.Entities.Parameters;

namespace Domain.LinxMicrovix.Outbound.WebService.Interfaces.Repositorys.LinxCommerce
{
    public interface IB2CConsultaGrade1Repository
    {
        public Task<bool> InsertRecord(LinxAPIParam jobParameter, B2CConsultaGrade1? record);
        public bool BulkInsertIntoTableRaw(LinxAPIParam jobParameter, IList<B2CConsultaGrade1> records);
        public Task<IEnumerable<B2CConsultaGrade1>> GetRegistersExists(LinxAPIParam jobParameter, List<B2CConsultaGrade1> registros);
    }
}
