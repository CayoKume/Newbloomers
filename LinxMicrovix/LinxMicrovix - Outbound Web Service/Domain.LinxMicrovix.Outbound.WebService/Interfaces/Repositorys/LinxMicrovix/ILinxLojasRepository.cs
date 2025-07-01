﻿using Domain.LinxMicrovix.Outbound.WebService.Entities.LinxMicrovix;
using Domain.LinxMicrovix.Outbound.WebService.Entities.Parameters;

namespace Domain.LinxMicrovix.Outbound.WebService.Interfaces.Repositorys.LinxMicrovix
{
    public interface ILinxLojasRepository
    {
        public Task<bool> InsertRecord(LinxAPIParam jobParameter, LinxLojas? record);
        public bool BulkInsertIntoTableRaw(LinxAPIParam jobParameter, IList<LinxLojas> records);
        public Task<IEnumerable<string>> GetRegistersExists();
    }
}
