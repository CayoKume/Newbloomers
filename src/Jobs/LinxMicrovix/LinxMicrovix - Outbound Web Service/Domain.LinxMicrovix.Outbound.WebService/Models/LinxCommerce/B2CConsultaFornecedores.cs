
using Domain.Core.Extensions;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.LinxMicrovix.Outbound.WebService.Models.LinxCommerce
{
    public class B2CConsultaFornecedores
    {
        public DateTime? lastupdateon { get; private set; }
        public Int32? cod_fornecedor { get; private set; }
        public string? nome { get; private set; }
        public string? nome_fantasia { get; private set; }
        public string? tipo_pessoa { get; private set; }
        public string? tipo_fornecedor { get; private set; }
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
        public Int64? timestamp { get; private set; }
        public Int32? portal { get; private set; }

        [NotMapped]
        [SkipProperty]
        public string? recordKey { get; private set; }

        [NotMapped]
        [SkipProperty]
        public string? recordXml { get; private set; }

        public B2CConsultaFornecedores() { }

        public B2CConsultaFornecedores(
            Domain.LinxMicrovix.Outbound.WebService.Dtos.LinxCommerce.B2CConsultaFornecedores record,
            string? recordXml
        )
        {
            lastupdateon = TimeZoneInfo.ConvertTimeFromUtc(DateTime.UtcNow, TimeZoneInfo.FindSystemTimeZoneById("E. South America Standard Time"));
            this.cod_fornecedor = CustomConvertersExtensions.ConvertToInt32Validation(record.cod_fornecedor);
            this.portal = CustomConvertersExtensions.ConvertToInt32Validation(record.portal);
            this.timestamp = CustomConvertersExtensions.ConvertToInt64Validation(record.timestamp);

            this.nome = record.nome;
            this.nome_fantasia = record.nome_fantasia;
            this.tipo_pessoa = record.tipo_pessoa;
            this.tipo_fornecedor = record.tipo_fornecedor;
            this.endereco = record.endereco;
            this.numero_rua = record.numero_rua;
            this.bairro = record.bairro;
            this.cep = record.cep;
            this.cidade = record.cidade;
            this.uf = record.uf;
            this.documento = record.documento;
            this.fone = record.fone;
            this.email = record.email;
            this.pais = record.pais;
            this.obs = record.obs;
            this.recordXml = recordXml;
        }
    }
}
