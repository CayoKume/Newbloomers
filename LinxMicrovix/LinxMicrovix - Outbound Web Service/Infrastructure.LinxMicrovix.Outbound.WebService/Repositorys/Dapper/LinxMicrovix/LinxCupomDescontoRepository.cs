using Domain.LinxMicrovix.Outbound.WebService.Entites.Parameters;
using Domain.LinxMicrovix.Outbound.WebService.Interfaces.Repositorys.LinxMicrovix;
using Domain.LinxMicrovix.Outbound.WebService.Entites.LinxMicrovix;

namespace Infrastructure.LinxMicrovix.Outbound.WebService.Repository.Dapper.LinxMicrovix
{
    public class LinxCupomDescontoRepository : ILinxCupomDescontoRepository
    {
        public LinxCupomDescontoRepository()
        {
            
        }

        public bool BulkInsertIntoTableRaw(LinxAPIParam jobParameter, IList<LinxCupomDesconto> records)
        {
            throw new NotImplementedException();
        }

        public Task<List<LinxCupomDesconto>> GetRegistersExists(LinxAPIParam jobParameter, List<LinxCupomDesconto> registros)
        {
            throw new NotImplementedException();
        }

        public Task<bool> InsertRecord(LinxAPIParam jobParameter, LinxCupomDesconto? record)
        {
            throw new NotImplementedException();
        }
    }
}
