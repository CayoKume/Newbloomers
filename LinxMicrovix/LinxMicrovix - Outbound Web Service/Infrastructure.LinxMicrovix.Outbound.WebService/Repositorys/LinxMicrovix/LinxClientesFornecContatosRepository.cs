﻿using Domain.LinxMicrovix.Outbound.WebService.Entities.Parameters;
using Domain.LinxMicrovix.Outbound.WebService.Interfaces.Repositorys.LinxMicrovix;
using Domain.LinxMicrovix.Outbound.WebService.Entities.LinxMicrovix;

namespace Infrastructure.LinxMicrovix.Outbound.WebService.Repository.LinxMicrovix
{
    public class LinxClientesFornecContatosRepository : ILinxClientesFornecContatosRepository
    {
        public LinxClientesFornecContatosRepository()
        {

        }

        public bool BulkInsertIntoTableRaw(LinxAPIParam jobParameter, IList<LinxClientesFornecContatos> records)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<LinxClientesFornecContatos>> GetRegistersExists(LinxAPIParam jobParameter, List<LinxClientesFornecContatos> registros)
        {
            throw new NotImplementedException();
        }

        public Task<bool> InsertRecord(LinxAPIParam jobParameter, LinxClientesFornecContatos? record)
        {
            throw new NotImplementedException();
        }
    }
}
