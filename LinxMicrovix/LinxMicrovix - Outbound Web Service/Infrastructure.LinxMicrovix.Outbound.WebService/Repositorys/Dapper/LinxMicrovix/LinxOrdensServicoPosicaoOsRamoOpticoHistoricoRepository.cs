using Domain.LinxMicrovix.Outbound.WebService.Entites.Parameters;
using Domain.LinxMicrovix.Outbound.WebService.Interfaces.Repositorys.LinxMicrovix;
using Domain.LinxMicrovix.Outbound.WebService.Entites.LinxMicrovix;

namespace Infrastructure.LinxMicrovix.Outbound.WebService.Repository.Dapper.LinxMicrovix
{
    public class LinxOrdensServicoPosicaoOsRamoOpticoHistoricoRepository : ILinxOrdensServicoPosicaoOsRamoOpticoHistoricoRepository
    {
        public LinxOrdensServicoPosicaoOsRamoOpticoHistoricoRepository()
        {
            
        }

        public bool BulkInsertIntoTableRaw(LinxAPIParam jobParameter, IList<LinxOrdensServicoPosicaoOsRamoOpticoHistorico> records)
        {
            throw new NotImplementedException();
        }

        public Task<List<LinxOrdensServicoPosicaoOsRamoOpticoHistorico>> GetRegistersExists(LinxAPIParam jobParameter, List<LinxOrdensServicoPosicaoOsRamoOpticoHistorico> registros)
        {
            throw new NotImplementedException();
        }

        public Task<bool> InsertRecord(LinxAPIParam jobParameter, LinxOrdensServicoPosicaoOsRamoOpticoHistorico? record)
        {
            throw new NotImplementedException();
        }
    }
}
