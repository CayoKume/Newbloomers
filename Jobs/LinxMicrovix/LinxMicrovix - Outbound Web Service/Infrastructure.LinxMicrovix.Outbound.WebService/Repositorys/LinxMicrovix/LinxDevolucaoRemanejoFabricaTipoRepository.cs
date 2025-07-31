using Domain.LinxMicrovix.Outbound.WebService.Entities.Parameters;
using Domain.LinxMicrovix.Outbound.WebService.Interfaces.Repositorys.LinxMicrovix;
using Domain.LinxMicrovix.Outbound.WebService.Models.LinxMicrovix;

namespace Infrastructure.LinxMicrovix.Outbound.WebService.Repository.LinxMicrovix
{
    public class LinxDevolucaoRemanejoFabricaTipoRepository : ILinxDevolucaoRemanejoFabricaTipoRepository
    {
        public LinxDevolucaoRemanejoFabricaTipoRepository()
        {

        }

        public bool BulkInsertIntoTableRaw(LinxAPIParam jobParameter, IList<LinxDevolucaoRemanejoFabricaTipo> records)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<LinxDevolucaoRemanejoFabricaTipo>> GetRegistersExists(LinxAPIParam jobParameter, List<LinxDevolucaoRemanejoFabricaTipo> registros)
        {
            throw new NotImplementedException();
        }

        public Task<bool> InsertRecord(LinxAPIParam jobParameter, LinxDevolucaoRemanejoFabricaTipo? record)
        {
            throw new NotImplementedException();
        }
    }
}
