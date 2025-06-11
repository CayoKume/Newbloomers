using Domain.LinxMicrovix.Outbound.WebService.Entities.Parameters;
using Domain.LinxMicrovix.Outbound.WebService.Interfaces.Repositorys.LinxMicrovix;
using Domain.LinxMicrovix.Outbound.WebService.Entities.LinxMicrovix;

namespace Infrastructure.LinxMicrovix.Outbound.WebService.Repository.LinxMicrovix
{
    public class LinxEnquadramentoIpiRepository : ILinxEnquadramentoIpiRepository
    {
        public LinxEnquadramentoIpiRepository()
        {

        }

        public bool BulkInsertIntoTableRaw(LinxAPIParam jobParameter, IList<LinxEnquadramentoIpi> records)
        {
            throw new NotImplementedException();
        }

        public Task<List<LinxEnquadramentoIpi>> GetRegistersExists(LinxAPIParam jobParameter, List<LinxEnquadramentoIpi> registros)
        {
            throw new NotImplementedException();
        }

        public Task<bool> InsertRecord(LinxAPIParam jobParameter, LinxEnquadramentoIpi? record)
        {
            throw new NotImplementedException();
        }
    }
}
