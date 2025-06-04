using Domain.LinxMicrovix.Outbound.WebService.Entities.Parameters;
using Domain.LinxMicrovix.Outbound.WebService.Interfaces.Repositorys.LinxMicrovix;
using Domain.LinxMicrovix.Outbound.WebService.Entities.LinxMicrovix;

namespace Infrastructure.LinxMicrovix.Outbound.WebService.Repository.Dapper.LinxMicrovix
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
