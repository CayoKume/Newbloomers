using Domain.LinxMicrovix.Outbound.WebService.Entites.Parameters;
using Domain.LinxMicrovix.Outbound.WebService.Interfaces.Repositorys.LinxMicrovix;
using Domain.LinxMicrovix.Outbound.WebService.Entites.LinxMicrovix;

namespace Infrastructure.LinxMicrovix.Outbound.WebService.Repository.Dapper.LinxMicrovix
{
    public class LinxPosicaoOsRamoOpticoRepository : ILinxPosicaoOsRamoOpticoRepository
    {
        public LinxPosicaoOsRamoOpticoRepository()
        {
            
        }

        public bool BulkInsertIntoTableRaw(LinxAPIParam jobParameter, IList<LinxPosicaoOsRamoOptico> records)
        {
            throw new NotImplementedException();
        }

        public Task<List<LinxPosicaoOsRamoOptico>> GetRegistersExists(LinxAPIParam jobParameter, List<LinxPosicaoOsRamoOptico> registros)
        {
            throw new NotImplementedException();
        }

        public Task<bool> InsertRecord(LinxAPIParam jobParameter, LinxPosicaoOsRamoOptico? record)
        {
            throw new NotImplementedException();
        }
    }
}
