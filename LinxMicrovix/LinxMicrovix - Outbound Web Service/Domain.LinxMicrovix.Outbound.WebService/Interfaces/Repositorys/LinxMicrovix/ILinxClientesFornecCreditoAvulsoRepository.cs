using Domain.LinxMicrovix.Outbound.WebService.Entites.Parameters;
using Domain.LinxMicrovix.Outbound.WebService.Entites.LinxMicrovix;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.LinxMicrovix.Outbound.WebService.Interfaces.Repositorys.LinxMicrovix
{
    public interface ILinxClientesFornecCreditoAvulsoRepository
    {
        public Task<bool> InsertRecord(LinxAPIParam jobParameter, LinxClientesFornecCreditoAvulso? record);
        public bool BulkInsertIntoTableRaw(LinxAPIParam jobParameter, IList<LinxClientesFornecCreditoAvulso> records);
        public Task<List<LinxClientesFornecCreditoAvulso>> GetRegistersExists(LinxAPIParam jobParameter, List<LinxClientesFornecCreditoAvulso> registros);
    }
}
