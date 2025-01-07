using Domain.LinxMicrovix.Outbound.WebService.Entites.Parameters;
using Domain.LinxMicrovix.Outbound.WebService.Interfaces.Repositorys.LinxMicrovix;

namespace Domain.LinxMicrovix.Outbound.WebService.Entites.LinxMicrovix
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

        public Task<List<LinxMovimentoReshop>> GetRegistersExists(LinxAPIParam jobParameter, List<LinxMovimentoReshop> registros)
        {
            throw new NotImplementedException();
        }

        public Task<bool> InsertRecord(LinxAPIParam jobParameter, LinxMovimentoReshop? record)
        {
            throw new NotImplementedException();
        }
    }
}
