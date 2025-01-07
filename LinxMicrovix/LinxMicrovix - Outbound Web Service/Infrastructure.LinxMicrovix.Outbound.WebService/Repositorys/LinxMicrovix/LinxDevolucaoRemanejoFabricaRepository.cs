using Domain.LinxMicrovix.Outbound.WebService.Entites.Parameters;
using Domain.LinxMicrovix.Outbound.WebService.Interfaces.Repositorys.LinxMicrovix;

namespace Domain.LinxMicrovix.Outbound.WebService.Entites.LinxMicrovix
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

        public Task<List<LinxDevolucaoRemanejoFabrica>> GetRegistersExists(LinxAPIParam jobParameter, List<LinxDevolucaoRemanejoFabrica> registros)
        {
            throw new NotImplementedException();
        }

        public Task<bool> InsertRecord(LinxAPIParam jobParameter, LinxDevolucaoRemanejoFabrica? record)
        {
            throw new NotImplementedException();
        }
    }
}
