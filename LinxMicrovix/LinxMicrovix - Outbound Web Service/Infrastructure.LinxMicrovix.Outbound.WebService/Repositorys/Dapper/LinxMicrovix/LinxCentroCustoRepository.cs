using Domain.LinxMicrovix.Outbound.WebService.Entites.Parameters;
using Domain.LinxMicrovix.Outbound.WebService.Interfaces.Repositorys.LinxMicrovix;
using Domain.LinxMicrovix.Outbound.WebService.Entites.LinxMicrovix;

namespace Infrastructure.LinxMicrovix.Outbound.WebService.Repository.Dapper.LinxMicrovix
{
    public class LinxCentroCustoRepository : ILinxCentroCustoRepository
    {
        public LinxCentroCustoRepository()
        {
            
        }

        public bool BulkInsertIntoTableRaw(LinxAPIParam jobParameter, IList<LinxCentroCusto> records)
        {
            throw new NotImplementedException();
        }

        public Task<List<LinxCentroCusto>> GetRegistersExists(LinxAPIParam jobParameter, List<LinxCentroCusto> registros)
        {
            throw new NotImplementedException();
        }

        public Task<bool> InsertRecord(LinxAPIParam jobParameter, LinxCentroCusto? record)
        {
            throw new NotImplementedException();
        }
    }
}
