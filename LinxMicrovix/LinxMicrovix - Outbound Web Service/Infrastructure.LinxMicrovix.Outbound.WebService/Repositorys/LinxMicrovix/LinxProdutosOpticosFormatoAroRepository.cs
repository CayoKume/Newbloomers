using Domain.LinxMicrovix.Outbound.WebService.Entites.Parameters;
using Domain.LinxMicrovix.Outbound.WebService.Interfaces.Repositorys.LinxMicrovix;

namespace Domain.LinxMicrovix.Outbound.WebService.Entites.LinxMicrovix
{
    public class LinxProdutosOpticosFormatoAroRepository : ILinxProdutosOpticosFormatoAroRepository
    {
        public LinxProdutosOpticosFormatoAroRepository()
        {
            
        }

        public bool BulkInsertIntoTableRaw(LinxAPIParam jobParameter, IList<LinxProdutosOpticosFormatoAro> records)
        {
            throw new NotImplementedException();
        }

        public Task<List<LinxProdutosOpticosFormatoAro>> GetRegistersExists(LinxAPIParam jobParameter, List<LinxProdutosOpticosFormatoAro> registros)
        {
            throw new NotImplementedException();
        }

        public Task<bool> InsertRecord(LinxAPIParam jobParameter, LinxProdutosOpticosFormatoAro? record)
        {
            throw new NotImplementedException();
        }
    }
}
