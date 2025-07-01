using Domain.LinxMicrovix.Outbound.WebService.Entities.Parameters;
using Domain.LinxMicrovix.Outbound.WebService.Interfaces.Repositorys.LinxMicrovix;
using Domain.LinxMicrovix.Outbound.WebService.Entities.LinxMicrovix;

namespace Infrastructure.LinxMicrovix.Outbound.WebService.Repository.LinxMicrovix
{
    public class LinxDevolucaoRemanejoFabricaRepository : ILinxDevolucaoRemanejoFabricaRepository
    {
        public LinxDevolucaoRemanejoFabricaRepository()
        {

        }

        public bool BulkInsertIntoTableRaw(LinxAPIParam jobParameter, IList<LinxDevolucaoRemanejoFabrica> records)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<LinxDevolucaoRemanejoFabrica>> GetRegistersExists(LinxAPIParam jobParameter, List<LinxDevolucaoRemanejoFabrica> registros)
        {
            throw new NotImplementedException();
        }

        public Task<bool> InsertRecord(LinxAPIParam jobParameter, LinxDevolucaoRemanejoFabrica? record)
        {
            throw new NotImplementedException();
        }
    }
}
