

namespace Domain.LinxMicrovix.Outbound.WebService.Dtos.LinxMicrovix
{
    public class LinxValesComprasEnviadosAPI
    {
        public string? numero_controle { get; private set; }
        public string? valor_vale { get; private set; }
        public string? doc_cliente { get; private set; }
        public string? status_vale { get; private set; }
        public string? codigo_portal_resgate { get; private set; }
        public string? codigo_empresa_resgate { get; private set; }
        public string? codigo_usuario_resgate { get; private set; }
        public string? codigo_vale_empresa_resgate { get; private set; }
        public string? data_criacao { get; private set; }
        public string? timestamp { get; private set; }
        public string? cnpj_empresa_resgate { get; private set; }
        public string? data_resgate { get; private set; }
        
        public LinxValesComprasEnviadosAPI() { }

        public LinxValesComprasEnviadosAPI(
            string? numero_controle,
            string? valor_vale,
            string? doc_cliente,
            string? status_vale,
            string? codigo_portal_resgate,
            string? codigo_empresa_resgate,
            string? codigo_usuario_resgate,
            string? codigo_vale_empresa_resgate,
            string? data_criacao,
            string? timestamp,
            string? cnpj_empresa_resgate,
            string? data_resgate
        )
        {
            this.numero_controle = numero_controle;
            this.valor_vale = valor_vale;
            this.doc_cliente = doc_cliente;
            this.status_vale = status_vale;
            this.codigo_portal_resgate = codigo_portal_resgate;
            this.codigo_empresa_resgate = codigo_empresa_resgate;
            this.codigo_usuario_resgate = codigo_usuario_resgate;
            this.codigo_vale_empresa_resgate = codigo_vale_empresa_resgate;
            this.data_criacao = data_criacao;
            this.timestamp = timestamp;
            this.cnpj_empresa_resgate = cnpj_empresa_resgate;
            this.data_resgate = data_resgate;
        }
    }
}