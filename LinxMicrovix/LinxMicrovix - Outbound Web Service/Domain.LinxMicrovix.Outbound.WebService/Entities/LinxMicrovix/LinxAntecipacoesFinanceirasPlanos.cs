using Domain.LinxMicrovix.Outbound.WebService.CustomValidations;
using Domain.IntegrationsCore.Extensions;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Globalization;

namespace Domain.LinxMicrovix.Outbound.WebService.Entites.LinxMicrovix
{
    public class LinxAntecipacoesFinanceirasPlanos
    {
        public DateTime lastupdateon { get; private set; }

        public Int32? portal { get; private set; }

        [LengthValidation(length: 14, propertyName: "cnpj_emp")]
        public string? cnpj_emp { get; private set; }

        public Int32? id_antecipacoes_financeiras { get; private set; }

        public Int32? numero_antecipacao { get; private set; }

        [LengthValidation(length: 50, propertyName: "forma_pgto")]
        public string? forma_pgto { get; private set; }

        public Int32? plano { get; private set; }

        [LengthValidation(length: 35, propertyName: "nome_plano")]
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

        [LengthValidation(length: 20, propertyName: "codigo_gerencial")]
        public string? codigo_gerencial { get; private set; }

        public Int32? empresa { get; private set; }

        [NotMapped]
        [SkipProperty]
        public string? recordKey { get; private set; }

        [NotMapped]
        [SkipProperty]
        public string? recordXml { get; private set; }

        public LinxAntecipacoesFinanceirasPlanos() { }

        public LinxAntecipacoesFinanceirasPlanos(
            List<ValidationResult> listValidations,
            string? portal,
            string? cnpj_emp,
            string? id_antecipacoes_financeiras,
            string? numero_antecipacao,
            string? forma_pgto,
            string? plano,
            string? nome_plano,
            string? valor,
            string? cancelado,
            string? timestamp,
            string? id_ordservprod,
            string? id_vendas_pos_produtos_tmp,
            string? id_vendas_pos,
            string? previsao_entrega,
            string? numero_ficha,
            string? id_vendas_pos_produtos_campos_adicionais_tmp,
            string? id_link_pagamento_linx_pay_hub,
            string? codigo_gerencial,
            string? empresa
        )
        {
            this.lastupdateon = DateTime.Now;

            this.empresa =
                ConvertToInt32Validation.IsValid(empresa, "empresa", listValidations) ?
                Convert.ToInt32(empresa) :
                0;

            this.id_link_pagamento_linx_pay_hub =
                ConvertToInt32Validation.IsValid(id_link_pagamento_linx_pay_hub, "id_link_pagamento_linx_pay_hub", listValidations) ?
                Convert.ToInt32(id_link_pagamento_linx_pay_hub) :
                0;

            this.id_vendas_pos_produtos_campos_adicionais_tmp =
                ConvertToInt32Validation.IsValid(id_vendas_pos_produtos_campos_adicionais_tmp, "id_vendas_pos_produtos_campos_adicionais_tmp", listValidations) ?
                Convert.ToInt32(id_vendas_pos_produtos_campos_adicionais_tmp) :
                0;

            this.numero_ficha =
                ConvertToInt64Validation.IsValid(numero_ficha, "numero_ficha", listValidations) ?
                Convert.ToInt64(numero_ficha) :
                0;

            this.previsao_entrega =
                ConvertToDateTimeValidation.IsValid(previsao_entrega, "previsao_entrega", listValidations) ?
                Convert.ToDateTime(previsao_entrega) :
                new DateTime(1990, 01, 01, 00, 00, 00, new CultureInfo("en-US").Calendar);

            this.id_ordservprod =
                ConvertToInt32Validation.IsValid(id_ordservprod, "id_ordservprod", listValidations) ?
                Convert.ToInt32(id_ordservprod) :
                0;

            this.id_vendas_pos_produtos_tmp =
                ConvertToInt32Validation.IsValid(id_vendas_pos_produtos_tmp, "id_vendas_pos_produtos_tmp", listValidations) ?
                Convert.ToInt32(id_vendas_pos_produtos_tmp) :
                0;

            this.id_vendas_pos =
                ConvertToInt32Validation.IsValid(id_vendas_pos, "id_vendas_pos", listValidations) ?
                Convert.ToInt32(id_vendas_pos) :
                0;

            this.id_antecipacoes_financeiras =
                ConvertToInt32Validation.IsValid(id_antecipacoes_financeiras, "id_antecipacoes_financeiras", listValidations) ?
                Convert.ToInt32(id_antecipacoes_financeiras) :
                0;

            this.numero_antecipacao =
                ConvertToInt32Validation.IsValid(numero_antecipacao, "numero_antecipacao", listValidations) ?
                Convert.ToInt32(numero_antecipacao) :
                0;

            this.plano =
                ConvertToInt32Validation.IsValid(plano, "plano", listValidations) ?
                Convert.ToInt32(plano) :
                0;

            this.valor =
                ConvertToDecimalValidation.IsValid(valor, "valor", listValidations) ?
                Convert.ToDecimal(valor, new CultureInfo("en-US")) :
                0;

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

            this.cnpj_emp = cnpj_emp;
            this.codigo_gerencial = codigo_gerencial;
            this.forma_pgto = forma_pgto;
            this.nome_plano = nome_plano;
        }
    }
}
