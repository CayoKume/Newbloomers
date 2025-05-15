using Domain.LinxMicrovix.Outbound.WebService.Entites.Parameters;
using Domain.LinxMicrovix.Outbound.WebService.Interfaces.Repositorys.LinxMicrovix;
using Domain.LinxMicrovix.Outbound.WebService.Entites.LinxMicrovix;

namespace Infrastructure.LinxMicrovix.Outbound.WebService.Repository.Dapper.LinxMicrovix
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
