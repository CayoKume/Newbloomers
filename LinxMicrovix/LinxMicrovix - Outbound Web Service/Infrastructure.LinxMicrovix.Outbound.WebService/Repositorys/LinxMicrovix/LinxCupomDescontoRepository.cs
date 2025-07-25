using Domain.LinxMicrovix.Outbound.WebService.Entities.Parameters;
using Domain.LinxMicrovix.Outbound.WebService.Interfaces.Repositorys.LinxMicrovix;
using Domain.LinxMicrovix.Outbound.WebService.Models.LinxMicrovix;

namespace Infrastructure.LinxMicrovix.Outbound.WebService.Repository.LinxMicrovix
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

        public Task<IEnumerable<LinxCupomDesconto>> GetRegistersExists(LinxAPIParam jobParameter, List<LinxCupomDesconto> registros)
        {
            throw new NotImplementedException();
        }

        public Task<bool> InsertRecord(LinxAPIParam jobParameter, LinxCupomDesconto? record)
        {
            throw new NotImplementedException();
        }
    }
}
