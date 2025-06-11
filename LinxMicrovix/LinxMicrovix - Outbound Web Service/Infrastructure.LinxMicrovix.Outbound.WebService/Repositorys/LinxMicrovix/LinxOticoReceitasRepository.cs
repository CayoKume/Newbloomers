using Domain.LinxMicrovix.Outbound.WebService.Entities.Parameters;
using Domain.LinxMicrovix.Outbound.WebService.Interfaces.Repositorys.LinxMicrovix;
using Domain.LinxMicrovix.Outbound.WebService.Entities.LinxMicrovix;

namespace Infrastructure.LinxMicrovix.Outbound.WebService.Repository.LinxMicrovix
{
    public class LinxOticoReceitasRepository : ILinxOticoReceitasRepository
    {
        public LinxOticoReceitasRepository()
        {

        }

        public bool BulkInsertIntoTableRaw(LinxAPIParam jobParameter, IList<LinxOticoReceitas> records)
        {
            throw new NotImplementedException();
        }

        public Task<List<LinxOticoReceitas>> GetRegistersExists(LinxAPIParam jobParameter, List<LinxOticoReceitas> registros)
        {
            throw new NotImplementedException();
        }

        public Task<bool> InsertRecord(LinxAPIParam jobParameter, LinxOticoReceitas? record)
        {
            throw new NotImplementedException();
        }
    }
}
