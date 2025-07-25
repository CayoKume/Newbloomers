namespace Domain.LinxMicrovix.Outbound.WebService.Dtos.LinxMicrovix
{
    public class LinxECFFormasPagamento
    {
        public string? id_ecf_forma_pagamento { get; set; }
        public string? id_ecf { get; set; }
        public string? id_forma_pagamento { get; set; }
        public string? timestamp { get; set; }
        public string? portal { get; set; }

        public LinxECFFormasPagamento() { }

        public LinxECFFormasPagamento(string? id_ecf_forma_pagamento, string? id_ecf, string? id_forma_pagamento, string? timestamp, string? portal)
        {
            this.id_ecf_forma_pagamento = id_ecf_forma_pagamento;
            this.id_ecf = id_ecf;
            this.id_forma_pagamento = id_forma_pagamento;
            this.timestamp = timestamp;
            this.portal = portal;
        }
    }
}