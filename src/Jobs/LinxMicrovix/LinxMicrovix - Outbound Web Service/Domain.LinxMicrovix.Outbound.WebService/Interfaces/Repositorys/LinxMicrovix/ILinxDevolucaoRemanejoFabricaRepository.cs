using Domain.LinxMicrovix.Outbound.WebService.Models.LinxMicrovix;
using Domain.LinxMicrovix.Outbound.WebService.Entities.Parameters;

namespace Domain.LinxMicrovix.Outbound.WebService.Interfaces.Repositorys.LinxMicrovix
{
    public interface ILinxDevolucaoRemanejoFabricaRepository
    {
        public Task<bool> InsertRecord(LinxAPIParam jobParameter, LinxDevolucaoRemanejoFabrica? record);
        public bool BulkInsertIntoTableRaw(LinxAPIParam jobParameter, IList<LinxDevolucaoRemanejoFabrica> records);
        public Task<IEnumerable<LinxDevolucaoRemanejoFabrica>> GetRegistersExists(LinxAPIParam jobParameter, List<LinxDevolucaoRemanejoFabrica> registros);
    }
}
