namespace Domain.LinxMicrovix.Outbound.WebService.Entities.Base.LinxMicrovix
{
    public abstract class LinxMovimentoTrocafone
    {
        public string? portal { get; set; }
        public string? cnpj_emp { get; set; }
        public string? identificador { get; set; }
        public string? num_vale { get; set; }
        public string? voucher { get; set; }
        public string? valor_vale { get; set; }
        public string? nome_produto { get; set; }
        public string? condicao { get; set; }
        public string? id_tradein_parceiro { get; set; }
    }
}
