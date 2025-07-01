using Domain.LinxMicrovix.Outbound.WebService.Entities.Parameters;
using Domain.LinxMicrovix.Outbound.WebService.Interfaces.Repositorys.LinxMicrovix;
using Domain.LinxMicrovix.Outbound.WebService.Entities.LinxMicrovix;

namespace Infrastructure.LinxMicrovix.Outbound.WebService.Repository.LinxMicrovix
{
    public class LinxClientesFornecCamposAdicionaisRepository : ILinxClientesFornecCamposAdicionaisRepository
    {
        public LinxClientesFornecCamposAdicionaisRepository()
        {

        }

        public bool BulkInsertIntoTableRaw(LinxAPIParam jobParameter, IList<LinxClientesFornecCamposAdicionais> records)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<LinxClientesFornecCamposAdicionais>> GetRegistersExists(LinxAPIParam jobParameter, List<LinxClientesFornecCamposAdicionais> registros)
        {
            throw new NotImplementedException();
        }

        public Task<bool> InsertRecord(LinxAPIParam jobParameter, LinxClientesFornecCamposAdicionais? record)
        {
            throw new NotImplementedException();
        }
    }
}
