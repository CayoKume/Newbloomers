using Domain.IntegrationsCore.Entities.Parameters;
using Domain.LinxMicrovix.Outbound.WebService.Entites.LinxMicrovix;

namespace Domain.LinxMicrovix.Outbound.WebService.Interfaces.Repositorys.LinxMicrovix
{
    public interface ILinxCategoriasFinanceirasRepository
    {
        public Task<bool> InsertRecord(LinxMicrovixJobParameter jobParameter, LinxCategoriasFinanceiras? record);
        public bool BulkInsertIntoTableRaw(LinxMicrovixJobParameter jobParameter, IList<LinxCategoriasFinanceiras> records);
        public Task<List<LinxCategoriasFinanceiras>> GetRegistersExists(LinxMicrovixJobParameter jobParameter, List<LinxCategoriasFinanceiras> registros);
    }
}
