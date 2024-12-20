using Domain.LinxMicrovix.Outbound.WebService.Entites.LinxMicrovix;
using Domain.LinxMicrovix.Outbound.WebService.Entites.Parameters;

namespace Domain.LinxMicrovix.Outbound.WebService.Interfaces.Repositorys.LinxMicrovix
{
    public interface ILinxOticoReceitasRepository
    {
        public Task<bool> InsertRecord(LinxAPIParam jobParameter, LinxOticoReceitas? record);
        public bool BulkInsertIntoTableRaw(LinxAPIParam jobParameter, IList<LinxOticoReceitas> records);
        public Task<List<LinxOticoReceitas>> GetRegistersExists(LinxAPIParam jobParameter, List<LinxOticoReceitas> registros);
    }
}
