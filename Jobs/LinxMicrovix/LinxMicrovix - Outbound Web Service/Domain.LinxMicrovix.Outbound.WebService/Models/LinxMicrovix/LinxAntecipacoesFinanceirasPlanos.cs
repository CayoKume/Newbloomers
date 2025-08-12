
using Domain.Core.Extensions;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Globalization;

namespace Domain.LinxMicrovix.Outbound.WebService.Models.LinxMicrovix
{
    public class LinxAntecipacoesFinanceirasPlanos
    {
        public DateTime lastupdateon { get; private set; }
        public Int32? portal { get; private set; }
        public string? cnpj_emp { get; private set; }
        public Int32? id_antecipacoes_financeiras { get; private set; }
        public Int32? numero_antecipacao { get; private set; }
        public string? forma_pgto { get; private set; }
        public Int32? plano { get; private set; }
        public string? nome_plano { get; private set; }
        public decimal? valor { get; private set; }
        public Int64? timestamp { get; private set; }
        public Int32? id_ordservprod { get; private set; }
        public Int32? id_vendas_pos_produtos_tmp { get; private set; }
        public Int32? id_vendas_pos { get; private set; }
        public bool? cancelado { get; private set; }
        public DateTime? previsao_entrega { get; private set; }
        public Int64? numero_ficha { get; private set; }
        public Int32? id_vendas_pos_produtos_campos_adicionais_tmp { get; private set; }
        public Int32? id_link_pagamento_linx_pay_hub { get; private set; }
        public string? codigo_gerencial { get; private set; }
        public Int32? empresa { get; private set; }

        [NotMapped]
        [SkipProperty]
        public string? recordKey { get; private set; }

        [NotMapped]
        [SkipProperty]
        public string? recordXml { get; private set; }

        public LinxAntecipacoesFinanceirasPlanos() { }

        public LinxAntecipacoesFinanceirasPlanos(Domain.LinxMicrovix.Outbound.WebService.Dtos.LinxMicrovix.LinxAntecipacoesFinanceirasPlanos record, string recordXml) {
            this.lastupdateon = CustomConvertersExtensions.ConvertToDateTimeValidation<DateTime>(DateTime.Now);
            this.empresa = CustomConvertersExtensions.ConvertToInt32Validation(record.empresa);
            this.id_link_pagamento_linx_pay_hub = CustomConvertersExtensions.ConvertToInt32Validation(record.id_link_pagamento_linx_pay_hub);
            this.id_vendas_pos_produtos_campos_adicionais_tmp = CustomConvertersExtensions.ConvertToInt32Validation(record.id_vendas_pos_produtos_campos_adicionais_tmp);
            this.numero_ficha = CustomConvertersExtensions.ConvertToInt64Validation(record.numero_ficha);
            this.previsao_entrega =  CustomConvertersExtensions.ConvertToDateTimeValidation<string>(record.previsao_entrega);
            this.id_ordservprod = CustomConvertersExtensions.ConvertToInt32Validation(record.id_ordservprod);
            this.id_vendas_pos_produtos_tmp = CustomConvertersExtensions.ConvertToInt32Validation(record.id_vendas_pos_produtos_tmp);
            this.id_vendas_pos = CustomConvertersExtensions.ConvertToInt32Validation(record.id_vendas_pos);
            this.id_antecipacoes_financeiras = CustomConvertersExtensions.ConvertToInt32Validation(record.id_antecipacoes_financeiras);
            this.numero_antecipacao = CustomConvertersExtensions.ConvertToInt32Validation(record.numero_antecipacao);
            this.plano = CustomConvertersExtensions.ConvertToInt32Validation(record.plano);
            this.valor = CustomConvertersExtensions.ConvertToDecimalValidation(record.valor);
            this.cancelado = CustomConvertersExtensions.ConvertToBooleanValidation(record.cancelado);
            this.portal = CustomConvertersExtensions.ConvertToInt32Validation(record.portal);
            this.timestamp = CustomConvertersExtensions.ConvertToInt64Validation(record.timestamp);
            this.cnpj_emp = record.cnpj_emp;
            this.codigo_gerencial = record.codigo_gerencial;
            this.forma_pgto = record.forma_pgto;
            this.nome_plano = record.nome_plano;
        }
    }
}
