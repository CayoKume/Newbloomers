﻿using Domain.LinxMicrovix.Outbound.WebService.Models.LinxMicrovix;
using Domain.LinxMicrovix.Outbound.WebService.Entities.Parameters;

namespace Domain.LinxMicrovix.Outbound.WebService.Interfaces.Repositorys.LinxMicrovix
{
    public interface ILinxRamosAtividadeRepository
    {
        public Task<bool> InsertRecord(LinxAPIParam jobParameter, LinxRamosAtividade? record);
        public bool BulkInsertIntoTableRaw(LinxAPIParam jobParameter, IList<LinxRamosAtividade> records);
        public Task<IEnumerable<LinxRamosAtividade>> GetRegistersExists(LinxAPIParam jobParameter, List<LinxRamosAtividade> registros);
    }
}
