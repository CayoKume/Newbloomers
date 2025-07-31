using Domain.LinxMicrovix.Outbound.WebService.Entities.Parameters;
using Domain.LinxMicrovix.Outbound.WebService.Interfaces.Repositorys.LinxMicrovix;
using Domain.LinxMicrovix.Outbound.WebService.Models.LinxMicrovix;

namespace Infrastructure.LinxMicrovix.Outbound.WebService.Repository.LinxMicrovix
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

        public Task<IEnumerable<LinxProdutosOpticosFormatoAro>> GetRegistersExists(LinxAPIParam jobParameter, List<LinxProdutosOpticosFormatoAro> registros)
        {
            throw new NotImplementedException();
        }

        public Task<bool> InsertRecord(LinxAPIParam jobParameter, LinxProdutosOpticosFormatoAro? record)
        {
            throw new NotImplementedException();
        }
    }
}
