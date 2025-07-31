using Domain.LinxMicrovix.Outbound.WebService.CustomValidations;

namespace Domain.LinxMicrovix.Outbound.WebService.Dtos.LinxMicrovix
{
    public class LinxPlanosBandeiras
    {
        public string? plano { get; private set; }
        public string? portal { get; private set; }
        public string? bandeira { get; private set; }
        public string? tipo_bandeira { get; private set; }
        public string? adquirente { get; private set; }
        public string? nome_adquirente { get; private set; }
        public string? codigo_bandeira_sitef { get; private set; }

        public LinxPlanosBandeiras() { }

        public LinxPlanosBandeiras(
            string? plano,
            string? portal,
            string? bandeira,
            string? tipo_bandeira,
            string? adquirente,
            string? nome_adquirente,
            string? codigo_bandeira_sitef
        )
        {
            this.plano = plano;
            this.portal = portal;
            this.bandeira = bandeira;
            this.tipo_bandeira = tipo_bandeira;
            this.adquirente = adquirente;
            this.nome_adquirente = nome_adquirente;
            this.codigo_bandeira_sitef = codigo_bandeira_sitef;
        }
    }
}