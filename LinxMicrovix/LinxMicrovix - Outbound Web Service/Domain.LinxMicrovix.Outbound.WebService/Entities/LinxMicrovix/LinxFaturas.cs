using Domain.LinxMicrovix.Outbound.WebService.CustomValidations;
using Domain.IntegrationsCore.Extensions;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Globalization;

namespace Domain.LinxMicrovix.Outbound.WebService.Entities.LinxMicrovix
{
    public class LinxFaturas
    {
        [SkipProperty]
        public Int32 id { get; set; }

        public DateTime? lastupdateon { get; private set; }

        public Int32? portal { get; private set; }

        [LengthValidation(length: 14, propertyName: "cnpj_emp")]
        public string? cnpj_emp { get; private set; }

        public Int64? codigo_fatura { get; private set; }

        public DateTime? data_emissao { get; private set; }

        public Int32? cod_cliente { get; private set; }

        [LengthValidation(length: 60, propertyName: "nome_cliente")]
        public string? nome_cliente { get; private set; }

        public DateTime? data_vencimento { get; private set; }

        public DateTime? data_baixa { get; private set; }

        public decimal? valor_fatura { get; private set; }

        public decimal? valor_pago { get; private set; }

        public decimal? valor_desconto { get; private set; }

        public decimal? valor_juros { get; private set; }

        public Int32? documento { get; private set; }

        [LengthValidation(length: 10, propertyName: "serie")]
        public string? serie { get; private set; }

        public Int32? ecf { get; private set; }

        public string? observacao { get; private set; }

        public Int32? qtde_parcelas { get; private set; }

        public Int32? ordem_parcela { get; private set; }

        [LengthValidation(length: 1, propertyName: "receber_pagar")]
        public string? receber_pagar { get; private set; }

        public Int32? vendedor { get; private set; }

        [LengthValidation(length: 1, propertyName: "excluido")]
        public string? excluido { get; private set; }

        [LengthValidation(length: 1, propertyName: "cancelado")]
        public string? cancelado { get; private set; }

        public Guid? identificador { get; private set; }

        [LengthValidation(length: 50, propertyName: "nsu")]
        public string? nsu { get; private set; }

        [LengthValidation(length: 50, propertyName: "cod_autorizacao")]
        public string? cod_autorizacao { get; private set; }

        [LengthValidation(length: 350, propertyName: "documento_sem_tef")]
        public string? documento_sem_tef { get; private set; }

        [LengthValidation(length: 30, propertyName: "autorizacao_sem_tef")]
        public string? autorizacao_sem_tef { get; private set; }

        public Int32? plano { get; private set; }

        public Int64? conta_credito { get; private set; }

        public Int64? conta_debito { get; private set; }

        public Int64? conta_fluxo { get; private set; }

        public Int64? cod_historico { get; private set; }

        [LengthValidation(length: 50, propertyName: "forma_pgto")]
        public string? forma_pgto { get; private set; }

        public Int32? ordem_cartao { get; private set; }

        [LengthValidation(length: 10, propertyName: "banco_codigo")]
        public string? banco_codigo { get; private set; }

        [LengthValidation(length: 30, propertyName: "banco_agencia")]
        public string? banco_agencia { get; private set; }

        [LengthValidation(length: 30, propertyName: "banco_conta")]
        public string? banco_conta { get; private set; }

        [LengthValidation(length: 30, propertyName: "banco_autorizacao_garantidora")]
        public string? banco_autorizacao_garantidora { get; private set; }

        [LengthValidation(length: 30, propertyName: "numero_bilhete_seguro")]
        public string? numero_bilhete_seguro { get; private set; }

        public Int64? timestamp { get; private set; }

        public Int32? empresa { get; private set; }

        public Int32? id_categorias_financeiras { get; private set; }

        public decimal? taxa_financeira { get; private set; }

        public decimal? valor_abatimento { get; private set; }

        public decimal? valor_multa { get; private set; }

        public Int32? centrocusto { get; private set; }

        public decimal? perc_taxa_adquirente { get; private set; }

        [LengthValidation(length: 50, propertyName: "fatura_origem_importacao_erp")]
        public string? fatura_origem_importacao_erp { get; private set; }

        [NotMapped]
        [SkipProperty]
        public string? recordKey { get; private set; }

        [NotMapped]
        [SkipProperty]
        public string? recordXml { get; private set; }

        public LinxFaturas() { }

        public LinxFaturas(
            List<ValidationResult> listValidations,
            string? portal,
            string? cnpj_emp,
            string? codigo_fatura,
            string? data_emissao,
            string? cod_cliente,
            string? nome_cliente,
            string? data_vencimento,
            string? data_baixa,
            string? valor_fatura,
            string? valor_pago,
            string? valor_desconto,
            string? valor_juros,
            string? documento,
            string? serie,
            string? ecf,
            string? observacao,
            string? qtde_parcelas,
            string? ordem_parcela,
            string? receber_pagar,
            string? vendedor,
            string? excluido,
            string? cancelado,
            string? identificador,
            string? nsu,
            string? cod_autorizacao,
            string? documento_sem_tef,
            string? autorizacao_sem_tef,
            string? plano,
            string? conta_credito,
            string? conta_debito,
            string? conta_fluxo,
            string? cod_historico,
            string? forma_pgto,
            string? ordem_cartao,
            string? banco_codigo,
            string? banco_agencia,
            string? banco_conta,
            string? banco_autorizacao_garantidora,
            string? numero_bilhete_seguro,
            string? timestamp,
            string? empresa,
            string? id_categorias_financeiras,
            string? taxa_financeira,
            string? valor_abatimento,
            string? valor_multa,
            string? centrocusto,
            string? perc_taxa_adquirente,
            string? fatura_origem_importacao_erp
        )
        {
            lastupdateon = DateTime.Now;

            this.portal =
                ConvertToInt32Validation.IsValid(portal, "portal", listValidations) ?
                Convert.ToInt32(portal) :
                0;

            this.cod_cliente =
                ConvertToInt32Validation.IsValid(cod_cliente, "cod_cliente", listValidations) ?
                Convert.ToInt32(cod_cliente) :
                0;

            this.documento =
                ConvertToInt32Validation.IsValid(documento, "documento", listValidations) ?
                Convert.ToInt32(documento) :
                0;

            this.ecf =
                ConvertToInt32Validation.IsValid(ecf, "ecf", listValidations) ?
                Convert.ToInt32(ecf) :
                0;

            this.qtde_parcelas =
                ConvertToInt32Validation.IsValid(qtde_parcelas, "qtde_parcelas", listValidations) ?
                Convert.ToInt32(qtde_parcelas) :
                0;

            this.ordem_parcela =
                ConvertToInt32Validation.IsValid(ordem_parcela, "ordem_parcela", listValidations) ?
                Convert.ToInt32(ordem_parcela) :
                0;

            this.plano =
                ConvertToInt32Validation.IsValid(plano, "plano", listValidations) ?
                Convert.ToInt32(plano) :
                0;

            this.ordem_cartao =
                ConvertToInt32Validation.IsValid(ordem_cartao, "ordem_cartao", listValidations) ?
                Convert.ToInt32(ordem_cartao) :
                0;

            this.empresa =
                ConvertToInt32Validation.IsValid(empresa, "empresa", listValidations) ?
                Convert.ToInt32(empresa) :
                0;

            this.id_categorias_financeiras =
                ConvertToInt32Validation.IsValid(id_categorias_financeiras, "id_categorias_financeiras", listValidations) ?
                Convert.ToInt32(id_categorias_financeiras) :
                0;

            this.centrocusto =
                ConvertToInt32Validation.IsValid(centrocusto, "centrocusto", listValidations) ?
                Convert.ToInt32(centrocusto) :
                0;

            this.codigo_fatura =
                ConvertToInt64Validation.IsValid(codigo_fatura, "codigo_fatura", listValidations) ?
                Convert.ToInt64(codigo_fatura) :
                0;

            this.conta_credito =
                ConvertToInt64Validation.IsValid(conta_credito, "conta_credito", listValidations) ?
                Convert.ToInt64(conta_credito) :
                0;

            this.conta_debito =
                ConvertToInt64Validation.IsValid(conta_debito, "conta_debito", listValidations) ?
                Convert.ToInt64(conta_debito) :
                0;

            this.conta_fluxo =
                ConvertToInt64Validation.IsValid(conta_fluxo, "conta_fluxo", listValidations) ?
                Convert.ToInt64(conta_fluxo) :
                0;

            this.cod_historico =
                ConvertToInt64Validation.IsValid(cod_historico, "cod_historico", listValidations) ?
                Convert.ToInt64(cod_historico) :
                0;

            this.timestamp =
                ConvertToInt64Validation.IsValid(timestamp, "timestamp", listValidations) ?
                Convert.ToInt64(timestamp) :
                0;

            this.valor_fatura =
                ConvertToDecimalValidation.IsValid(valor_fatura, "valor_fatura", listValidations) ?
                Convert.ToDecimal(valor_fatura, new CultureInfo("en-US")) :
                0;

            this.valor_pago =
                ConvertToDecimalValidation.IsValid(valor_pago, "valor_pago", listValidations) ?
                Convert.ToDecimal(valor_pago, new CultureInfo("en-US")) :
                0;

            this.valor_desconto =
                ConvertToDecimalValidation.IsValid(valor_desconto, "valor_desconto", listValidations) ?
                Convert.ToDecimal(valor_desconto, new CultureInfo("en-US")) :
                0;

            this.valor_juros =
                ConvertToDecimalValidation.IsValid(valor_juros, "valor_juros", listValidations) ?
                Convert.ToDecimal(valor_juros, new CultureInfo("en-US")) :
                0;

            this.taxa_financeira =
                ConvertToDecimalValidation.IsValid(taxa_financeira, "taxa_financeira", listValidations) ?
                Convert.ToDecimal(taxa_financeira, new CultureInfo("en-US")) :
                0;

            this.valor_abatimento =
                ConvertToDecimalValidation.IsValid(valor_abatimento, "valor_abatimento", listValidations) ?
                Convert.ToDecimal(valor_abatimento, new CultureInfo("en-US")) :
                0;

            this.valor_multa =
                ConvertToDecimalValidation.IsValid(valor_multa, "valor_multa", listValidations) ?
                Convert.ToDecimal(valor_multa, new CultureInfo("en-US")) :
                0;

            this.perc_taxa_adquirente =
                ConvertToDecimalValidation.IsValid(perc_taxa_adquirente, "perc_taxa_adquirente", listValidations) ?
                Convert.ToDecimal(perc_taxa_adquirente, new CultureInfo("en-US")) :
                0;

            this.data_emissao =
                ConvertToDateTimeValidation.IsValid(data_emissao, "data_emissao", listValidations) ?
                Convert.ToDateTime(data_emissao) :
                new DateTime(1990, 01, 01, 00, 00, 00, new CultureInfo("en-US").Calendar);

            this.data_vencimento =
                ConvertToDateTimeValidation.IsValid(data_vencimento, "data_vencimento", listValidations) ?
                Convert.ToDateTime(data_vencimento) :
                new DateTime(1990, 01, 01, 00, 00, 00, new CultureInfo("en-US").Calendar);

            this.data_baixa =
                ConvertToDateTimeValidation.IsValid(data_baixa, "data_baixa", listValidations) ?
                Convert.ToDateTime(data_baixa) :
                new DateTime(1990, 01, 01, 00, 00, 00, new CultureInfo("en-US").Calendar);

            this.identificador =
                String.IsNullOrEmpty(identificador) ? null
                : Guid.Parse(identificador);

            this.cnpj_emp = cnpj_emp;
            this.nome_cliente = nome_cliente;
            this.serie = serie;
            this.observacao = observacao;
            this.receber_pagar = receber_pagar;
            this.excluido = excluido;
            this.cancelado = cancelado;
            this.nsu = nsu;
            this.cod_autorizacao = cod_autorizacao;
            this.documento_sem_tef = documento_sem_tef;
            this.cod_autorizacao = cod_autorizacao;
            this.documento_sem_tef = documento_sem_tef;
            this.autorizacao_sem_tef = autorizacao_sem_tef;
            this.forma_pgto = forma_pgto;
            this.banco_codigo = banco_codigo;
            this.banco_agencia = banco_agencia;
            this.banco_conta = banco_conta;
            this.banco_autorizacao_garantidora = banco_autorizacao_garantidora;
            this.numero_bilhete_seguro = numero_bilhete_seguro;
            this.fatura_origem_importacao_erp = fatura_origem_importacao_erp;
        }
    }
}
