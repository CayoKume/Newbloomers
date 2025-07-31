using Domain.LinxMicrovix.Outbound.WebService.CustomValidations;

namespace Domain.LinxMicrovix.Outbound.WebService.Dtos.LinxMicrovix
{
    public class LinxTrocaUnificadaResumoVendas
    {
        public string? id_troca_unificada_resumo_vendas { get; private set; }
        public string? portal { get; private set; }
        public string? empresa { get; private set; }
        public string? token { get; private set; }
        public string? identificador { get; private set; }
        public string? documento { get; private set; }
        public string? serie { get; private set; }
        public string? data_venda { get; private set; }
        public string? documento_cliente { get; private set; }
        public string? venda_cancelada { get; private set; }
        public string? timestamp { get; private set; }

        public LinxTrocaUnificadaResumoVendas() { }

        public LinxTrocaUnificadaResumoVendas(
            string? id_troca_unificada_resumo_vendas,
            string? portal,
            string? empresa,
            string? token,
            string? identificador,
            string? documento,
            string? serie,
            string? data_venda,
            string? documento_cliente,
            string? venda_cancelada,
            string? timestamp
        )
        {
            this.id_troca_unificada_resumo_vendas = id_troca_unificada_resumo_vendas;
            this.portal = portal;
            this.empresa = empresa;
            this.token = token;
            this.identificador = identificador;
            this.documento = documento;
            this.serie = serie;
            this.data_venda = data_venda;
            this.documento_cliente = documento_cliente;
            this.venda_cancelada = venda_cancelada;
            this.timestamp = timestamp;
        }
    }
}