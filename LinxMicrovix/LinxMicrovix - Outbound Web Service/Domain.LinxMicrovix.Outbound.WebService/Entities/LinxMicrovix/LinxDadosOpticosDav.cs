using Domain.LinxMicrovix.Outbound.WebService.CustomValidations;
using Domain.IntegrationsCore.Extensions;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Globalization;

namespace Domain.LinxMicrovix.Outbound.WebService.Entites.LinxMicrovix
{
    public class LinxDadosOpticosDav
    {
        [SkipProperty]
        public Int32 id { get; set; }

        public DateTime? lastupdateon { get; private set; }

        public Int64? id_vendas_pos_produtos { get; private set; }

        public Int64? cod_produto { get; private set; }

        public Int32? dav { get; private set; }

        [LengthValidation(length: 20, propertyName: "tipo_lente")]
        public string? tipo_lente { get; private set; }

        [LengthValidation(length: 2, propertyName: "od_oe")]
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

        [LengthValidation(length: 1, propertyName: "tipo_armacao")]
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

        [LengthValidation(length: 100, propertyName: "paciente")]
        public string? paciente { get; private set; }

        [LengthValidation(length: 100, propertyName: "endereco_paciente")]
        public string? endereco_paciente { get; private set; }

        [LengthValidation(length: 100, propertyName: "medico_especialista")]
        public string? medico_especialista { get; private set; }

        [LengthValidation(length: 100, propertyName: "endereco_medico_especialista")]
        public string? endereco_medico_especialista { get; private set; }

        [LengthValidation(length: 100, propertyName: "refracionista_optico")]
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

        [LengthValidation(length: 20, propertyName: "codigo_gerencial")]
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

        public LinxDadosOpticosDav(
            List<ValidationResult> listValidations,
            string? id_vendas_pos_produtos,
            string? cod_produto,
            string? dav,
            string? tipo_lente,
            string? od_oe,
            string? lng_esferico_od,
            string? lng_cilindrico_od,
            string? lng_eixo_od,
            string? lng_esferico_oe,
            string? lng_cilindrico_oe,
            string? lng_eixo_oe,
            string? prt_esferico_od,
            string? prt_cilindrico_od,
            string? prt_eixo_od,
            string? prt_esferico_oe,
            string? prt_cilindrico_oe,
            string? prt_eixo_oe,
            string? cmpl_add_od,
            string? base_od,
            string? diametro_od,
            string? cmpl_add_oe,
            string? base_oe,
            string? diametro_oe,
            string? ponte,
            string? altura,
            string? aro,
            string? diag_maior,
            string? dist_haste,
            string? dist_front,
            string? tipo_armacao,
            string? curvatura,
            string? id_produtos_opticos_tipo_aro,
            string? id_produtos_opticos_formato_aro,
            string? lng_dpdpn_od,
            string? prt_dpdpn_od,
            string? lng_dpdpn_oe,
            string? prt_dpdpn_oe,
            string? lng_altura_od,
            string? prt_altura_od,
            string? lng_altura_oe,
            string? prt_altura_oe,
            string? calibre,
            string? dp_montagem,
            string? observacao,
            string? paciente,
            string? endereco_paciente,
            string? medico_especialista,
            string? endereco_medico_especialista,
            string? refracionista_optico,
            string? data_receita,
            string? timestamp,
            string? id_ordservprod,
            string? id_vendas_pos_produtos_tmp,
            string? id_vendas_pos,
            string? cancelado,
            string? previsao_entrega,
            string? numero_ficha,
            string? id_vendas_pos_produtos_campos_adicionais_tmp,
            string? id_link_pagamento_linx_pay_hub,
            string? codigo_gerencial,
            string? empresa,
            string? origem,
            string? acoes_promocionais_desconto,
            string? desconto,
            string? acrescimo,
            string? frete,
            string? descontos_impostos,
            string? acrescimos_impostos,
            string? preco_unitario,
            string? quantidade,
            string? desconto_item,
            string? acrescimo_item_valor,
            string? desconto_item_valor
        )
        {
            lastupdateon = DateTime.Now;

            this.dav =
                ConvertToInt32Validation.IsValid(dav, "dav", listValidations) ?
                Convert.ToInt32(dav) :
                0;

            this.id_produtos_opticos_tipo_aro =
                ConvertToInt32Validation.IsValid(id_produtos_opticos_tipo_aro, "id_produtos_opticos_tipo_aro", listValidations) ?
                Convert.ToInt32(id_produtos_opticos_tipo_aro) :
                0;

            this.id_produtos_opticos_formato_aro =
                ConvertToInt32Validation.IsValid(id_produtos_opticos_formato_aro, "id_produtos_opticos_formato_aro", listValidations) ?
                Convert.ToInt32(id_produtos_opticos_formato_aro) :
                0;

            this.id_ordservprod =
                ConvertToInt32Validation.IsValid(id_ordservprod, "id_ordservprod", listValidations) ?
                Convert.ToInt32(id_ordservprod) :
                0;

            this.id_vendas_pos_produtos_tmp =
                ConvertToInt32Validation.IsValid(id_vendas_pos_produtos_tmp, "id_vendas_pos_produtos_tmp", listValidations) ?
                Convert.ToInt32(id_vendas_pos_produtos_tmp) :
                0;

            this.id_vendas_pos_produtos_campos_adicionais_tmp =
                ConvertToInt32Validation.IsValid(id_vendas_pos_produtos_campos_adicionais_tmp, "id_vendas_pos_produtos_campos_adicionais_tmp", listValidations) ?
                Convert.ToInt32(id_vendas_pos_produtos_campos_adicionais_tmp) :
                0;

            this.id_link_pagamento_linx_pay_hub =
                ConvertToInt32Validation.IsValid(id_link_pagamento_linx_pay_hub, "id_link_pagamento_linx_pay_hub", listValidations) ?
                Convert.ToInt32(id_link_pagamento_linx_pay_hub) :
                0;

            this.empresa =
                ConvertToInt32Validation.IsValid(empresa, "empresa", listValidations) ?
                Convert.ToInt32(empresa) :
                0;

            this.origem =
                ConvertToInt32Validation.IsValid(origem, "origem", listValidations) ?
                Convert.ToInt32(origem) :
                0;

            this.id_vendas_pos_produtos =
                ConvertToInt64Validation.IsValid(id_vendas_pos_produtos, "id_vendas_pos_produtos", listValidations) ?
                Convert.ToInt64(id_vendas_pos_produtos) :
                0;

            this.cod_produto =
                ConvertToInt64Validation.IsValid(cod_produto, "cod_produto", listValidations) ?
                Convert.ToInt64(cod_produto) :
                0;

            this.id_vendas_pos =
                ConvertToInt64Validation.IsValid(id_vendas_pos, "id_vendas_pos", listValidations) ?
                Convert.ToInt64(id_vendas_pos) :
                0;

            this.timestamp =
                ConvertToInt64Validation.IsValid(timestamp, "timestamp", listValidations) ?
                Convert.ToInt64(timestamp) :
                0;

            this.lng_esferico_od =
                ConvertToDecimalValidation.IsValid(lng_esferico_od, "lng_esferico_od", listValidations) ?
                Convert.ToDecimal(lng_esferico_od, new CultureInfo("en-US")) :
                0;

            this.lng_cilindrico_od =
                ConvertToDecimalValidation.IsValid(lng_cilindrico_od, "lng_cilindrico_od", listValidations) ?
                Convert.ToDecimal(lng_cilindrico_od, new CultureInfo("en-US")) :
                0;

            this.lng_eixo_od =
                ConvertToDecimalValidation.IsValid(lng_eixo_od, "lng_eixo_od", listValidations) ?
                Convert.ToDecimal(lng_eixo_od, new CultureInfo("en-US")) :
                0;

            this.lng_esferico_oe =
                ConvertToDecimalValidation.IsValid(lng_esferico_oe, "lng_esferico_oe", listValidations) ?
                Convert.ToDecimal(lng_esferico_oe, new CultureInfo("en-US")) :
                0;

            this.lng_cilindrico_oe =
                ConvertToDecimalValidation.IsValid(lng_cilindrico_oe, "lng_cilindrico_oe", listValidations) ?
                Convert.ToDecimal(lng_cilindrico_oe, new CultureInfo("en-US")) :
                0;

            this.lng_eixo_oe =
                ConvertToDecimalValidation.IsValid(lng_eixo_oe, "lng_eixo_oe", listValidations) ?
                Convert.ToDecimal(lng_eixo_oe, new CultureInfo("en-US")) :
                0;

            this.prt_esferico_od =
                ConvertToDecimalValidation.IsValid(prt_esferico_od, "prt_esferico_od", listValidations) ?
                Convert.ToDecimal(prt_esferico_od, new CultureInfo("en-US")) :
                0;

            this.prt_cilindrico_od =
                ConvertToDecimalValidation.IsValid(prt_cilindrico_od, "prt_cilindrico_od", listValidations) ?
                Convert.ToDecimal(prt_cilindrico_od, new CultureInfo("en-US")) :
                0;

            this.prt_eixo_od =
                ConvertToDecimalValidation.IsValid(prt_eixo_od, "prt_eixo_od", listValidations) ?
                Convert.ToDecimal(prt_eixo_od, new CultureInfo("en-US")) :
                0;

            this.prt_esferico_oe =
                ConvertToDecimalValidation.IsValid(prt_esferico_oe, "prt_esferico_oe", listValidations) ?
                Convert.ToDecimal(prt_esferico_oe, new CultureInfo("en-US")) :
                0;

            this.prt_cilindrico_oe =
                ConvertToDecimalValidation.IsValid(prt_cilindrico_oe, "prt_cilindrico_oe", listValidations) ?
                Convert.ToDecimal(prt_cilindrico_oe, new CultureInfo("en-US")) :
                0;

            this.prt_eixo_oe =
                ConvertToDecimalValidation.IsValid(prt_eixo_oe, "prt_eixo_oe", listValidations) ?
                Convert.ToDecimal(prt_eixo_oe, new CultureInfo("en-US")) :
                0;

            this.cmpl_add_od =
                ConvertToDecimalValidation.IsValid(cmpl_add_od, "cmpl_add_od", listValidations) ?
                Convert.ToDecimal(cmpl_add_od, new CultureInfo("en-US")) :
                0;

            this.base_od =
                ConvertToDecimalValidation.IsValid(base_od, "base_od", listValidations) ?
                Convert.ToDecimal(base_od, new CultureInfo("en-US")) :
                0;

            this.diametro_od =
                ConvertToDecimalValidation.IsValid(diametro_od, "diametro_od", listValidations) ?
                Convert.ToDecimal(diametro_od, new CultureInfo("en-US")) :
                0;

            this.diametro_od =
                ConvertToDecimalValidation.IsValid(diametro_od, "diametro_od", listValidations) ?
                Convert.ToDecimal(diametro_od, new CultureInfo("en-US")) :
                0;

            this.base_oe =
                ConvertToDecimalValidation.IsValid(base_oe, "base_oe", listValidations) ?
                Convert.ToDecimal(base_oe, new CultureInfo("en-US")) :
                0;

            this.base_oe =
                ConvertToDecimalValidation.IsValid(base_oe, "base_oe", listValidations) ?
                Convert.ToDecimal(base_oe, new CultureInfo("en-US")) :
                0;

            this.base_oe =
                ConvertToDecimalValidation.IsValid(base_oe, "base_oe", listValidations) ?
                Convert.ToDecimal(base_oe, new CultureInfo("en-US")) :
                0;

            this.altura =
                ConvertToDecimalValidation.IsValid(altura, "altura", listValidations) ?
                Convert.ToDecimal(altura, new CultureInfo("en-US")) :
                0;

            this.aro =
                ConvertToDecimalValidation.IsValid(aro, "aro", listValidations) ?
                Convert.ToDecimal(aro, new CultureInfo("en-US")) :
                0;

            this.diag_maior =
                ConvertToDecimalValidation.IsValid(diag_maior, "diag_maior", listValidations) ?
                Convert.ToDecimal(diag_maior, new CultureInfo("en-US")) :
                0;

            this.diag_maior =
                ConvertToDecimalValidation.IsValid(diag_maior, "diag_maior", listValidations) ?
                Convert.ToDecimal(diag_maior, new CultureInfo("en-US")) :
                0;

            this.dist_front =
                ConvertToDecimalValidation.IsValid(dist_front, "dist_front", listValidations) ?
                Convert.ToDecimal(dist_front, new CultureInfo("en-US")) :
                0;

            this.curvatura =
                ConvertToDecimalValidation.IsValid(curvatura, "curvatura", listValidations) ?
                Convert.ToDecimal(curvatura, new CultureInfo("en-US")) :
                0;

            this.lng_dpdpn_od =
                ConvertToDecimalValidation.IsValid(lng_dpdpn_od, "lng_dpdpn_od", listValidations) ?
                Convert.ToDecimal(lng_dpdpn_od, new CultureInfo("en-US")) :
                0;

            this.prt_dpdpn_od =
                ConvertToDecimalValidation.IsValid(prt_dpdpn_od, "prt_dpdpn_od", listValidations) ?
                Convert.ToDecimal(prt_dpdpn_od, new CultureInfo("en-US")) :
                0;

            this.lng_dpdpn_oe =
                ConvertToDecimalValidation.IsValid(lng_dpdpn_oe, "lng_dpdpn_oe", listValidations) ?
                Convert.ToDecimal(lng_dpdpn_oe, new CultureInfo("en-US")) :
                0;

            this.prt_dpdpn_oe =
                ConvertToDecimalValidation.IsValid(prt_dpdpn_oe, "prt_dpdpn_oe", listValidations) ?
                Convert.ToDecimal(prt_dpdpn_oe, new CultureInfo("en-US")) :
                0;

            this.lng_altura_od =
                ConvertToDecimalValidation.IsValid(lng_altura_od, "lng_altura_od", listValidations) ?
                Convert.ToDecimal(lng_altura_od, new CultureInfo("en-US")) :
                0;

            this.prt_altura_od =
                ConvertToDecimalValidation.IsValid(prt_altura_od, "prt_altura_od", listValidations) ?
                Convert.ToDecimal(prt_altura_od, new CultureInfo("en-US")) :
                0;

            this.lng_altura_oe =
                ConvertToDecimalValidation.IsValid(lng_altura_oe, "lng_altura_oe", listValidations) ?
                Convert.ToDecimal(lng_altura_oe, new CultureInfo("en-US")) :
                0;

            this.prt_altura_oe =
                ConvertToDecimalValidation.IsValid(prt_altura_oe, "prt_altura_oe", listValidations) ?
                Convert.ToDecimal(prt_altura_oe, new CultureInfo("en-US")) :
                0;

            this.calibre =
                ConvertToDecimalValidation.IsValid(calibre, "calibre", listValidations) ?
                Convert.ToDecimal(calibre, new CultureInfo("en-US")) :
                0;

            this.dp_montagem =
                ConvertToDecimalValidation.IsValid(dp_montagem, "dp_montagem", listValidations) ?
                Convert.ToDecimal(dp_montagem, new CultureInfo("en-US")) :
                0;

            this.acoes_promocionais_desconto =
                ConvertToDecimalValidation.IsValid(acoes_promocionais_desconto, "acoes_promocionais_desconto", listValidations) ?
                Convert.ToDecimal(acoes_promocionais_desconto, new CultureInfo("en-US")) :
                0;

            this.desconto =
                ConvertToDecimalValidation.IsValid(desconto, "desconto", listValidations) ?
                Convert.ToDecimal(desconto, new CultureInfo("en-US")) :

                this.acrescimo =
                ConvertToDecimalValidation.IsValid(acrescimo, "acrescimo", listValidations) ?
                Convert.ToDecimal(acrescimo, new CultureInfo("en-US")) :
                0;

            this.frete =
                ConvertToDecimalValidation.IsValid(frete, "frete", listValidations) ?
                Convert.ToDecimal(frete, new CultureInfo("en-US")) :
                0;

            this.descontos_impostos =
                ConvertToDecimalValidation.IsValid(descontos_impostos, "descontos_impostos", listValidations) ?
                Convert.ToDecimal(descontos_impostos, new CultureInfo("en-US")) :
                0;

            this.acrescimos_impostos =
                ConvertToDecimalValidation.IsValid(acrescimos_impostos, "acrescimos_impostos", listValidations) ?
                Convert.ToDecimal(acrescimos_impostos, new CultureInfo("en-US")) :
                0;

            this.preco_unitario =
                ConvertToDecimalValidation.IsValid(preco_unitario, "preco_unitario", listValidations) ?
                Convert.ToDecimal(preco_unitario, new CultureInfo("en-US")) :
                0;

            this.quantidade =
                ConvertToDecimalValidation.IsValid(quantidade, "quantidade", listValidations) ?
                Convert.ToDecimal(quantidade, new CultureInfo("en-US")) :
                0;

            this.desconto_item =
                ConvertToDecimalValidation.IsValid(desconto_item, "desconto_item", listValidations) ?
                Convert.ToDecimal(desconto_item, new CultureInfo("en-US")) :
                0;

            this.acrescimo_item_valor =
                ConvertToDecimalValidation.IsValid(acrescimo_item_valor, "acrescimo_item_valor", listValidations) ?
                Convert.ToDecimal(acrescimo_item_valor, new CultureInfo("en-US")) :
                0;

            this.desconto_item_valor =
                ConvertToDecimalValidation.IsValid(desconto_item_valor, "desconto_item_valor", listValidations) ?
                Convert.ToDecimal(desconto_item_valor, new CultureInfo("en-US")) :
                0;

            this.previsao_entrega =
                ConvertToDateTimeValidation.IsValid(previsao_entrega, "previsao_entrega", listValidations) ?
                Convert.ToDateTime(previsao_entrega) :
                new DateTime(1990, 01, 01, 00, 00, 00, new CultureInfo("en-US").Calendar);

            this.data_receita =
                ConvertToDateTimeValidation.IsValid(data_receita, "data_receita", listValidations) ?
                Convert.ToDateTime(data_receita) :
                new DateTime(1990, 01, 01, 00, 00, 00, new CultureInfo("en-US").Calendar);

            this.cancelado =
                ConvertToBooleanValidation.IsValid(cancelado, "cancelado", listValidations) ?
                Convert.ToBoolean(cancelado) :
                false;

            this.tipo_lente = tipo_lente;
            this.od_oe = od_oe;
            this.tipo_armacao = tipo_armacao;
            this.observacao = observacao;
            this.paciente = paciente;
            this.endereco_paciente = endereco_paciente;
            this.medico_especialista = medico_especialista;
            this.endereco_medico_especialista = endereco_medico_especialista;
            this.refracionista_optico = refracionista_optico;
            this.codigo_gerencial = codigo_gerencial;
        }
    }
}
