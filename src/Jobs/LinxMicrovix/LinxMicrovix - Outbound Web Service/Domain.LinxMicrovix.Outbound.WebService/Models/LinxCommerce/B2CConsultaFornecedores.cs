using Domain.LinxMicrovix.Outbound.WebService.CustomValidations;
using Domain.Core.Extensions;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.LinxMicrovix.Outbound.WebService.Models.LinxCommerce
{
    public class B2CConsultaFornecedores
    {
        [NotMapped]
        public Int32 id { get; set; }

        public DateTime? lastupdateon { get; private set; }

        public Int32? cod_fornecedor { get; private set; }

        [LengthValidation(length: 60, propertyName: "nome")]
        public string? nome { get; private set; }

        [LengthValidation(length: 60, propertyName: "nome_fantasia")]
        public string? nome_fantasia { get; private set; }

        [LengthValidation(length: 1, propertyName: "tipo_pessoa")]
        public string? tipo_pessoa { get; private set; }

        [LengthValidation(length: 1, propertyName: "tipo_fornecedor")]
        public string? tipo_fornecedor { get; private set; }

        [LengthValidation(length: 250, propertyName: "endereco")]
        public string? endereco { get; private set; }

        [LengthValidation(length: 20, propertyName: "numero_rua")]
        public string? numero_rua { get; private set; }

        [LengthValidation(length: 60, propertyName: "bairro")]
        public string? bairro { get; private set; }

        [LengthValidation(length: 9, propertyName: "cep")]
        public string? cep { get; private set; }

        [LengthValidation(length: 40, propertyName: "cidade")]
        public string? cidade { get; private set; }

        [LengthValidation(length: 2, propertyName: "uf")]
        public string? uf { get; private set; }

        [LengthValidation(length: 14, propertyName: "documento")]
        public string? documento { get; private set; }

        [LengthValidation(length: 20, propertyName: "fone")]
        public string? fone { get; private set; }

        [LengthValidation(length: 50, propertyName: "email")]
        public string? email { get; private set; }

        [LengthValidation(length: 80, propertyName: "pais")]
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
            List<ValidationResult> listValidations,
            string? cod_fornecedor,
            string? nome,
            string? nome_fantasia,
            string? tipo_pessoa,
            string? tipo_fornecedor,
            string? endereco,
            string? numero_rua,
            string? bairro,
            string? cep,
            string? cidade,
            string? uf,
            string? documento,
            string? fone,
            string? email,
            string? pais,
            string? obs,
            string? timestamp,
            string? portal,
            string? recordXml
        )
        {
            lastupdateon = DateTime.Now;

            this.cod_fornecedor =
                ConvertToInt32Validation.IsValid(cod_fornecedor, "cod_fornecedor", listValidations) ?
                Convert.ToInt32(cod_fornecedor) :
                0;

            this.portal =
                ConvertToInt32Validation.IsValid(portal, "portal", listValidations) ?
                Convert.ToInt32(portal) :
                0;

            this.timestamp =
                ConvertToInt64Validation.IsValid(timestamp, "timestamp", listValidations) ?
                Convert.ToInt64(timestamp) :
                0;

            this.nome = nome;
            this.nome_fantasia = nome_fantasia;
            this.tipo_pessoa = tipo_pessoa;
            this.tipo_fornecedor = tipo_fornecedor;
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
            this.recordXml = recordXml;
        }
    }
}
