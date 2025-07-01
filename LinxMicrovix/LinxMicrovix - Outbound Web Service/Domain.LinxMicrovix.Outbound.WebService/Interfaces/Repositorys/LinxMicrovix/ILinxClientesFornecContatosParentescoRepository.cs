﻿using Domain.LinxMicrovix.Outbound.WebService.Entities.LinxMicrovix;
using Domain.LinxMicrovix.Outbound.WebService.Entities.Parameters;

namespace Domain.LinxMicrovix.Outbound.WebService.Interfaces.Repositorys.LinxMicrovix
{
    public interface ILinxClientesFornecContatosParentescoRepository
    {
        public Task<bool> InsertRecord(LinxAPIParam jobParameter, LinxClientesFornecContatosParentesco? record);
        public bool BulkInsertIntoTableRaw(LinxAPIParam jobParameter, IList<LinxClientesFornecContatosParentesco> records);
        public Task<IEnumerable<LinxClientesFornecContatosParentesco>> GetRegistersExists(LinxAPIParam jobParameter, List<LinxClientesFornecContatosParentesco> registros);
    }
}
