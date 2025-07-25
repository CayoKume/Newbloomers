using Domain.LinxMicrovix.Outbound.WebService.CustomValidations;
using Domain.IntegrationsCore.Extensions;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Globalization;

namespace Domain.LinxMicrovix.Outbound.WebService.Models.LinxMicrovix
{
    public class LinxMovimentoTrocas
    {
        [SkipProperty]
        public Int32 id { get; set; }

        public DateTime? lastupdateon { get; private set; }

        public Int32? portal { get; private set; }

        [LengthValidation(length: 14, propertyName: "cnpj_emp")]
        public string? cnpj_emp { get; private set; }

        public Guid? identificador { get; private set; }

        public Int64? num_vale { get; private set; }

        public decimal? valor_vale { get; private set; }

        [LengthValidation(length: 50, propertyName: "motivo")]
        public string? motivo { get; private set; }

        public Int32? doc_origem { get; private set; }

        [LengthValidation(length: 10, propertyName: "serie_origem")]
        public string? serie_origem { get; private set; }

        public Int32? doc_venda { get; private set; }

        [LengthValidation(length: 10, propertyName: "serie_venda")]
        public string? serie_venda { get; private set; }
        public bool? excluido { get; private set; }

        public Int64? timestamp { get; private set; }

        public Int32? desfazimento { get; private set; }

        public Int32? empresa { get; private set; }

        public Int32? vale_cod_cliente { get; private set; }

        public Int64? vale_codigoproduto { get; private set; }

        public Int32? id_vale_ordem_servico_externa { get; private set; }

        public Int32? doc_venda_origem { get; private set; }

        [LengthValidation(length: 10, propertyName: "serie_venda_origem")]
        public string? serie_venda_origem { get; private set; }

        public Int32? cod_cliente { get; private set; }

        [NotMapped]
        [SkipProperty]
        public string? recordKey { get; private set; }

        [NotMapped]
        [SkipProperty]
        public string? recordXml { get; private set; }

        public LinxMovimentoTrocas() { }

        public LinxMovimentoTrocas(
            List<ValidationResult> listValidations,
            string? portal,
            string? cnpj_emp,
            string? identificador,
            string? num_vale,
            string? valor_vale,
            string? motivo,
            string? doc_origem,
            string? serie_origem,
            string? doc_venda,
            string? serie_venda,
            string? excluido,
            string? timestamp,
            string? desfazimento,
            string? empresa,
            string? vale_cod_cliente,
            string? vale_codigoproduto,
            string? id_vale_ordem_servico_externa,
            string? doc_venda_origem,
            string? serie_venda_origem,
            string? cod_cliente,
            string? recordXml
        )
        {
            lastupdateon = DateTime.Now;

            this.doc_origem =
                ConvertToInt32Validation.IsValid(doc_origem, "doc_origem", listValidations) ?
                Convert.ToInt32(doc_origem) :
                0;

            this.doc_venda =
                ConvertToInt32Validation.IsValid(doc_venda, "doc_venda", listValidations) ?
                Convert.ToInt32(doc_venda) :
                0;

            this.empresa =
                ConvertToInt32Validation.IsValid(empresa, "empresa", listValidations) ?
                Convert.ToInt32(empresa) :
                0;

            this.vale_cod_cliente =
                ConvertToInt32Validation.IsValid(vale_cod_cliente, "vale_cod_cliente", listValidations) ?
                Convert.ToInt32(vale_cod_cliente) :
                0;

            this.id_vale_ordem_servico_externa =
                ConvertToInt32Validation.IsValid(id_vale_ordem_servico_externa, "id_vale_ordem_servico_externa", listValidations) ?
                Convert.ToInt32(id_vale_ordem_servico_externa) :
                0;

            this.doc_venda_origem =
                ConvertToInt32Validation.IsValid(doc_venda_origem, "doc_venda_origem", listValidations) ?
                Convert.ToInt32(doc_venda_origem) :
                0;

            this.cod_cliente =
                ConvertToInt32Validation.IsValid(cod_cliente, "cod_cliente", listValidations) ?
                Convert.ToInt32(cod_cliente) :
                0;

            this.portal =
                ConvertToInt32Validation.IsValid(portal, "portal", listValidations) ?
                Convert.ToInt32(portal) :
                0;

            this.timestamp =
                ConvertToInt64Validation.IsValid(timestamp, "timestamp", listValidations) ?
                Convert.ToInt64(timestamp) :
                0;

            this.num_vale =
                ConvertToInt64Validation.IsValid(num_vale, "num_vale", listValidations) ?
                Convert.ToInt64(num_vale) :
                0;

            this.vale_codigoproduto =
                ConvertToInt64Validation.IsValid(vale_codigoproduto, "vale_codigoproduto", listValidations) ?
                Convert.ToInt64(vale_codigoproduto) :
                0;

            this.valor_vale =
                ConvertToDecimalValidation.IsValid(valor_vale, "valor_vale", listValidations) ?
                Convert.ToDecimal(valor_vale, new CultureInfo("en-US")) :
                0;

            this.excluido =
                ConvertToBooleanValidation.IsValid(excluido, "excluido", listValidations) ?
                Convert.ToBoolean(excluido) :
                false;

            this.desfazimento =
                ConvertToInt32Validation.IsValid(desfazimento, "desfazimento", listValidations) ?
                Convert.ToInt32(desfazimento) :
                0;

            this.identificador =
                String.IsNullOrEmpty(identificador) ? new Guid()
                : Guid.Parse(identificador);

            this.cnpj_emp = cnpj_emp;
            this.motivo = motivo;
            this.serie_origem = serie_origem;
            this.serie_venda = serie_venda;
            this.serie_venda_origem = serie_venda_origem;
            this.recordKey = $"[{cnpj_emp}]|[{num_vale}]|[{doc_origem}]|[{doc_venda}]|[{doc_venda_origem}]|[{cod_cliente}]|[{timestamp}]";
            this.recordXml = recordXml;
        }
    }
}
