﻿using Domain.LinxMicrovix.Outbound.WebService.Entities.Parameters;
using Domain.LinxMicrovix.Outbound.WebService.Interfaces.Repositorys.LinxMicrovix;
using Domain.LinxMicrovix.Outbound.WebService.Models.LinxMicrovix;

namespace Infrastructure.LinxMicrovix.Outbound.WebService.Repository.LinxMicrovix
{
    public class LinxFaturasRepository : ILinxFaturasRepository
    {
        public LinxFaturasRepository()
        {

        }

        public bool BulkInsertIntoTableRaw(LinxAPIParam jobParameter, IList<LinxFaturas> records)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<LinxFaturas>> GetRegistersExists(LinxAPIParam jobParameter, List<LinxFaturas> registros)
        {
            throw new NotImplementedException();
        }

        public Task<bool> InsertRecord(LinxAPIParam jobParameter, LinxFaturas? record)
        {
            throw new NotImplementedException();
        }
    }
}
