using Domain.LinxMicrovix.Outbound.WebService.Entites.Parameters;
using Domain.LinxMicrovix.Outbound.WebService.Interfaces.Repositorys.LinxMicrovix;

namespace Domain.LinxMicrovix.Outbound.WebService.Entites.LinxMicrovix
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

        public Task<List<LinxProdutosSerial>> GetRegistersExists(LinxAPIParam jobParameter, List<LinxProdutosSerial> registros)
        {
            throw new NotImplementedException();
        }

        public Task<bool> InsertRecord(LinxAPIParam jobParameter, LinxProdutosSerial? record)
        {
            throw new NotImplementedException();
        }
    }
}
