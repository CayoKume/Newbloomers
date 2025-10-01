
using Domain.Core.Extensions;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Globalization;

namespace Domain.LinxMicrovix.Outbound.WebService.Models.LinxMicrovix
{
    public class LinxDadosOpticosDav
    {
        public DateTime? lastupdateon { get; private set; }
        public Int64? id_vendas_pos_produtos { get; private set; }
        public Int64? cod_produto { get; private set; }
        public Int32? dav { get; private set; }
        public string? tipo_lente { get; private set; }
        public string? od_oe { get; private set; }
        public decimal? lng_esferico_od { get; private set; }
        public decimal? lng_cilindrico_od { get; private set; }
        public decimal? lng_eixo_od { get; private set; }
        public decimal? lng_esferico_oe { get; private set; }
        public decimal? lng_cilindrico_oe { get; private set; }
        public decimal? lng_eixo_oe { get; private set; }
        public decimal? prt_esferico_od { get; private set; }
        public decimal? prt_cilindrico_od { get; private set; }
        public decimal? prt_eixo_od { get; private set; }
        public decimal? prt_esferico_oe { get; private set; }
        public decimal? prt_cilindrico_oe { get; private set; }
        public decimal? prt_eixo_oe { get; private set; }
        public decimal? cmpl_add_od { get; private set; }
        public decimal? base_od { get; private set; }
        public decimal? diametro_od { get; private set; }
        public decimal? cmpl_add_oe { get; private set; }
        public decimal? base_oe { get; private set; }
        public decimal? diametro_oe { get; private set; }
        public decimal? ponte { get; private set; }
        public decimal? altura { get; private set; }
        public decimal? aro { get; private set; }
        public decimal? diag_maior { get; private set; }
        public decimal? dist_haste { get; private set; }
        public decimal? dist_front { get; private set; }
        public string? tipo_armacao { get; private set; }
        public decimal? curvatura { get; private set; }
        public Int32? id_produtos_opticos_tipo_aro { get; private set; }
        public Int32? id_produtos_opticos_formato_aro { get; private set; }
        public decimal? lng_dpdpn_od { get; private set; }
        public decimal? prt_dpdpn_od { get; private set; }
        public decimal? lng_dpdpn_oe { get; private set; }
        public decimal? prt_dpdpn_oe { get; private set; }
        public decimal? lng_altura_od { get; private set; }
        public decimal? prt_altura_od { get; private set; }
        public decimal? lng_altura_oe { get; private set; }
        public decimal? prt_altura_oe { get; private set; }
        public decimal? calibre { get; private set; }
        public decimal? dp_montagem { get; private set; }
        public string? observacao { get; private set; }
        public string? paciente { get; private set; }
        public string? endereco_paciente { get; private set; }
        public string? medico_especialista { get; private set; }
        public string? endereco_medico_especialista { get; private set; }
        public string? refracionista_optico { get; private set; }
        public DateTime? data_receita { get; private set; }
        public Int64? timestamp { get; private set; }
        public Int32? id_ordservprod { get; private set; }
        public Int32? id_vendas_pos_produtos_tmp { get; private set; }
        public Int64? id_vendas_pos { get; private set; }
        public bool? cancelado { get; private set; }
        public DateTime? previsao_entrega { get; private set; }
        public Int64? numero_ficha { get; private set; }
        public Int32? id_vendas_pos_produtos_campos_adicionais_tmp { get; private set; }
        public Int32? id_link_pagamento_linx_pay_hub { get; private set; }
        public string? codigo_gerencial { get; private set; }
        public Int32? empresa { get; private set; }
        public Int32? origem { get; private set; }
        public decimal? acoes_promocionais_desconto { get; private set; }
        public decimal? desconto { get; private set; }
        public decimal? acrescimo { get; private set; }
        public decimal? frete { get; private set; }
        public decimal? descontos_impostos { get; private set; }
        public decimal? acrescimos_impostos { get; private set; }
        public decimal? preco_unitario { get; private set; }
        public decimal? quantidade { get; private set; }
        public decimal? desconto_item { get; private set; }
        public decimal? acrescimo_item_valor { get; private set; }
        public decimal? desconto_item_valor { get; private set; }

        [NotMapped]
        [SkipProperty]
        public string? recordKey { get; private set; }

        [NotMapped]
        [SkipProperty]
        public string? recordXml { get; private set; }

        public LinxDadosOpticosDav() { }

        public LinxDadosOpticosDav(Domain.LinxMicrovix.Outbound.WebService.Dtos.LinxMicrovix.LinxDadosOpticosDav record, string recordXml) {
                        lastupdateon = TimeZoneInfo.ConvertTimeFromUtc(DateTime.UtcNow, TimeZoneInfo.FindSystemTimeZoneById("E. South America Standard Time"));
            this.dav = CustomConvertersExtensions.ConvertToInt32Validation(record.dav);
            this.id_produtos_opticos_tipo_aro = CustomConvertersExtensions.ConvertToInt32Validation(record.id_produtos_opticos_tipo_aro);
            this.id_produtos_opticos_formato_aro = CustomConvertersExtensions.ConvertToInt32Validation(record.id_produtos_opticos_formato_aro);
            this.id_ordservprod = CustomConvertersExtensions.ConvertToInt32Validation(record.id_ordservprod);
            this.id_vendas_pos_produtos_tmp = CustomConvertersExtensions.ConvertToInt32Validation(record.id_vendas_pos_produtos_tmp);
            this.id_vendas_pos_produtos_campos_adicionais_tmp = CustomConvertersExtensions.ConvertToInt32Validation(record.id_vendas_pos_produtos_campos_adicionais_tmp);
            this.id_link_pagamento_linx_pay_hub = CustomConvertersExtensions.ConvertToInt32Validation(record.id_link_pagamento_linx_pay_hub);
            this.empresa = CustomConvertersExtensions.ConvertToInt32Validation(record.empresa);
            this.origem = CustomConvertersExtensions.ConvertToInt32Validation(record.origem);
            this.id_vendas_pos_produtos = CustomConvertersExtensions.ConvertToInt64Validation(record.id_vendas_pos_produtos);
            this.cod_produto = CustomConvertersExtensions.ConvertToInt64Validation(record.cod_produto);
            this.id_vendas_pos = CustomConvertersExtensions.ConvertToInt64Validation(record.id_vendas_pos);
            this.timestamp = CustomConvertersExtensions.ConvertToInt64Validation(record.timestamp);
            this.lng_esferico_od = CustomConvertersExtensions.ConvertToDecimalValidation(record.lng_esferico_od);
            this.lng_cilindrico_od = CustomConvertersExtensions.ConvertToDecimalValidation(record.lng_cilindrico_od);
            this.lng_eixo_od = CustomConvertersExtensions.ConvertToDecimalValidation(record.lng_eixo_od);
            this.lng_esferico_oe = CustomConvertersExtensions.ConvertToDecimalValidation(record.lng_esferico_oe);
            this.lng_cilindrico_oe = CustomConvertersExtensions.ConvertToDecimalValidation(record.lng_cilindrico_oe);
            this.lng_eixo_oe = CustomConvertersExtensions.ConvertToDecimalValidation(record.lng_eixo_oe);
            this.prt_esferico_od = CustomConvertersExtensions.ConvertToDecimalValidation(record.prt_esferico_od);
            this.prt_cilindrico_od = CustomConvertersExtensions.ConvertToDecimalValidation(record.prt_cilindrico_od);
            this.prt_eixo_od = CustomConvertersExtensions.ConvertToDecimalValidation(record.prt_eixo_od);
            this.prt_esferico_oe = CustomConvertersExtensions.ConvertToDecimalValidation(record.prt_esferico_oe);
            this.prt_cilindrico_oe = CustomConvertersExtensions.ConvertToDecimalValidation(record.prt_cilindrico_oe);
            this.prt_eixo_oe = CustomConvertersExtensions.ConvertToDecimalValidation(record.prt_eixo_oe);
            this.cmpl_add_od = CustomConvertersExtensions.ConvertToDecimalValidation(record.cmpl_add_od);
            this.base_od = CustomConvertersExtensions.ConvertToDecimalValidation(record.base_od);
            this.diametro_od = CustomConvertersExtensions.ConvertToDecimalValidation(record.diametro_od);
            this.diametro_od = CustomConvertersExtensions.ConvertToDecimalValidation(record.diametro_od);
            this.base_oe = CustomConvertersExtensions.ConvertToDecimalValidation(record.base_oe);
            this.base_oe = CustomConvertersExtensions.ConvertToDecimalValidation(record.base_oe);
            this.base_oe = CustomConvertersExtensions.ConvertToDecimalValidation(record.base_oe);
            this.altura = CustomConvertersExtensions.ConvertToDecimalValidation(record.altura);
            this.aro = CustomConvertersExtensions.ConvertToDecimalValidation(record.aro);
            this.diag_maior = CustomConvertersExtensions.ConvertToDecimalValidation(record.diag_maior);
            this.diag_maior = CustomConvertersExtensions.ConvertToDecimalValidation(record.diag_maior);
            this.dist_front = CustomConvertersExtensions.ConvertToDecimalValidation(record.dist_front);
            this.curvatura = CustomConvertersExtensions.ConvertToDecimalValidation(record.curvatura);
            this.lng_dpdpn_od = CustomConvertersExtensions.ConvertToDecimalValidation(record.lng_dpdpn_od);
            this.prt_dpdpn_od = CustomConvertersExtensions.ConvertToDecimalValidation(record.prt_dpdpn_od);
            this.lng_dpdpn_oe = CustomConvertersExtensions.ConvertToDecimalValidation(record.lng_dpdpn_oe);
            this.prt_dpdpn_oe = CustomConvertersExtensions.ConvertToDecimalValidation(record.prt_dpdpn_oe);
            this.lng_altura_od = CustomConvertersExtensions.ConvertToDecimalValidation(record.lng_altura_od);
            this.prt_altura_od = CustomConvertersExtensions.ConvertToDecimalValidation(record.prt_altura_od);
            this.lng_altura_oe = CustomConvertersExtensions.ConvertToDecimalValidation(record.lng_altura_oe);
            this.prt_altura_oe = CustomConvertersExtensions.ConvertToDecimalValidation(record.prt_altura_oe);
            this.calibre = CustomConvertersExtensions.ConvertToDecimalValidation(record.calibre);
            this.dp_montagem = CustomConvertersExtensions.ConvertToDecimalValidation(record.dp_montagem);
            this.acoes_promocionais_desconto = CustomConvertersExtensions.ConvertToDecimalValidation(record.acoes_promocionais_desconto);
            this.desconto = CustomConvertersExtensions.ConvertToDecimalValidation(record.desconto);
            this.acrescimo = CustomConvertersExtensions.ConvertToDecimalValidation(record.acrescimo);
            this.frete = CustomConvertersExtensions.ConvertToDecimalValidation(record.frete);
            this.descontos_impostos = CustomConvertersExtensions.ConvertToDecimalValidation(record.descontos_impostos);
            this.acrescimos_impostos = CustomConvertersExtensions.ConvertToDecimalValidation(record.acrescimos_impostos);
            this.preco_unitario = CustomConvertersExtensions.ConvertToDecimalValidation(record.preco_unitario);
            this.quantidade = CustomConvertersExtensions.ConvertToDecimalValidation(record.quantidade);
            this.desconto_item = CustomConvertersExtensions.ConvertToDecimalValidation(record.desconto_item);
            this.acrescimo_item_valor = CustomConvertersExtensions.ConvertToDecimalValidation(record.acrescimo_item_valor);
            this.desconto_item_valor = CustomConvertersExtensions.ConvertToDecimalValidation(record.desconto_item_valor);
            this.previsao_entrega =  CustomConvertersExtensions.ConvertToDateTimeValidation<string>(record.previsao_entrega);
            this.data_receita =  CustomConvertersExtensions.ConvertToDateTimeValidation<string>(record.data_receita);
            this.cancelado = CustomConvertersExtensions.ConvertToBooleanValidation(record.cancelado);
            this.tipo_lente = record.tipo_lente;
            this.od_oe = record.od_oe;
            this.tipo_armacao = record.tipo_armacao;
            this.observacao = record.observacao;
            this.paciente = record.paciente;
            this.endereco_paciente = record.endereco_paciente;
            this.medico_especialista = record.medico_especialista;
            this.endereco_medico_especialista = record.endereco_medico_especialista;
            this.refracionista_optico = record.refracionista_optico;
            this.codigo_gerencial = record.codigo_gerencial;
        }
    }
}
