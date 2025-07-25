namespace Domain.LinxMicrovix.Outbound.WebService.Dtos.LinxCommerce
{
    public class B2CConsultaTransportadores
    {
        public string? cod_transportador { get; private set; }
        public string? nome { get; private set; }
        public string? nome_fantasia { get; private set; }
        public string? tipo_pessoa { get; private set; }
        public string? tipo_transportador { get; private set; }
        public string? endereco { get; private set; }
        public string? numero_rua { get; private set; }
        public string? bairro { get; private set; }
        public string? cep { get; private set; }
        public string? cidade { get; private set; }
        public string? uf { get; private set; }
        public string? documento { get; private set; }
        public string? fone { get; private set; }
        public string? email { get; private set; }
        public string? pais { get; private set; }
        public string? obs { get; private set; }
        public string? timestamp { get; private set; }
        public string? portal { get; private set; }

        public B2CConsultaTransportadores() { }

        public B2CConsultaTransportadores(string? cod_transportador, string? nome, string? nome_fantasia, string? tipo_pessoa, string? tipo_transportador, string? endereco, string? numero_rua, string? bairro, string? cep, string? cidade, string? uf, string? documento, string? fone, string? email, string? pais, string? obs, string? timestamp, string? portal)
        {
            this.cod_transportador = cod_transportador;
            this.nome = nome;
            this.nome_fantasia = nome_fantasia;
            this.tipo_pessoa = tipo_pessoa;
            this.tipo_transportador = tipo_transportador;
            this.endereco = endereco;
            this.numero_rua = numero_rua;
            this.bairro = bairro;
            this.cep = cep;
            this.cidade = cidade;
            this.uf = uf;
            this.documento = documento;
            this.fone = fone;
            this.email = email;
            this.pais = pais;
            this.obs = obs;
            this.timestamp = timestamp;
            this.portal = portal;
        }
    }
}