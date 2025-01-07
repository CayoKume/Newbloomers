using Domain.LinxMicrovix.Outbound.WebService.Entites.Parameters;
using Domain.LinxMicrovix.Outbound.WebService.Interfaces.Repositorys.LinxMicrovix;

namespace Domain.LinxMicrovix.Outbound.WebService.Entites.LinxMicrovix
{
    public class LinxMovimentoTrocasRepository : ILinxMovimentoTrocasRepository
    {
        public LinxMovimentoTrocasRepository()
        {
            
        }

        public bool BulkInsertIntoTableRaw(LinxAPIParam jobParameter, IList<LinxMovimentoTrocas> records)
        {
            throw new NotImplementedException();
        }

        public Task<List<LinxMovimentoTrocas>> GetRegistersExists(LinxAPIParam jobParameter, List<LinxMovimentoTrocas> registros)
        {
            throw new NotImplementedException();
        }

        public Task<bool> InsertRecord(LinxAPIParam jobParameter, LinxMovimentoTrocas? record)
        {
            throw new NotImplementedException();
        }
    }
}
