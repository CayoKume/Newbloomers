using Domain.LinxMicrovix.Outbound.WebService.Entities.Parameters;
using Domain.LinxMicrovix.Outbound.WebService.Interfaces.Repositorys.LinxMicrovix;
using Domain.LinxMicrovix.Outbound.WebService.Models.LinxMicrovix;

namespace Infrastructure.LinxMicrovix.Outbound.WebService.Repository.LinxMicrovix
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

        public Task<IEnumerable<LinxCategoriasFinanceiras>> GetRegistersExists(LinxAPIParam jobParameter, List<LinxCategoriasFinanceiras> registros)
        {
            throw new NotImplementedException();
        }

        public Task<bool> InsertRecord(LinxAPIParam jobParameter, LinxCategoriasFinanceiras? record)
        {
            throw new NotImplementedException();
        }
    }
}
