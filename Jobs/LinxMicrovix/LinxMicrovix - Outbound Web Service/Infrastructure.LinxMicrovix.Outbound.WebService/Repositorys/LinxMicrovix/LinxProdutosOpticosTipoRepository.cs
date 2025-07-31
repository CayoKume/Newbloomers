using Domain.LinxMicrovix.Outbound.WebService.Entities.Parameters;
using Domain.LinxMicrovix.Outbound.WebService.Interfaces.Repositorys.LinxMicrovix;
using Domain.LinxMicrovix.Outbound.WebService.Models.LinxMicrovix;

namespace Infrastructure.LinxMicrovix.Outbound.WebService.Repository.LinxMicrovix
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

        public Task<IEnumerable<LinxProdutosOpticosTipo>> GetRegistersExists(LinxAPIParam jobParameter, List<LinxProdutosOpticosTipo> registros)
        {
            throw new NotImplementedException();
        }

        public Task<bool> InsertRecord(LinxAPIParam jobParameter, LinxProdutosOpticosTipo? record)
        {
            throw new NotImplementedException();
        }
    }
}
