using Domain.LinxMicrovix.Outbound.WebService.Entites.Parameters;
using Domain.LinxMicrovix.Outbound.WebService.Interfaces.Repositorys.LinxMicrovix;

namespace Domain.LinxMicrovix.Outbound.WebService.Entites.LinxMicrovix
{
    public class LinxXMLDocumentosRepository : ILinxXMLDocumentosRepository
    {
        public LinxXMLDocumentosRepository()
        {
            
        }

        public bool BulkInsertIntoTableRaw(LinxAPIParam jobParameter, IList<LinxXMLDocumentos> records)
        {
            throw new NotImplementedException();
        }

        public Task<List<LinxXMLDocumentos>> GetRegistersExists(LinxAPIParam jobParameter, List<LinxXMLDocumentos> registros)
        {
            throw new NotImplementedException();
        }

        public Task<bool> InsertRecord(LinxAPIParam jobParameter, LinxXMLDocumentos? record)
        {
            throw new NotImplementedException();
        }
    }
}
