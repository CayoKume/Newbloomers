using Domain.LinxMicrovix.Outbound.WebService.Entities.Parameters;
using Domain.LinxMicrovix.Outbound.WebService.Interfaces.Repositorys.LinxMicrovix;
using Domain.LinxMicrovix.Outbound.WebService.Models.LinxMicrovix;

namespace Infrastructure.LinxMicrovix.Outbound.WebService.Repository.LinxMicrovix
{
    public class LinxDevolucaoRemanejoFabricaStatusRepository : ILinxDevolucaoRemanejoFabricaStatusRepository
    {
        public LinxDevolucaoRemanejoFabricaStatusRepository()
        {

        }

        public bool BulkInsertIntoTableRaw(LinxAPIParam jobParameter, IList<LinxDevolucaoRemanejoFabricaStatus> records)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<LinxDevolucaoRemanejoFabricaStatus>> GetRegistersExists(LinxAPIParam jobParameter, List<LinxDevolucaoRemanejoFabricaStatus> registros)
        {
            throw new NotImplementedException();
        }

        public Task<bool> InsertRecord(LinxAPIParam jobParameter, LinxDevolucaoRemanejoFabricaStatus? record)
        {
            throw new NotImplementedException();
        }
    }
}
