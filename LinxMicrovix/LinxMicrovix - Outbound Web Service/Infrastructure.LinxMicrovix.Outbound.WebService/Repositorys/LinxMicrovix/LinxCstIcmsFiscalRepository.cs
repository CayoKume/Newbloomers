﻿using Domain.LinxMicrovix.Outbound.WebService.Entities.Parameters;
using Domain.LinxMicrovix.Outbound.WebService.Interfaces.Repositorys.LinxMicrovix;
using Domain.LinxMicrovix.Outbound.WebService.Entities.LinxMicrovix;

namespace Infrastructure.LinxMicrovix.Outbound.WebService.Repository.LinxMicrovix
{
    public class LinxCstIcmsFiscalRepository : ILinxCstIcmsFiscalRepository
    {
        public LinxCstIcmsFiscalRepository()
        {

        }

        public bool BulkInsertIntoTableRaw(LinxAPIParam jobParameter, IList<LinxCstIcmsFiscal> records)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<LinxCstIcmsFiscal>> GetRegistersExists(LinxAPIParam jobParameter, List<LinxCstIcmsFiscal> registros)
        {
            throw new NotImplementedException();
        }

        public Task<bool> InsertRecord(LinxAPIParam jobParameter, LinxCstIcmsFiscal? record)
        {
            throw new NotImplementedException();
        }
    }
}
