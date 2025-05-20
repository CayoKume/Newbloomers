using Domain.LinxMicrovix.Outbound.WebService.CustomValidations;
using Domain.IntegrationsCore.Extensions;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.LinxMicrovix.Outbound.WebService.Entites.LinxCommerce
{
    public class B2CConsultaClientesEnderecosEntrega
    {
        [NotMapped]
        public Int32 id { get; set; }

        public DateTime? lastupdateon { get; private set; }

        public Int32? id_endereco_entrega { get; private set; }

        public Int32? cod_cliente_erp { get; private set; }

        public Int32? cod_cliente_b2c { get; private set; }

        [LengthValidation(length: 250, propertyName: "endereco_cliente")]
        public string? endereco_cliente { get; private set; }

        [LengthValidation(length: 20, propertyName: "numero_rua_cliente")]
        public string? numero_rua_cliente { get; private set; }

        [LengthValidation(length: 60, propertyName: "complemento_end_cli")]
        public string? complemento_end_cli { get; private set; }

        [LengthValidation(length: 9, propertyName: "cep_cliente")]
        public string? cep_cliente { get; private set; }

        [LengthValidation(length: 60, propertyName: "bairro_cliente")]
        public string? bairro_cliente { get; private set; }

        [LengthValidation(length: 40, propertyName: "cidade_cliente")]
        public string? cidade_cliente { get; private set; }

        [LengthValidation(length: 2, propertyName: "uf_cliente")]
        public string? uf_cliente { get; private set; }

        [LengthValidation(length: 250, propertyName: "descricao")]
        public string? descricao { get; private set; }

        public bool? principal { get; private set; }

        public Int32? id_cidade { get; private set; }

        public Int64? timestamp { get; private set; }

        public Int32? portal { get; private set; }

        [NotMapped]
        [SkipProperty]
        public string? recordKey { get; private set; }

        [NotMapped]
        [SkipProperty]
        public string? recordXml { get; private set; }

        public B2CConsultaClientesEnderecosEntrega() { }

        public B2CConsultaClientesEnderecosEntrega(
            List<ValidationResult> listValidations,
            string? id_endereco_entrega,
            string? cod_cliente_erp,
            string? cod_cliente_b2c,
            string? endereco_cliente,
            string? numero_rua_cliente,
            string? complemento_end_cli,
            string? cep_cliente,
            string? bairro_cliente,
            string? cidade_cliente,
            string? uf_cliente,
            string? descricao,
            string? principal,
            string? id_cidade,
            string? timestamp,
            string? portal,
            string? recordXml
        )
        {
            lastupdateon = DateTime.Now;

            this.id_endereco_entrega =
                ConvertToInt32Validation.IsValid(id_endereco_entrega, "id_endereco_entrega", listValidations) ?
                Convert.ToInt32(id_endereco_entrega) :
                0;

            this.cod_cliente_erp =
                ConvertToInt32Validation.IsValid(cod_cliente_erp, "cod_cliente_erp", listValidations) ?
                Convert.ToInt32(cod_cliente_erp) :
                0;

            this.cod_cliente_b2c =
                ConvertToInt32Validation.IsValid(cod_cliente_b2c, "cod_cliente_b2c", listValidations) ?
                Convert.ToInt32(cod_cliente_b2c) :
                0;

            this.principal =
                ConvertToBooleanValidation.IsValid(principal, "principal", listValidations) ?
                Convert.ToBoolean(principal) :
                false;

            this.id_cidade =
                ConvertToInt32Validation.IsValid(id_cidade, "id_cidade", listValidations) ?
                Convert.ToInt32(id_cidade) :
                0;

            this.portal =
                ConvertToInt32Validation.IsValid(portal, "portal", listValidations) ?
                Convert.ToInt32(portal) :
                0;

            this.timestamp =
                ConvertToInt64Validation.IsValid(timestamp, "timestamp", listValidations) ?
                Convert.ToInt64(timestamp) :
                0;

            this.endereco_cliente = endereco_cliente;
            this.numero_rua_cliente = numero_rua_cliente;
            this.complemento_end_cli = complemento_end_cli;
            this.cep_cliente = cep_cliente;
            this.bairro_cliente = bairro_cliente;
            this.cidade_cliente = cep_cliente;
            this.uf_cliente = uf_cliente;
            this.descricao = descricao;
            this.recordKey = $"[{id_endereco_entrega}]|[{cod_cliente_b2c}]|[{timestamp}]";
            this.recordXml = recordXml;
        }
    }
}
