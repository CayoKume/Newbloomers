using Domain.LinxMicrovix.Outbound.WebService.Entites.Parameters;
using Domain.LinxMicrovix.Outbound.WebService.Interfaces.Repositorys.LinxMicrovix;

namespace Domain.LinxMicrovix.Outbound.WebService.Entites.LinxMicrovix
{
    public class LinxCategoriasFinanceirasRepository : ILinxCategoriasFinanceirasRepository
    {
        public LinxCategoriasFinanceirasRepository()
        {
            
        }

        public bool BulkInsertIntoTableRaw(LinxAPIParam jobParameter, IList<LinxCategoriasFinanceiras> records)
        {
            throw new NotImplementedException();
        }

        public Task<List<LinxCategoriasFinanceiras>> GetRegistersExists(LinxAPIParam jobParameter, List<LinxCategoriasFinanceiras> registros)
        {
            throw new NotImplementedException();
        }

        public Task<bool> InsertRecord(LinxAPIParam jobParameter, LinxCategoriasFinanceiras? record)
        {
            throw new NotImplementedException();
        }
    }
}
