using Domain.LinxMicrovix.Outbound.WebService.Models.LinxMicrovix;
using Domain.LinxMicrovix.Outbound.WebService.Entities.Parameters;

namespace Domain.LinxMicrovix.Outbound.WebService.Interfaces.Repositorys.LinxMicrovix
{
    public interface ILinxTrocaUnificadaResumoBaixaRepository
    {
        public Task<bool> InsertRecord(LinxAPIParam jobParameter, LinxTrocaUnificadaResumoBaixa? record);
        public bool BulkInsertIntoTableRaw(LinxAPIParam jobParameter, IList<LinxTrocaUnificadaResumoBaixa> records);
        public Task<IEnumerable<LinxTrocaUnificadaResumoBaixa>> GetRegistersExists(LinxAPIParam jobParameter, List<LinxTrocaUnificadaResumoBaixa> registros);
    }
}
