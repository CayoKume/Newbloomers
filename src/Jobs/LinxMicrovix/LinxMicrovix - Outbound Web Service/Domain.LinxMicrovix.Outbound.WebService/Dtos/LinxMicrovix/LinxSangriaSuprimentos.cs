

namespace Domain.LinxMicrovix.Outbound.WebService.Dtos.LinxMicrovix
{
    public class LinxSangriaSuprimentos
    {
        public string? portal { get; private set; }
        public string? cnpj_emp { get; private set; }
        public string? usuario { get; private set; }
        public string? data { get; private set; }
        public string? valor { get; private set; }
        public string? obs { get; private set; }
        public string? cancelado { get; private set; }
        public string? conferido { get; private set; }
        public string? cod_historico { get; private set; }
        public string? desc_historico { get; private set; }
        public string? id_sangria_suprimentos { get; private set; }

        public LinxSangriaSuprimentos() { }

        public LinxSangriaSuprimentos(
            string? portal,
            string? cnpj_emp,
            string? usuario,
            string? data,
            string? valor,
            string? obs,
            string? cancelado,
            string? conferido,
            string? cod_historico,
            string? desc_historico,
            string? id_sangria_suprimentos
        )
        {
            this.portal = portal;
            this.cnpj_emp = cnpj_emp;
            this.usuario = usuario;
            this.data = data;
            this.valor = valor;
            this.obs = obs;
            this.cancelado = cancelado;
            this.conferido = conferido;
            this.cod_historico = cod_historico;
            this.desc_historico = desc_historico;
            this.id_sangria_suprimentos = id_sangria_suprimentos;
        }
    }
}