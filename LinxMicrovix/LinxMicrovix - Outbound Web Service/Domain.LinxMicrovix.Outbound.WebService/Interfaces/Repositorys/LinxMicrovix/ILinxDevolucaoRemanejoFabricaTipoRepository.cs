using Domain.LinxMicrovix.Outbound.WebService.Entites.LinxMicrovix;
using Domain.LinxMicrovix.Outbound.WebService.Entites.Parameters;

namespace Domain.LinxMicrovix.Outbound.WebService.Interfaces.Repositorys.LinxMicrovix
{
    public interface ILinxDevolucaoRemanejoFabricaTipoRepository
    {
        public Task<bool> InsertRecord(LinxAPIParam jobParameter, LinxDevolucaoRemanejoFabricaTipo? record);
        public bool BulkInsertIntoTableRaw(LinxAPIParam jobParameter, IList<LinxDevolucaoRemanejoFabricaTipo> records);
        public Task<List<LinxDevolucaoRemanejoFabricaTipo>> GetRegistersExists(LinxAPIParam jobParameter, List<LinxDevolucaoRemanejoFabricaTipo> registros);
    }
}
