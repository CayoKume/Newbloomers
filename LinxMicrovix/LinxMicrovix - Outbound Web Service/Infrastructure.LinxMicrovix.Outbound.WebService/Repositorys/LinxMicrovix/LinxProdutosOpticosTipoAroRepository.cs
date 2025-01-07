using Domain.LinxMicrovix.Outbound.WebService.Entites.Parameters;
using Domain.LinxMicrovix.Outbound.WebService.Interfaces.Repositorys.LinxMicrovix;

namespace Domain.LinxMicrovix.Outbound.WebService.Entites.LinxMicrovix
{
    public class LinxProdutosOpticosTipoAroRepository : ILinxProdutosOpticosTipoAroRepository
    {
        public LinxProdutosOpticosTipoAroRepository()
        {
            
        }

        public bool BulkInsertIntoTableRaw(LinxAPIParam jobParameter, IList<LinxProdutosOpticosTipoAro> records)
        {
            throw new NotImplementedException();
        }

        public Task<List<LinxProdutosOpticosTipoAro>> GetRegistersExists(LinxAPIParam jobParameter, List<LinxProdutosOpticosTipoAro> registros)
        {
            throw new NotImplementedException();
        }

        public Task<bool> InsertRecord(LinxAPIParam jobParameter, LinxProdutosOpticosTipoAro? record)
        {
            throw new NotImplementedException();
        }
    }
}
