﻿using Domain.LinxMicrovix.Outbound.WebService.Models.LinxMicrovix;
using Domain.LinxMicrovix.Outbound.WebService.Entities.Parameters;

namespace Domain.LinxMicrovix.Outbound.WebService.Interfaces.Repositorys.LinxMicrovix
{
    public interface ILinxAcoesPromocionaisCombinacaoProdutosItensRepository
    {
        public Task<bool> InsertRecord(LinxAPIParam jobParameter, LinxAcoesPromocionaisCombinacaoProdutosItens? record);
        public bool BulkInsertIntoTableRaw(LinxAPIParam jobParameter, IList<LinxAcoesPromocionaisCombinacaoProdutosItens> records);
        public Task<IEnumerable<LinxAcoesPromocionaisCombinacaoProdutosItens>> GetRegistersExists(LinxAPIParam jobParameter, List<LinxAcoesPromocionaisCombinacaoProdutosItens> registros);
    }
}
