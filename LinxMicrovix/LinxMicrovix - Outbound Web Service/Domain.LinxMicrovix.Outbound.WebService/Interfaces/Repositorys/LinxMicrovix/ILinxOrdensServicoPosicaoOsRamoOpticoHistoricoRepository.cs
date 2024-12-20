using Domain.LinxMicrovix.Outbound.WebService.Entites.LinxMicrovix;
using Domain.LinxMicrovix.Outbound.WebService.Entites.Parameters;

namespace Domain.LinxMicrovix.Outbound.WebService.Interfaces.Repositorys.LinxMicrovix
{
    public interface ILinxOrdensServicoPosicaoOsRamoOpticoHistoricoRepository
    {
        public Task<bool> InsertRecord(LinxAPIParam jobParameter, LinxOrdensServicoPosicaoOsRamoOpticoHistorico? record);
        public bool BulkInsertIntoTableRaw(LinxAPIParam jobParameter, IList<LinxOrdensServicoPosicaoOsRamoOpticoHistorico> records);
        public Task<List<LinxOrdensServicoPosicaoOsRamoOpticoHistorico>> GetRegistersExists(LinxAPIParam jobParameter, List<LinxOrdensServicoPosicaoOsRamoOpticoHistorico> registros);
    }
}
