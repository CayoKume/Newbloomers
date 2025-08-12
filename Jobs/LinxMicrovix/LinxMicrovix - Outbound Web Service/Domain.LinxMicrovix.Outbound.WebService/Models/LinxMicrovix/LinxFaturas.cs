
using Domain.Core.Extensions;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Globalization;

namespace Domain.LinxMicrovix.Outbound.WebService.Models.LinxMicrovix
{
    public class LinxFaturas
    {
        public DateTime? lastupdateon { get; private set; }
        public Int32? portal { get; private set; }
        public string? cnpj_emp { get; private set; }
        public Int64? codigo_fatura { get; private set; }
        public DateTime? data_emissao { get; private set; }
        public Int32? cod_cliente { get; private set; }
        public string? nome_cliente { get; private set; }
        public DateTime? data_vencimento { get; private set; }
        public DateTime? data_baixa { get; private set; }
        public decimal? valor_fatura { get; private set; }
        public decimal? valor_pago { get; private set; }
        public decimal? valor_desconto { get; private set; }
        public decimal? valor_juros { get; private set; }
        public Int32? documento { get; private set; }
        public string? serie { get; private set; }
        public Int32? ecf { get; private set; }
        public string? observacao { get; private set; }
        public Int32? qtde_parcelas { get; private set; }
        public Int32? ordem_parcela { get; private set; }
        public string? receber_pagar { get; private set; }
        public Int32? vendedor { get; private set; }
        public string? excluido { get; private set; }
        public string? cancelado { get; private set; }
        public Guid? identificador { get; private set; }
        public string? nsu { get; private set; }
        public string? cod_autorizacao { get; private set; }
        public string? documento_sem_tef { get; private set; }
        public string? autorizacao_sem_tef { get; private set; }
        public Int32? plano { get; private set; }
        public Int64? conta_credito { get; private set; }
        public Int64? conta_debito { get; private set; }
        public Int64? conta_fluxo { get; private set; }
        public Int64? cod_historico { get; private set; }
        public string? forma_pgto { get; private set; }
        public Int32? ordem_cartao { get; private set; }
        public string? banco_codigo { get; private set; }
        public string? banco_agencia { get; private set; }
        public string? banco_conta { get; private set; }
        public string? banco_autorizacao_garantidora { get; private set; }
        public string? numero_bilhete_seguro { get; private set; }
        public Int64? timestamp { get; private set; }
        public Int32? empresa { get; private set; }
        public Int32? id_categorias_financeiras { get; private set; }
        public decimal? taxa_financeira { get; private set; }
        public decimal? valor_abatimento { get; private set; }
        public decimal? valor_multa { get; private set; }
        public Int32? centrocusto { get; private set; }
        public decimal? perc_taxa_adquirente { get; private set; }
        public string? fatura_origem_importacao_erp { get; private set; }

        [NotMapped]
        [SkipProperty]
        public string? recordKey { get; private set; }

        [NotMapped]
        [SkipProperty]
        public string? recordXml { get; private set; }

        public LinxFaturas() { }

        public LinxFaturas(Domain.LinxMicrovix.Outbound.WebService.Dtos.LinxMicrovix.LinxFaturas record, string recordXml) {
            lastupdateon = CustomConvertersExtensions.ConvertToDateTimeValidation<DateTime>(DateTime.Now);
            this.portal = CustomConvertersExtensions.ConvertToInt32Validation(record.portal);
            this.cod_cliente = CustomConvertersExtensions.ConvertToInt32Validation(record.cod_cliente);
            this.documento = CustomConvertersExtensions.ConvertToInt32Validation(record.documento);
            this.ecf = CustomConvertersExtensions.ConvertToInt32Validation(record.ecf);
            this.qtde_parcelas = CustomConvertersExtensions.ConvertToInt32Validation(record.qtde_parcelas);
            this.ordem_parcela = CustomConvertersExtensions.ConvertToInt32Validation(record.ordem_parcela);
            this.plano = CustomConvertersExtensions.ConvertToInt32Validation(record.plano);
            this.ordem_cartao = CustomConvertersExtensions.ConvertToInt32Validation(record.ordem_cartao);
            this.empresa = CustomConvertersExtensions.ConvertToInt32Validation(record.empresa);
            this.id_categorias_financeiras = CustomConvertersExtensions.ConvertToInt32Validation(record.id_categorias_financeiras);
            this.centrocusto = CustomConvertersExtensions.ConvertToInt32Validation(record.centrocusto);
            this.codigo_fatura = CustomConvertersExtensions.ConvertToInt64Validation(record.codigo_fatura);
            this.conta_credito = CustomConvertersExtensions.ConvertToInt64Validation(record.conta_credito);
            this.conta_debito = CustomConvertersExtensions.ConvertToInt64Validation(record.conta_debito);
            this.conta_fluxo = CustomConvertersExtensions.ConvertToInt64Validation(record.conta_fluxo);
            this.cod_historico = CustomConvertersExtensions.ConvertToInt64Validation(record.cod_historico);
            this.timestamp = CustomConvertersExtensions.ConvertToInt64Validation(record.timestamp);
            this.valor_fatura = CustomConvertersExtensions.ConvertToDecimalValidation(record.valor_fatura);
            this.valor_pago = CustomConvertersExtensions.ConvertToDecimalValidation(record.valor_pago);
            this.valor_desconto = CustomConvertersExtensions.ConvertToDecimalValidation(record.valor_desconto);
            this.valor_juros = CustomConvertersExtensions.ConvertToDecimalValidation(record.valor_juros);
            this.taxa_financeira = CustomConvertersExtensions.ConvertToDecimalValidation(record.taxa_financeira);
            this.valor_abatimento = CustomConvertersExtensions.ConvertToDecimalValidation(record.valor_abatimento);
            this.valor_multa = CustomConvertersExtensions.ConvertToDecimalValidation(record.valor_multa);
            this.perc_taxa_adquirente = CustomConvertersExtensions.ConvertToDecimalValidation(record.perc_taxa_adquirente);
            this.data_emissao =  CustomConvertersExtensions.ConvertToDateTimeValidation<string>(record.data_emissao);
            this.data_vencimento =  CustomConvertersExtensions.ConvertToDateTimeValidation<string>(record.data_vencimento);
            this.data_baixa =  CustomConvertersExtensions.ConvertToDateTimeValidation<string>(record.data_baixa);
            this.identificador = Guid.Parse(record.identificador);
            this.cnpj_emp = record.cnpj_emp;
            this.nome_cliente = record.nome_cliente;
            this.serie = record.serie;
            this.observacao = record.observacao;
            this.receber_pagar = record.receber_pagar;
            this.excluido = record.excluido;
            this.cancelado = record.cancelado;
            this.nsu = record.nsu;
            this.cod_autorizacao = record.cod_autorizacao;
            this.documento_sem_tef = record.documento_sem_tef;
            this.cod_autorizacao = record.cod_autorizacao;
            this.documento_sem_tef = record.documento_sem_tef;
            this.autorizacao_sem_tef = record.autorizacao_sem_tef;
            this.forma_pgto = record.forma_pgto;
            this.banco_codigo = record.banco_codigo;
            this.banco_agencia = record.banco_agencia;
            this.banco_conta = record.banco_conta;
            this.banco_autorizacao_garantidora = record.banco_autorizacao_garantidora;
            this.numero_bilhete_seguro = record.numero_bilhete_seguro;
            this.fatura_origem_importacao_erp = record.fatura_origem_importacao_erp;
        }
    }
}
