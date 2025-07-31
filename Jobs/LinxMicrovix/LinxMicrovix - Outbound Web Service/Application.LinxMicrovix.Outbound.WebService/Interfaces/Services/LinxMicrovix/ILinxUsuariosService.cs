using Domain.LinxMicrovix.Outbound.WebService.Entities.Parameters;
using Domain.LinxMicrovix.Outbound.WebService.Models.LinxMicrovix;

namespace Application.LinxMicrovix.Outbound.WebService.Interfaces.Services.LinxMicrovix
{
    public interface ILinxUsuariosService
    {
        public List<LinxUsuarios?> DeserializeXMLToObject(LinxAPIParam jobParameter, List<Dictionary<string?, string?>> records);
        public Task<bool> GetRecords(LinxAPIParam jobParameter);
    }
}
