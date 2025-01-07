using Domain.LinxMicrovix.Outbound.WebService.Entites.Parameters;
using Domain.LinxMicrovix.Outbound.WebService.Interfaces.Repositorys.LinxMicrovix;

namespace Domain.LinxMicrovix.Outbound.WebService.Entites.LinxMicrovix
{
    public class LinxDevolucaoRemanejoFabricaItemRepository : ILinxDevolucaoRemanejoFabricaItemRepository
    {
        public LinxDevolucaoRemanejoFabricaItemRepository()
        {
            
        }

        public bool BulkInsertIntoTableRaw(LinxAPIParam jobParameter, IList<LinxDevolucaoRemanejoFabricaItem> records)
        {
            throw new NotImplementedException();
        }

        public Task<List<LinxDevolucaoRemanejoFabricaItem>> GetRegistersExists(LinxAPIParam jobParameter, List<LinxDevolucaoRemanejoFabricaItem> registros)
        {
            throw new NotImplementedException();
        }

        public Task<bool> InsertRecord(LinxAPIParam jobParameter, LinxDevolucaoRemanejoFabricaItem? record)
        {
            throw new NotImplementedException();
        }
    }
}
