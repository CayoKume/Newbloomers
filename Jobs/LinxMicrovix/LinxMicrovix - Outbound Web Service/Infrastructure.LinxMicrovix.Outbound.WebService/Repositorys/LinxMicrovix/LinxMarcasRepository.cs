using Domain.LinxMicrovix.Outbound.WebService.Entities.Parameters;
using Domain.LinxMicrovix.Outbound.WebService.Interfaces.Repositorys.LinxMicrovix;
using Domain.LinxMicrovix.Outbound.WebService.Models.LinxMicrovix;

namespace Infrastructure.LinxMicrovix.Outbound.WebService.Repository.LinxMicrovix
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

        public Task<IEnumerable<LinxMarcas>> GetRegistersExists(LinxAPIParam jobParameter, List<LinxMarcas> registros)
        {
            throw new NotImplementedException();
        }

        public Task<bool> InsertRecord(LinxAPIParam jobParameter, LinxMarcas? record)
        {
            throw new NotImplementedException();
        }
    }
}
