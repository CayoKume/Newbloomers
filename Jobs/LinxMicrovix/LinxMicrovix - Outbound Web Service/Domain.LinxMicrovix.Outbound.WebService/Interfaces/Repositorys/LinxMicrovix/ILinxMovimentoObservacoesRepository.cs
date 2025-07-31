﻿using Domain.LinxMicrovix.Outbound.WebService.Models.LinxMicrovix;
using Domain.LinxMicrovix.Outbound.WebService.Entities.Parameters;

namespace Domain.LinxMicrovix.Outbound.WebService.Interfaces.Repositorys.LinxMicrovix
{
    public interface ILinxMovimentoObservacoesRepository
    {
        public Task<bool> InsertRecord(LinxAPIParam jobParameter, LinxMovimentoObservacoes? record);
        public bool BulkInsertIntoTableRaw(LinxAPIParam jobParameter, IList<LinxMovimentoObservacoes> records);
        public Task<IEnumerable<LinxMovimentoObservacoes>> GetRegistersExists(LinxAPIParam jobParameter, List<LinxMovimentoObservacoes> registros);
    }
}
