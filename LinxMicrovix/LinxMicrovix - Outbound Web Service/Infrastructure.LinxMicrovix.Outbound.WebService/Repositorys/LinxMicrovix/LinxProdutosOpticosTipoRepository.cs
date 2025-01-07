using Domain.LinxMicrovix.Outbound.WebService.Entites.Parameters;
using Domain.LinxMicrovix.Outbound.WebService.Interfaces.Repositorys.LinxMicrovix;

namespace Domain.LinxMicrovix.Outbound.WebService.Entites.LinxMicrovix
{
    public class LinxProdutosOpticosTipoRepository : ILinxProdutosOpticosTipoRepository
    {
        public LinxProdutosOpticosTipoRepository()
        {
            
        }

        public bool BulkInsertIntoTableRaw(LinxAPIParam jobParameter, IList<LinxProdutosOpticosTipo> records)
        {
            throw new NotImplementedException();
        }

        public Task<List<LinxProdutosOpticosTipo>> GetRegistersExists(LinxAPIParam jobParameter, List<LinxProdutosOpticosTipo> registros)
        {
            throw new NotImplementedException();
        }

        public Task<bool> InsertRecord(LinxAPIParam jobParameter, LinxProdutosOpticosTipo? record)
        {
            throw new NotImplementedException();
        }
    }
}
