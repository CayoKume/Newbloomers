using Domain.LinxMicrovix.Outbound.WebService.Entites.Parameters;
using Domain.LinxMicrovix.Outbound.WebService.Interfaces.Repositorys.LinxMicrovix;

namespace Domain.LinxMicrovix.Outbound.WebService.Entites.LinxMicrovix
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
