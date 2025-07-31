using Domain.LinxMicrovix.Outbound.WebService.Entities.Parameters;
using Domain.LinxMicrovix.Outbound.WebService.Interfaces.Repositorys.LinxMicrovix;
using Domain.LinxMicrovix.Outbound.WebService.Models.LinxMicrovix;

namespace Infrastructure.LinxMicrovix.Outbound.WebService.Repository.LinxMicrovix
{
    public class LinxTrocaUnificadaResumoBaixaRepository : ILinxTrocaUnificadaResumoBaixaRepository
    {
        public LinxTrocaUnificadaResumoBaixaRepository()
        {

        }

        public bool BulkInsertIntoTableRaw(LinxAPIParam jobParameter, IList<LinxTrocaUnificadaResumoBaixa> records)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<LinxTrocaUnificadaResumoBaixa>> GetRegistersExists(LinxAPIParam jobParameter, List<LinxTrocaUnificadaResumoBaixa> registros)
        {
            throw new NotImplementedException();
        }

        public Task<bool> InsertRecord(LinxAPIParam jobParameter, LinxTrocaUnificadaResumoBaixa? record)
        {
            throw new NotImplementedException();
        }
    }
}
