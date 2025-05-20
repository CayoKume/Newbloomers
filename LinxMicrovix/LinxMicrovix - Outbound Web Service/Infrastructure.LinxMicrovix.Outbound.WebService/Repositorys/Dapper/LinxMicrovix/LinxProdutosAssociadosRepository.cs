using Domain.LinxMicrovix.Outbound.WebService.Entites.Parameters;
using Domain.LinxMicrovix.Outbound.WebService.Interfaces.Repositorys.LinxMicrovix;
using Domain.LinxMicrovix.Outbound.WebService.Entites.LinxMicrovix;

namespace Infrastructure.LinxMicrovix.Outbound.WebService.Repository.Dapper.LinxMicrovix
{
    public class LinxProdutosAssociadosRepository : ILinxProdutosAssociadosRepository
    {
        public LinxProdutosAssociadosRepository()
        {

        }

        public bool BulkInsertIntoTableRaw(LinxAPIParam jobParameter, IList<LinxProdutosAssociados> records)
        {
            throw new NotImplementedException();
        }

        public Task<List<LinxProdutosAssociados>> GetRegistersExists(LinxAPIParam jobParameter, List<LinxProdutosAssociados> registros)
        {
            throw new NotImplementedException();
        }

        public Task<bool> InsertRecord(LinxAPIParam jobParameter, LinxProdutosAssociados? record)
        {
            throw new NotImplementedException();
        }
    }
}
