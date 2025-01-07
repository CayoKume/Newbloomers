using Domain.LinxMicrovix.Outbound.WebService.Entites.Parameters;
using Domain.LinxMicrovix.Outbound.WebService.Interfaces.Repositorys.LinxMicrovix;

namespace Domain.LinxMicrovix.Outbound.WebService.Entites.LinxMicrovix
{
    public class LinxProdutosCamposAdicionaisRepository : ILinxProdutosCamposAdicionaisRepository
    {
        public LinxProdutosCamposAdicionaisRepository()
        {
            
        }

        public bool BulkInsertIntoTableRaw(LinxAPIParam jobParameter, IList<LinxProdutosCamposAdicionais> records)
        {
            throw new NotImplementedException();
        }

        public Task<List<LinxProdutosCamposAdicionais>> GetRegistersExists(LinxAPIParam jobParameter, List<LinxProdutosCamposAdicionais> registros)
        {
            throw new NotImplementedException();
        }

        public Task<bool> InsertRecord(LinxAPIParam jobParameter, LinxProdutosCamposAdicionais? record)
        {
            throw new NotImplementedException();
        }
    }
}
