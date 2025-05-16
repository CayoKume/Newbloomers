using Domain.LinxMicrovix.Outbound.WebService.Entites.Parameters;
using Domain.LinxMicrovix.Outbound.WebService.Entites.LinxMicrovix;

namespace Application.LinxMicrovix.Outbound.WebService.Interfaces.LinxMicrovix
{
    public interface ILinxUsuariosService
    {
        public List<LinxUsuarios?> DeserializeXMLToObject(LinxAPIParam jobParameter, List<Dictionary<string?, string?>> records);
        public Task<bool> GetRecords(LinxAPIParam jobParameter);
    }
}
