using Domain.LinxMicrovix.Outbound.WebService.Entites.Parameters;
using Domain.LinxMicrovix.Outbound.WebService.Interfaces.Repositorys.LinxMicrovix;
using Domain.LinxMicrovix.Outbound.WebService.Entites.LinxMicrovix;

namespace Infrastructure.LinxMicrovix.Outbound.WebService.Repository.Dapper.LinxMicrovix
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

        public Task<List<LinxClientesFornecCamposAdicionais>> GetRegistersExists(LinxAPIParam jobParameter, List<LinxClientesFornecCamposAdicionais> registros)
        {
            throw new NotImplementedException();
        }

        public Task<bool> InsertRecord(LinxAPIParam jobParameter, LinxClientesFornecCamposAdicionais? record)
        {
            throw new NotImplementedException();
        }
    }
}
