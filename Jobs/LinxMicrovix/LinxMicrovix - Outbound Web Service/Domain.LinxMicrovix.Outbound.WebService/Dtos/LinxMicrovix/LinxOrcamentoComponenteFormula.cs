using Domain.LinxMicrovix.Outbound.WebService.CustomValidations;

namespace Domain.LinxMicrovix.Outbound.WebService.Dtos.LinxMicrovix
{
    public class LinxOrcamentoComponenteFormula
    {
        public string? id_orcamento_componente_formula { get; private set; }
        public string? documento { get; private set; }
        public string? codigo_produto { get; private set; }
        public string? codigo_componente { get; private set; }
        public string? descricao_componente { get; private set; }
        public string? unidade { get; private set; }
        public string? quantidade { get; private set; }
        public string? valor_componente { get; private set; }
        public string? lote_componente { get; private set; }
        public string? data_validade_lote { get; private set; }
        public string? codigo_ws { get; private set; }
        public string? portal { get; private set; }
        public string? timestamp { get; private set; }

        public LinxOrcamentoComponenteFormula() { }

        public LinxOrcamentoComponenteFormula(
            string? id_orcamento_componente_formula,
            string? documento,
            string? codigo_produto,
            string? codigo_componente,
            string? descricao_componente,
            string? unidade,
            string? quantidade,
            string? valor_componente,
            string? lote_componente,
            string? data_validade_lote,
            string? codigo_ws,
            string? portal,
            string? timestamp
        )
        {
            this.id_orcamento_componente_formula = id_orcamento_componente_formula;
            this.documento = documento;
            this.codigo_produto = codigo_produto;
            this.codigo_componente = codigo_componente;
            this.descricao_componente = descricao_componente;
            this.unidade = unidade;
            this.quantidade = quantidade;
            this.valor_componente = valor_componente;
            this.lote_componente = lote_componente;
            this.data_validade_lote = data_validade_lote;
            this.codigo_ws = codigo_ws;
            this.portal = portal;
            this.timestamp = timestamp;
        }
    }
}