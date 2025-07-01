using Domain.LinxMicrovix.Outbound.WebService.Entities.Parameters;
using Domain.LinxMicrovix.Outbound.WebService.Interfaces.Repositorys.LinxMicrovix;
using Domain.LinxMicrovix.Outbound.WebService.Entities.LinxMicrovix;

namespace Infrastructure.LinxMicrovix.Outbound.WebService.Repository.LinxMicrovix
{
    public class LinxProdutosSerialRepository : ILinxProdutosSerialRepository
    {
        public LinxProdutosSerialRepository()
        {

        }

        public bool BulkInsertIntoTableRaw(LinxAPIParam jobParameter, IList<LinxProdutosSerial> records)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<LinxProdutosSerial>> GetRegistersExists(LinxAPIParam jobParameter, List<LinxProdutosSerial> registros)
        {
            throw new NotImplementedException();
        }

        public Task<bool> InsertRecord(LinxAPIParam jobParameter, LinxProdutosSerial? record)
        {
            throw new NotImplementedException();
        }
    }
}
