﻿using Domain.LinxMicrovix.Outbound.WebService.Models.LinxMicrovix;
using Domain.LinxMicrovix.Outbound.WebService.Entities.Parameters;

namespace Domain.LinxMicrovix.Outbound.WebService.Interfaces.Repositorys.LinxMicrovix
{
    public interface ILinxMovimentoTrocasRepository
    {
        public Task<bool> InsertRecord(LinxAPIParam jobParameter, LinxMovimentoTrocas? record);
        public bool BulkInsertIntoTableRaw(LinxAPIParam jobParameter, IList<LinxMovimentoTrocas> records);
        public Task<IEnumerable<string?>> GetRegistersExists(LinxAPIParam jobParameter, List<LinxMovimentoTrocas?> registros);
    }
}
