using Domain.LinxMicrovix.Outbound.WebService.CustomValidations;

namespace Domain.LinxMicrovix.Outbound.WebService.Dtos.LinxMicrovix
{
    public class LinxProdutosDetalhesSimplificado
    {
        public string? cod_produto { get; private set; }
        public string? empresa { get; private set; }
        public string? portal { get; private set; }
        public string? cnpj_emp { get; private set; }
        public string? quantidade { get; private set; }
        public string? id_config_tributaria { get; private set; }
        public string? timestamp { get; private set; }

        public LinxProdutosDetalhesSimplificado() { }

        public LinxProdutosDetalhesSimplificado(
            string? cod_produto,
            string? empresa,
            string? portal,
            string? cnpj_emp,
            string? quantidade,
            string? id_config_tributaria,
            string? timestamp
        )
        {
            this.cod_produto = cod_produto;
            this.empresa = empresa;
            this.portal = portal;
            this.cnpj_emp = cnpj_emp;
            this.quantidade = quantidade;
            this.id_config_tributaria = id_config_tributaria;
            this.timestamp = timestamp;
        }
    }
}