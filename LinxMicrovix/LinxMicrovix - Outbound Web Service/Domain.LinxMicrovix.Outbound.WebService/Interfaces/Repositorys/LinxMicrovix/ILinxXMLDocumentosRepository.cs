using Domain.LinxMicrovix.Outbound.WebService.Entites.LinxMicrovix;
using Domain.LinxMicrovix.Outbound.WebService.Entites.Parameters;

namespace Domain.LinxMicrovix.Outbound.WebService.Interfaces.Repositorys.LinxMicrovix
{
    public interface ILinxXMLDocumentosRepository
    {
        public Task<bool> InsertRecord(LinxAPIParam jobParameter, LinxXMLDocumentos? record);
        public bool BulkInsertIntoTableRaw(LinxAPIParam jobParameter, IList<LinxXMLDocumentos> records);
        public Task<List<LinxXMLDocumentos>> GetRegistersExists(LinxAPIParam jobParameter, List<LinxXMLDocumentos> registros);

    }
}
