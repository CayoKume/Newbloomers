using Domain.LinxMicrovix.Outbound.WebService.CustomValidations;
using Domain.IntegrationsCore.Extensions;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Globalization;

namespace Domain.LinxMicrovix.Outbound.WebService.Models.LinxMicrovix
{
    public class LinxAntecipacoesFinanceiras
    {
        [SkipProperty]
        public Int32 id { get; set; }

        public DateTime lastupdateon { get; private set; }

        public Int32? portal { get; private set; }

        [LengthValidation(length: 14, propertyName: "cnpj_emp")]
        public string? cnpj_emp { get; private set; }

        public Int32? empresa { get; private set; }

        public Int32? cod_cliente { get; private set; }

        public Int32? numero_antecipacao { get; private set; }

        public DateTime? data_antecipacao { get; private set; }

        public DateTime? previsao_entrega { get; private set; }

        [LengthValidation(length: 3, propertyName: "dav_pv")]
        public string? dav_pv { get; private set; }

        public Int32? numero_origem { get; private set; }

        public Int32? dav_remessa { get; private set; }

        public Int64? codigoproduto { get; private set; }

        public decimal? quantidade { get; private set; }

        public decimal? preco_unitario_produto { get; private set; }

        public decimal? valor_pago_antecipacao { get; private set; }

        [LengthValidation(length: 1, propertyName: "entregue")]
        public string? entregue { get; private set; }

        public Guid? identificador { get; private set; }

        public Int64? timestamp { get; private set; }

        public bool? cancelado { get; private set; }

        public Int32? id_antecipacoes_financeiras { get; private set; }

        public Int32? id_antecipacoes_financeiras_detalhes { get; private set; }

        public Int32? id_vendas_pos_produtos { get; private set; }

        [NotMapped]
        [SkipProperty]
        public string? recordKey { get; private set; }

        [NotMapped]
        [SkipProperty]
        public string? recordXml { get; private set; }

        public LinxAntecipacoesFinanceiras() { }

        public LinxAntecipacoesFinanceiras(
            List<ValidationResult> listValidations,
            string? portal,
            string? cnpj_emp,
            string? empresa,
            string? cod_cliente,
            string? numero_antecipacao,
            string? data_antecipacao,
            string? previsao_entrega,
            string? dav_pv,
            string? numero_origem,
            string? dav_remessa,
            string? codigoproduto,
            string? quantidade,
            string? preco_unitario_produto,
            string? valor_pago_antecipacao,
            string? entregue,
            string? identificador,
            string? timestamp,
            string? cancelado,
            string? id_antecipacoes_financeiras,
            string? id_antecipacoes_financeiras_detalhes,
            string? id_vendas_pos_produtos
        )
        {
            this.lastupdateon = DateTime.Now;

            this.empresa =
                ConvertToInt32Validation.IsValid(empresa, "empresa", listValidations) ?
                Convert.ToInt32(empresa) :
                0;

            this.id_antecipacoes_financeiras =
                ConvertToInt32Validation.IsValid(id_antecipacoes_financeiras, "id_antecipacoes_financeiras", listValidations) ?
                Convert.ToInt32(id_antecipacoes_financeiras) :
                0;

            this.id_antecipacoes_financeiras_detalhes =
                ConvertToInt32Validation.IsValid(id_antecipacoes_financeiras_detalhes, "id_antecipacoes_financeiras_detalhes", listValidations) ?
                Convert.ToInt32(id_antecipacoes_financeiras_detalhes) :
                0;

            this.id_vendas_pos_produtos =
                ConvertToInt32Validation.IsValid(id_vendas_pos_produtos, "id_vendas_pos_produtos", listValidations) ?
                Convert.ToInt32(id_vendas_pos_produtos) :
                0;

            this.cod_cliente =
                ConvertToInt32Validation.IsValid(cod_cliente, "cod_cliente", listValidations) ?
                Convert.ToInt32(cod_cliente) :
                0;

            this.numero_antecipacao =
                ConvertToInt32Validation.IsValid(numero_antecipacao, "numero_antecipacao", listValidations) ?
                Convert.ToInt32(numero_antecipacao) :
                0;

            this.data_antecipacao =
                ConvertToDateTimeValidation.IsValid(data_antecipacao, "data_antecipacao", listValidations) ?
                Convert.ToDateTime(data_antecipacao) :
                new DateTime(1990, 01, 01, 00, 00, 00, new CultureInfo("en-US").Calendar);

            this.previsao_entrega =
                ConvertToDateTimeValidation.IsValid(previsao_entrega, "previsao_entrega", listValidations) ?
                Convert.ToDateTime(previsao_entrega) :
                new DateTime(1990, 01, 01, 00, 00, 00, new CultureInfo("en-US").Calendar);

            this.dav_remessa =
                ConvertToInt32Validation.IsValid(dav_remessa, "dav_remessa", listValidations) ?
                Convert.ToInt32(dav_remessa) :
                0;

            this.codigoproduto =
                ConvertToInt64Validation.IsValid(codigoproduto, "codigoproduto", listValidations) ?
                Convert.ToInt64(codigoproduto) :
                0;

            this.quantidade =
                ConvertToDecimalValidation.IsValid(quantidade, "quantidade", listValidations) ?
                Convert.ToDecimal(quantidade, new CultureInfo("en-US")) :
                0;

            this.preco_unitario_produto =
                ConvertToDecimalValidation.IsValid(preco_unitario_produto, "preco_unitario_produto", listValidations) ?
                Convert.ToDecimal(preco_unitario_produto, new CultureInfo("en-US")) :
                0;

            this.valor_pago_antecipacao =
                ConvertToDecimalValidation.IsValid(valor_pago_antecipacao, "valor_pago_antecipacao", listValidations) ?
                Convert.ToDecimal(valor_pago_antecipacao, new CultureInfo("en-US")) :
                0;

            this.identificador =
                String.IsNullOrEmpty(identificador) ? null
                : Guid.Parse(identificador);

            this.cancelado =
                ConvertToBooleanValidation.IsValid(cancelado, "cancelado", listValidations) ?
                Convert.ToBoolean(cancelado) :
                false;

            this.portal =
                ConvertToInt32Validation.IsValid(portal, "portal", listValidations) ?
                Convert.ToInt32(portal) :
                0;

            this.timestamp =
                ConvertToInt64Validation.IsValid(timestamp, "timestamp", listValidations) ?
                Convert.ToInt64(timestamp) :
                0;

            this.entregue = entregue;
            this.dav_pv = dav_pv;
            this.cnpj_emp = cnpj_emp;
        }
    }
}
