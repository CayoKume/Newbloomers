using Domain.LinxMicrovix.Outbound.WebService.Entites.Parameters;
using Domain.LinxMicrovix.Outbound.WebService.Interfaces.Repositorys.LinxMicrovix;

namespace Domain.LinxMicrovix.Outbound.WebService.Entites.LinxMicrovix
{
    public class LinxMarcasRepository : ILinxMarcasRepository
    {
        public LinxMarcasRepository()
        {
            
        }

        public bool BulkInsertIntoTableRaw(LinxAPIParam jobParameter, IList<LinxMarcas> records)
        {
            throw new NotImplementedException();
        }

        public Task<List<LinxMarcas>> GetRegistersExists(LinxAPIParam jobParameter, List<LinxMarcas> registros)
        {
            throw new NotImplementedException();
        }

        public Task<bool> InsertRecord(LinxAPIParam jobParameter, LinxMarcas? record)
        {
            throw new NotImplementedException();
        }
    }
}
