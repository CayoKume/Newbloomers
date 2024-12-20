using Domain.LinxMicrovix.Outbound.WebService.Entites.LinxMicrovix;
using Domain.LinxMicrovix.Outbound.WebService.Entites.Parameters;

namespace Domain.LinxMicrovix.Outbound.WebService.Interfaces.Repositorys.LinxMicrovix
{
    public interface ILinxSangriaSuprimentosRepository
    {
        public Task<bool> InsertRecord(LinxAPIParam jobParameter, LinxSangriaSuprimentos? record);
        public bool BulkInsertIntoTableRaw(LinxAPIParam jobParameter, IList<LinxSangriaSuprimentos> records);
        public Task<List<LinxSangriaSuprimentos>> GetRegistersExists(LinxAPIParam jobParameter, List<LinxSangriaSuprimentos> registros);
    }
}
