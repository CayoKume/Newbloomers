using Domain.LinxMicrovix.Outbound.WebService.Entites.LinxMicrovix;
using Domain.LinxMicrovix.Outbound.WebService.Entites.Parameters;

namespace Domain.LinxMicrovix.Outbound.WebService.Interfaces.Repositorys.LinxMicrovix
{
    public interface ILinxMetasVendedoresDiaRepository
    {
        public Task<bool> InsertRecord(LinxAPIParam jobParameter, LinxMetasVendedoresDia? record);
        public bool BulkInsertIntoTableRaw(LinxAPIParam jobParameter, IList<LinxMetasVendedoresDia> records);
        public Task<List<LinxMetasVendedoresDia>> GetRegistersExists(LinxAPIParam jobParameter, List<LinxMetasVendedoresDia> registros);
    }
}
