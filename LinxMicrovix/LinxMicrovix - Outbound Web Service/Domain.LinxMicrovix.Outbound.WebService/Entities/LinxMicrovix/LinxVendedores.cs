using Domain.LinxMicrovix.Outbound.WebService.CustomValidations;
using Domain.IntegrationsCore.Extensions;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Globalization;

namespace Domain.LinxMicrovix.Outbound.WebService.Entites.LinxMicrovix
{
    [Table("LinxVendedores", Schema = "linx_microvix_erp")]
    public class LinxVendedores
    {
        public DateTime lastupdateon { get; private set; }

        public Int32? cod_vendedor { get; private set; }

        [LengthValidation(length: 50, propertyName: "nome_vendedor")]
        public string? nome_vendedor { get; private set; }

        [LengthValidation(length: 1, propertyName: "tipo_vendedor")]
        public string? tipo_vendedor { get; private set; }

        [LengthValidation(length: 250, propertyName: "end_vend_rua")]
        public string? end_vend_rua { get; private set; }

        [LengthValidation(length: 20, propertyName: "end_vend_numero")]
        public string? end_vend_numero { get; private set; }

        [LengthValidation(length: 60, propertyName: "end_vend_complemento")]
        public string? end_vend_complemento { get; private set; }

        [LengthValidation(length: 60, propertyName: "end_vend_bairro")]
        public string? end_vend_bairro { get; private set; }

        [LengthValidation(length: 9, propertyName: "end_vend_cep")]
        public string? end_vend_cep { get; private set; }

        [LengthValidation(length: 40, propertyName: "end_vend_cidade")]
        public string? end_vend_cidade { get; private set; }

        [LengthValidation(length: 2, propertyName: "end_vend_uf")]
        public string? end_vend_uf { get; private set; }

        [LengthValidation(length: 20, propertyName: "fone_vendedor")]
        public string? fone_vendedor { get; private set; }

        [LengthValidation(length: 50, propertyName: "mail_vendedor")]
        public string? mail_vendedor { get; private set; }

        public DateTime? dt_upd { get; private set; }

        [LengthValidation(length: 14, propertyName: "cpf_vendedor")]
        public string? cpf_vendedor { get; private set; }

        [LengthValidation(length: 1, propertyName: "ativo")]
        public string? ativo { get; private set; }

        public DateTime? data_admissao { get; private set; }

        public DateTime? data_saida { get; private set; }

        public Int32? portal { get; private set; }

        public Int64? timestamp { get; private set; }

        [LengthValidation(length: 30, propertyName: "matricula")]
        public string? matricula { get; private set; }

        public Int32? id_tipo_venda { get; private set; }

        [LengthValidation(length: 100, propertyName: "descricao_tipo_venda")]
        public string? descricao_tipo_venda { get; private set; }

        [LengthValidation(length: 20, propertyName: "cargo")]
        public string? cargo { get; private set; }

        [NotMapped]
        [SkipProperty]
        public string? recordKey { get; private set; }

        [NotMapped]
        [SkipProperty]
        public string? recordXml { get; private set; }

        public LinxVendedores() { }

        public LinxVendedores(
            List<ValidationResult> listValidations,
            string? cod_vendedor,
            string? nome_vendedor,
            string? tipo_vendedor,
            string? end_vend_rua,
            string? end_vend_numero,
            string? end_vend_complemento,
            string? end_vend_bairro,
            string? end_vend_cep,
            string? end_vend_cidade,
            string? end_vend_uf,
            string? fone_vendedor,
            string? mail_vendedor,
            string? dt_upd,
            string? cpf_vendedor,
            string? ativo,
            string? data_admissao,
            string? data_saida,
            string? portal,
            string? timestamp,
            string? matricula,
            string? id_tipo_venda,
            string? descricao_tipo_venda,
            string? cargo,
            string? recordXml
        )
        {
            lastupdateon = DateTime.Now;

            this.cod_vendedor =
                ConvertToInt32Validation.IsValid(cod_vendedor, "cod_vendedor", listValidations) ?
                Convert.ToInt32(cod_vendedor) :
                0;

            this.dt_upd =
                ConvertToDateTimeValidation.IsValid(dt_upd, "dt_upd", listValidations) ?
                Convert.ToDateTime(dt_upd) :
                new DateTime(1990, 01, 01, 00, 00, 00, new CultureInfo("en-US").Calendar);

            this.data_admissao =
                ConvertToDateTimeValidation.IsValid(data_admissao, "data_admissao", listValidations) ?
                Convert.ToDateTime(data_admissao) :
                new DateTime(1990, 01, 01, 00, 00, 00, new CultureInfo("en-US").Calendar);

            this.data_saida =
                ConvertToDateTimeValidation.IsValid(data_saida, "data_saida", listValidations) ?
                Convert.ToDateTime(data_saida) :
                new DateTime(1990, 01, 01, 00, 00, 00, new CultureInfo("en-US").Calendar);

            this.id_tipo_venda =
                ConvertToInt32Validation.IsValid(id_tipo_venda, "id_tipo_venda", listValidations) ?
                Convert.ToInt32(id_tipo_venda) :
                0;

            this.portal =
                ConvertToInt32Validation.IsValid(portal, "portal", listValidations) ?
                Convert.ToInt32(portal) :
                0;

            this.timestamp =
                ConvertToInt64Validation.IsValid(timestamp, "timestamp", listValidations) ?
                Convert.ToInt64(timestamp) :
                0;

            this.nome_vendedor = nome_vendedor;
            this.tipo_vendedor = tipo_vendedor;
            this.end_vend_rua = end_vend_rua;
            this.end_vend_numero = end_vend_numero;
            this.end_vend_complemento = end_vend_complemento;
            this.end_vend_bairro = end_vend_bairro;
            this.end_vend_cep = end_vend_cep;
            this.end_vend_cidade = end_vend_cidade;
            this.end_vend_uf = end_vend_uf;
            this.fone_vendedor = fone_vendedor;
            this.mail_vendedor = mail_vendedor;
            this.cpf_vendedor = cpf_vendedor;
            this.ativo = ativo;
            this.matricula = matricula;
            this.descricao_tipo_venda = descricao_tipo_venda;
            this.cargo = cargo;
            this.recordKey = $"[{cod_vendedor}]|[{cpf_vendedor}]|[{timestamp}]";
            this.recordXml = recordXml;
        }
    }
}
