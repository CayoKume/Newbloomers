namespace Domain.LinxMicrovix.Outbound.WebService.Dtos.LinxCommerce
{
    public class B2CConsultaPlanosParcelas
    {
        public string? plano { get; private set; }
        public string? ordem_parcela { get; private set; }
        public string? prazo_parc { get; private set; }
        public string? id_planos_parcelas { get; private set; }
        public string? timestamp { get; private set; }
        public string? portal { get; private set; }

        public B2CConsultaPlanosParcelas() { }

        public B2CConsultaPlanosParcelas(
            string? plano,
            string? ordem_parcela,
            string? prazo_parc,
            string? id_planos_parcelas,
            string? timestamp,
            string? portal
        )
        {
            this.plano = plano;
            this.ordem_parcela = ordem_parcela;
            this.prazo_parc = prazo_parc;
            this.id_planos_parcelas = id_planos_parcelas;
            this.timestamp = timestamp;
            this.portal = portal;
        }
    }
}