using Domain.LinxMicrovix.Outbound.WebService.Entites.Parameters;
using Domain.LinxMicrovix.Outbound.WebService.Interfaces.Repositorys.LinxMicrovix;

namespace Domain.LinxMicrovix.Outbound.WebService.Entites.LinxMicrovix
{
    public class LinxMetasVendedoresDiaRepository : ILinxMetasVendedoresDiaRepository
    {
        public LinxMetasVendedoresDiaRepository()
        {
            
        }

        public bool BulkInsertIntoTableRaw(LinxAPIParam jobParameter, IList<LinxMetasVendedoresDia> records)
        {
            throw new NotImplementedException();
        }

        public Task<List<LinxMetasVendedoresDia>> GetRegistersExists(LinxAPIParam jobParameter, List<LinxMetasVendedoresDia> registros)
        {
            throw new NotImplementedException();
        }

        public Task<bool> InsertRecord(LinxAPIParam jobParameter, LinxMetasVendedoresDia? record)
        {
            throw new NotImplementedException();
        }
    }
}
