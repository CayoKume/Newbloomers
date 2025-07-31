using Domain.LinxMicrovix.Outbound.WebService.Models.LinxMicrovix;
using Domain.LinxMicrovix.Outbound.WebService.Entities.Parameters;

namespace Domain.LinxMicrovix.Outbound.WebService.Interfaces.Repositorys.LinxMicrovix
{
    public interface ILinxMetasVendedoresDiaRepository
    {
        public Task<bool> InsertRecord(LinxAPIParam jobParameter, LinxMetasVendedoresDia? record);
        public bool BulkInsertIntoTableRaw(LinxAPIParam jobParameter, IList<LinxMetasVendedoresDia> records);
        public Task<IEnumerable<LinxMetasVendedoresDia>> GetRegistersExists(LinxAPIParam jobParameter, List<LinxMetasVendedoresDia> registros);
    }
}
