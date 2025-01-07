using Domain.LinxMicrovix.Outbound.WebService.Entites.Parameters;
using Domain.LinxMicrovix.Outbound.WebService.Interfaces.Repositorys.LinxMicrovix;

namespace Domain.LinxMicrovix.Outbound.WebService.Entites.LinxMicrovix
{
    public class LinxMotivoDevolucaoRepository : ILinxMotivoDevolucaoRepository
    {
        public LinxMotivoDevolucaoRepository()
        {
            
        }

        public bool BulkInsertIntoTableRaw(LinxAPIParam jobParameter, IList<LinxMotivoDevolucao> records)
        {
            throw new NotImplementedException();
        }

        public Task<List<LinxMotivoDevolucao>> GetRegistersExists(LinxAPIParam jobParameter, List<LinxMotivoDevolucao> registros)
        {
            throw new NotImplementedException();
        }

        public Task<bool> InsertRecord(LinxAPIParam jobParameter, LinxMotivoDevolucao? record)
        {
            throw new NotImplementedException();
        }
    }
}
