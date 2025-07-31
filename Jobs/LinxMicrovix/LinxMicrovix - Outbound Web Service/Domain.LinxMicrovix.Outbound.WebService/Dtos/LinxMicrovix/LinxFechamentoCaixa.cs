namespace Domain.LinxMicrovix.Outbound.WebService.Dtos.LinxMicrovix
{
    public class LinxFechamentoCaixa
    {
        public string? ativo { get; set; }
        public string? conferencia_efetuada { get; set; }
        public string? data { get; set; }
        public string? empresa { get; set; }
        public string? obs { get; set; }
        public string? timestamp { get; set; }
        public string? qtd_001 { get; set; }
        public string? qtd_005 { get; set; }
        public string? qtd_010 { get; set; }
        public string? qtd_025 { get; set; }
        public string? qtd_050 { get; set; }
        public string? qtd_1 { get; set; }
        public string? qtd_10 { get; set; }
        public string? qtd_100 { get; set; }
        public string? qtd_2 { get; set; }
        public string? qtd_20 { get; set; }
        public string? qtd_200 { get; set; }
        public string? qtd_5 { get; set; }
        public string? qtd_50 { get; set; }
        public string? sangria { get; set; }
        public string? suprimentos { get; set; }
        public string? total_c_prazo { get; set; }
        public string? total_c_vista { get; set; }
        public string? total_cartao { get; set; }
        public string? total_cartao_credito { get; set; }
        public string? total_cartao_debito { get; set; }
        public string? total_convenio { get; set; }
        public string? total_crediario { get; set; }
        public string? total_geral { get; set; }
        public string? total_giftcard { get; set; }
        public string? total_link_pagamento { get; set; }
        public string? total_link_pagamento_credito { get; set; }
        public string? total_link_pagamento_debito { get; set; }
        public string? total_pix { get; set; }
        public string? total_qr_linx { get; set; }
        public string? total_vale_compra { get; set; }
        public string? usuario { get; set; }
        public string? vale_compras_dev { get; set; }

        public LinxFechamentoCaixa()
        {
        }

        public LinxFechamentoCaixa(string? ativo, string? conferencia_efetuada, string? data, string? empresa, string? obs, string? timestamp, string? qtd_001, string? qtd_005, string? qtd_010, string? qtd_025, string? qtd_050, string? qtd_1, string? qtd_10, string? qtd_100, string? qtd_2, string? qtd_20, string? qtd_200, string? qtd_5, string? qtd_50, string? sangria, string? suprimentos, string? total_c_prazo, string? total_c_vista, string? total_cartao, string? total_cartao_credito, string? total_cartao_debito, string? total_convenio, string? total_crediario, string? total_geral, string? total_giftcard, string? total_link_pagamento, string? total_link_pagamento_credito, string? total_link_pagamento_debito, string? total_pix, string? total_qr_linx, string? total_vale_compra, string? usuario, string? vale_compras_dev)
        {
            this.ativo = ativo;
            this.conferencia_efetuada = conferencia_efetuada;
            this.data = data;
            this.empresa = empresa;
            this.obs = obs;
            this.timestamp = timestamp;
            this.qtd_001 = qtd_001;
            this.qtd_005 = qtd_005;
            this.qtd_010 = qtd_010;
            this.qtd_025 = qtd_025;
            this.qtd_050 = qtd_050;
            this.qtd_1 = qtd_1;
            this.qtd_10 = qtd_10;
            this.qtd_100 = qtd_100;
            this.qtd_2 = qtd_2;
            this.qtd_20 = qtd_20;
            this.qtd_200 = qtd_200;
            this.qtd_5 = qtd_5;
            this.qtd_50 = qtd_50;
            this.sangria = sangria;
            this.suprimentos = suprimentos;
            this.total_c_prazo = total_c_prazo;
            this.total_c_vista = total_c_vista;
            this.total_cartao = total_cartao;
            this.total_cartao_credito = total_cartao_credito;
            this.total_cartao_debito = total_cartao_debito;
            this.total_convenio = total_convenio;
            this.total_crediario = total_crediario;
            this.total_geral = total_geral;
            this.total_giftcard = total_giftcard;
            this.total_link_pagamento = total_link_pagamento;
            this.total_link_pagamento_credito = total_link_pagamento_credito;
            this.total_link_pagamento_debito = total_link_pagamento_debito;
            this.total_pix = total_pix;
            this.total_qr_linx = total_qr_linx;
            this.total_vale_compra = total_vale_compra;
            this.usuario = usuario;
            this.vale_compras_dev = vale_compras_dev;
        }
    }
}
