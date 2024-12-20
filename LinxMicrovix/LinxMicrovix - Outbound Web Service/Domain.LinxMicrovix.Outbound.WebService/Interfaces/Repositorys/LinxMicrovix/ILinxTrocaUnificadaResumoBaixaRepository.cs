using Domain.LinxMicrovix.Outbound.WebService.Entites.LinxMicrovix;
using Domain.LinxMicrovix.Outbound.WebService.Entites.Parameters;

namespace Domain.LinxMicrovix.Outbound.WebService.Interfaces.Repositorys.LinxMicrovix
{
    public interface ILinxTrocaUnificadaResumoBaixaRepository
    {
        public Task<bool> InsertRecord(LinxAPIParam jobParameter, LinxTrocaUnificadaResumoBaixa? record);
        public bool BulkInsertIntoTableRaw(LinxAPIParam jobParameter, IList<LinxTrocaUnificadaResumoBaixa> records);
        public Task<List<LinxTrocaUnificadaResumoBaixa>> GetRegistersExists(LinxAPIParam jobParameter, List<LinxTrocaUnificadaResumoBaixa> registros);
    }
}
