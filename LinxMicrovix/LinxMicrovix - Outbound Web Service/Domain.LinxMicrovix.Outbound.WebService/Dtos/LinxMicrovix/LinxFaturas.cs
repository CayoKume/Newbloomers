namespace Domain.LinxMicrovix.Outbound.WebService.Dtos.LinxMicrovix
{
    public class LinxFaturas
    {
        public string? id_fatura { get; set; }
        public string? id_venda { get; set; }
        public string? empresa { get; set; }
        public string? data_fatura { get; set; }
        public string? valor_fatura { get; set; }
        public string? data_vencimento { get; set; }
        public string? data_pagamento { get; set; }
        public string? valor_pago { get; set; }
        public string? status_fatura { get; set; }
        public string? timestamp { get; set; }
        public string? portal { get; set; }

        public LinxFaturas() { }

        public LinxFaturas(string? id_fatura, string? id_venda, string? empresa, string? data_fatura, string? valor_fatura, string? data_vencimento, string? data_pagamento, string? valor_pago, string? status_fatura, string? timestamp, string? portal)
        {
            this.id_fatura = id_fatura;
            this.id_venda = id_venda;
            this.empresa = empresa;
            this.data_fatura = data_fatura;
            this.valor_fatura = valor_fatura;
            this.data_vencimento = data_vencimento;
            this.data_pagamento = data_pagamento;
            this.valor_pago = valor_pago;
            this.status_fatura = status_fatura;
            this.timestamp = timestamp;
            this.portal = portal;
        }
    }
}