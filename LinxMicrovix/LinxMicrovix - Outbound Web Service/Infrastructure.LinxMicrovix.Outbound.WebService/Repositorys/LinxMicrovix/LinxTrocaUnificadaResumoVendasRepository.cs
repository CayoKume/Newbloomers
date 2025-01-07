using Domain.LinxMicrovix.Outbound.WebService.Entites.Parameters;
using Domain.LinxMicrovix.Outbound.WebService.Interfaces.Repositorys.LinxMicrovix;

namespace Domain.LinxMicrovix.Outbound.WebService.Entites.LinxMicrovix
{
    public class LinxTrocaUnificadaResumoVendasRepository : ILinxTrocaUnificadaResumoVendasRepository
    {
        public LinxTrocaUnificadaResumoVendasRepository()
        {
            
        }

        public bool BulkInsertIntoTableRaw(LinxAPIParam jobParameter, IList<LinxTrocaUnificadaResumoVendas> records)
        {
            throw new NotImplementedException();
        }

        public Task<List<LinxTrocaUnificadaResumoVendas>> GetRegistersExists(LinxAPIParam jobParameter, List<LinxTrocaUnificadaResumoVendas> registros)
        {
            throw new NotImplementedException();
        }

        public Task<bool> InsertRecord(LinxAPIParam jobParameter, LinxTrocaUnificadaResumoVendas? record)
        {
            throw new NotImplementedException();
        }
    }
}
