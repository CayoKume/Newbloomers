using Domain.LinxMicrovix.Outbound.WebService.Entites.LinxMicrovix;
using Domain.LinxMicrovix.Outbound.WebService.Entites.Parameters;

namespace Domain.LinxMicrovix.Outbound.WebService.Interfaces.Repositorys.LinxMicrovix
{
    public interface ILinxDevolucaoRemanejoFabricaItemRepository
    {
        public Task<bool> InsertRecord(LinxAPIParam jobParameter, LinxDevolucaoRemanejoFabricaItem? record);
        public bool BulkInsertIntoTableRaw(LinxAPIParam jobParameter, IList<LinxDevolucaoRemanejoFabricaItem> records);
        public Task<List<LinxDevolucaoRemanejoFabricaItem>> GetRegistersExists(LinxAPIParam jobParameter, List<LinxDevolucaoRemanejoFabricaItem> registros);
    }
}
