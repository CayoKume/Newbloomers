using Domain.LinxMicrovix.Outbound.WebService.Entities.Parameters;
using Domain.LinxMicrovix.Outbound.WebService.Interfaces.Repositorys.LinxMicrovix;
using Domain.LinxMicrovix.Outbound.WebService.Models.LinxMicrovix;

namespace Infrastructure.LinxMicrovix.Outbound.WebService.Repository.LinxMicrovix
{
    public class LinxMovimentoReshopRepository : ILinxMovimentoReshopRepository
    {
        public LinxMovimentoReshopRepository()
        {

        }

        public bool BulkInsertIntoTableRaw(LinxAPIParam jobParameter, IList<LinxMovimentoReshop> records)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<LinxMovimentoReshop>> GetRegistersExists(LinxAPIParam jobParameter, List<LinxMovimentoReshop> registros)
        {
            throw new NotImplementedException();
        }

        public Task<bool> InsertRecord(LinxAPIParam jobParameter, LinxMovimentoReshop? record)
        {
            throw new NotImplementedException();
        }
    }
}
