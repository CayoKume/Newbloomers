using Domain.LinxMicrovix.Outbound.WebService.Entites.Parameters;
using Domain.LinxMicrovix.Outbound.WebService.Interfaces.Repositorys.LinxMicrovix;
using Domain.LinxMicrovix.Outbound.WebService.Entites.LinxMicrovix;

namespace Infrastructure.LinxMicrovix.Outbound.WebService.Repository.Dapper.LinxMicrovix
{
    public class LinxProdutosInformacoesRepository : ILinxProdutosInformacoesRepository
    {
        public LinxProdutosInformacoesRepository()
        {
            
        }

        public bool BulkInsertIntoTableRaw(LinxAPIParam jobParameter, IList<LinxProdutosInformacoes> records)
        {
            throw new NotImplementedException();
        }

        public Task<List<LinxProdutosInformacoes>> GetRegistersExists(LinxAPIParam jobParameter, List<LinxProdutosInformacoes> registros)
        {
            throw new NotImplementedException();
        }

        public Task<bool> InsertRecord(LinxAPIParam jobParameter, LinxProdutosInformacoes? record)
        {
            throw new NotImplementedException();
        }
    }
}
