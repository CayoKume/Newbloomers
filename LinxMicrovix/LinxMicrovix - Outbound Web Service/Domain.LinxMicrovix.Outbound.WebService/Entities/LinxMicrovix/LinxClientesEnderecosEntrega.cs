using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using Domain.IntegrationsCore.Extensions;
using Domain.LinxMicrovix.Outbound.WebService.CustomValidations;

namespace Domain.LinxMicrovix.Outbound.WebService.Entities.LinxMicrovix
{
    public class LinxClientesEnderecosEntrega
    {
        [NotMapped]
        public Int32 id { get; set; }

        public DateTime? lastupdateon { get; private set; }

        public Int32? id_endereco_entrega { get; private set; }

        public Int32? cod_cliente { get; private set; }

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

        [LengthValidation(length: 20, propertyName: "fone_cliente")]
        public string? fone_cliente { get; private set; }

        [LengthValidation(length: 20, propertyName: "fone_celular")]
        public string? fone_celular { get; private set; }

        public Int64? timestamp { get; private set; }

        public Int32? portal { get; private set; }

        [NotMapped]
        [SkipProperty]
        public string? recordKey { get; private set; }

        [NotMapped]
        [SkipProperty]
        public string? recordXml { get; private set; }

        public LinxClientesEnderecosEntrega(){ }

        public LinxClientesEnderecosEntrega(
            List<ValidationResult> listValidations,
            string? id_endereco_entrega,
            string? cod_cliente,
            string? endereco_cliente,
            string? numero_rua_cliente,
            string? complemento_end_cli,
            string? cep_cliente,
            string? bairro_cliente,
            string? cidade_cliente,
            string? uf_cliente,
            string? descricao,
            string? principal,
            string? fone_cliente,
            string? fone_celular,
            string? timestamp,
            string? portal,
            string? recordXml
        )
        {
            this.lastupdateon = DateTime.Now;

            this.id_endereco_entrega =
                ConvertToInt32Validation.IsValid(id_endereco_entrega, "id_endereco_entrega", listValidations) ?
                Convert.ToInt32(id_endereco_entrega) :
                0;

            this.cod_cliente =
                ConvertToInt32Validation.IsValid(cod_cliente, "cod_cliente", listValidations) ?
                Convert.ToInt32(cod_cliente) :
                0;

            this.portal =
                ConvertToInt32Validation.IsValid(portal, "portal", listValidations) ?
                Convert.ToInt32(portal) :
                0;

            this.principal =
                ConvertToBooleanValidation.IsValid(principal, "principal", listValidations) ?
                Convert.ToBoolean(principal) :
                false;

            this.timestamp =
                ConvertToInt64Validation.IsValid(timestamp, "timestamp", listValidations) ?
                Convert.ToInt64(timestamp) :
                0;

            this.endereco_cliente = endereco_cliente;
            this.numero_rua_cliente = numero_rua_cliente;
            this.complemento_end_cli = complemento_end_cli;
            this.cep_cliente = cep_cliente;
            this.bairro_cliente = bairro_cliente;
            this.cidade_cliente = cidade_cliente;
            this.uf_cliente = uf_cliente;
            this.descricao = descricao;
            this.fone_celular = fone_celular;
            this.fone_cliente = fone_cliente;
            this.recordKey = $"[{id_endereco_entrega}]|[{cod_cliente}]|[{timestamp}]";
            this.recordXml = recordXml;
        }
    }
}
