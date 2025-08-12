
using Domain.Core.Extensions;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Globalization;

namespace Domain.LinxMicrovix.Outbound.WebService.Models.LinxMicrovix
{
    public class LinxAntecipacoesFinanceiras
    {
        public DateTime lastupdateon { get; private set; }
        public Int32? portal { get; private set; }
        public string? cnpj_emp { get; private set; }
        public Int32? empresa { get; private set; }
        public Int32? cod_cliente { get; private set; }
        public Int32? numero_antecipacao { get; private set; }
        public DateTime? data_antecipacao { get; private set; }
        public DateTime? previsao_entrega { get; private set; }
        public string? dav_pv { get; private set; }
        public Int32? numero_origem { get; private set; }
        public Int32? dav_remessa { get; private set; }
        public Int64? codigoproduto { get; private set; }
        public decimal? quantidade { get; private set; }
        public decimal? preco_unitario_produto { get; private set; }
        public decimal? valor_pago_antecipacao { get; private set; }
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

        public LinxAntecipacoesFinanceiras(Domain.LinxMicrovix.Outbound.WebService.Dtos.LinxMicrovix.LinxAntecipacoesFinanceiras record, string recordXml) {
            this.lastupdateon = CustomConvertersExtensions.ConvertToDateTimeValidation<DateTime>(DateTime.Now);
            this.empresa = CustomConvertersExtensions.ConvertToInt32Validation(record.empresa);
            this.id_antecipacoes_financeiras = CustomConvertersExtensions.ConvertToInt32Validation(record.id_antecipacoes_financeiras);
            this.id_antecipacoes_financeiras_detalhes = CustomConvertersExtensions.ConvertToInt32Validation(record.id_antecipacoes_financeiras_detalhes);
            this.id_vendas_pos_produtos = CustomConvertersExtensions.ConvertToInt32Validation(record.id_vendas_pos_produtos);
            this.cod_cliente = CustomConvertersExtensions.ConvertToInt32Validation(record.cod_cliente);
            this.numero_antecipacao = CustomConvertersExtensions.ConvertToInt32Validation(record.numero_antecipacao);
            this.data_antecipacao =  CustomConvertersExtensions.ConvertToDateTimeValidation<string>(record.data_antecipacao);
            this.previsao_entrega =  CustomConvertersExtensions.ConvertToDateTimeValidation<string>(record.previsao_entrega);
            this.dav_remessa = CustomConvertersExtensions.ConvertToInt32Validation(record.dav_remessa);
            this.codigoproduto = CustomConvertersExtensions.ConvertToInt64Validation(record.codigoproduto);
            this.quantidade = CustomConvertersExtensions.ConvertToDecimalValidation(record.quantidade);
            this.preco_unitario_produto = CustomConvertersExtensions.ConvertToDecimalValidation(record.preco_unitario_produto);
            this.valor_pago_antecipacao = CustomConvertersExtensions.ConvertToDecimalValidation(record.valor_pago_antecipacao);
            this.identificador = Guid.Parse(record.identificador);
            this.cancelado = CustomConvertersExtensions.ConvertToBooleanValidation(record.cancelado);
            this.portal = CustomConvertersExtensions.ConvertToInt32Validation(record.portal);
            this.timestamp = CustomConvertersExtensions.ConvertToInt64Validation(record.timestamp);
            this.entregue = record.entregue;
            this.dav_pv = record.dav_pv;
            this.cnpj_emp = record.cnpj_emp;
        }
    }
}
