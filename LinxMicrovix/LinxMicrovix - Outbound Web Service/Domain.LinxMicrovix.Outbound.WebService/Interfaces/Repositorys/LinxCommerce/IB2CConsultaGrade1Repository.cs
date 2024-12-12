using Domain.LinxMicrovix.Outbound.WebService.Entites.Parameters;
using Domain.LinxMicrovix.Outbound.WebService.Entites.LinxCommerce;

namespace Domain.LinxMicrovix.Outbound.WebService.Interfaces.Repositorys.LinxCommerce
{
    public interface IB2CConsultaGrade1Repository
    {
        public Task<bool> InsertRecord(LinxAPIParam jobParameter, B2CConsultaGrade1? record);
        public Task<bool> InsertParametersIfNotExists(LinxAPIParam jobParameter);
        public Task<bool> CreateTableMerge(LinxAPIParam jobParameter);
        public bool BulkInsertIntoTableRaw(LinxAPIParam jobParameter, IList<B2CConsultaGrade1> records);
        public Task<List<B2CConsultaGrade1>> GetRegistersExists(LinxAPIParam jobParameter, List<B2CConsultaGrade1> registros);
    }
}
