
using Domain.Core.Extensions;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Globalization;

namespace Domain.LinxMicrovix.Outbound.WebService.Models.LinxMicrovix
{
    public class LinxOticoReceitas
    {
        public DateTime? lastupdateon { get; private set; }
        public Int32? id_otico_receitas { get; private set; }
        public Int32? cod_cliente { get; private set; }
        public Int64? codigoproduto { get; private set; }
        public decimal? lng_esferico_od { get; private set; }
        public decimal? lng_cilindrico_od { get; private set; }
        public decimal? lng_eixo_od { get; private set; }
        public decimal? lng_dpdpn_od { get; private set; }
        public decimal? lng_altura_od { get; private set; }
        public decimal? prt_esferico_od { get; private set; }
        public decimal? prt_cilindrico_od { get; private set; }
        public decimal? prt_eixo_od { get; private set; }
        public decimal? prt_dpdpn_od { get; private set; }
        public decimal? lng_esferico_oe { get; private set; }
        public decimal? lng_cilindrico_oe { get; private set; }
        public decimal? lng_eixo_oe { get; private set; }
        public decimal? lng_dpdpn_oe { get; private set; }
        public decimal? lng_altura_oe { get; private set; }
        public decimal? prt_esferico_oe { get; private set; }
        public decimal? prt_cilindrico_oe { get; private set; }
        public decimal? prt_eixo_oe { get; private set; }
        public decimal? prt_dpdpn_oe { get; private set; }
        public decimal? lng_adicao_od { get; private set; }
        public decimal? lng_adicao_oe { get; private set; }
        public string? otico_lado_lente { get; private set; }
        public decimal? diametro_od { get; private set; }
        public decimal? diametro_oe { get; private set; }
        public decimal? ponte { get; private set; }
        public decimal? altura { get; private set; }
        public decimal? aro { get; private set; }
        public decimal? diag_maior { get; private set; }
        public string? tipo_armacao { get; private set; }
        public string? observacao { get; private set; }
        public string? paciente { get; private set; }
        public decimal? cmpl_add_od { get; private set; }
        public decimal? cmpl_add_oe { get; private set; }
        public decimal? base_od { get; private set; }
        public decimal? base_oe { get; private set; }
        public decimal? dist_haste { get; private set; }
        public decimal? dist_front { get; private set; }
        public decimal? curvatura { get; private set; }
        public decimal? lng_pris1_od { get; private set; }
        public Int32? id_lng_pris1_od_desc { get; private set; }
        public decimal? lng_pris1_oe { get; private set; }
        public Int32? id_lng_pris1_oe_desc { get; private set; }
        public decimal? prt_pris1_od { get; private set; }
        public Int32? id_prt_pris1_od_desc { get; private set; }
        public decimal? prt_pris1_oe { get; private set; }
        public Int32? id_prt_pris1_oe_desc { get; private set; }
        public decimal? lng_pris2_od { get; private set; }
        public Int32? id_lng_pris2_od_desc { get; private set; }
        public decimal? lng_pris2_oe { get; private set; }
        public Int32? id_lng_pris2_oe_desc { get; private set; }
        public decimal? prt_pris2_od { get; private set; }
        public Int32? id_prt_pris2_od_desc { get; private set; }
        public decimal? prt_pris2_oe { get; private set; }
        public Int32? id_prt_pris2_oe_desc { get; private set; }
        public decimal? dist_vertice { get; private set; }
        public decimal? inc_planto { get; private set; }
        public string? ativ_princ { get; private set; }
        public string? otico_area_privilegiada { get; private set; }
        public decimal? dist_visao { get; private set; }
        public string? personalizada { get; private set; }
        public decimal? pris_od { get; private set; }
        public decimal? pris_oe { get; private set; }
        public decimal? eixo_od { get; private set; }
        public decimal? eixo_oe { get; private set; }
        public decimal? borda_od { get; private set; }
        public decimal? borda_oe { get; private set; }
        public decimal? centro_od { get; private set; }
        public decimal? centro_oe { get; private set; }
        public decimal? furo_od { get; private set; }
        public decimal? furo_oe { get; private set; }
        public string? format_corte { get; private set; }
        public string? dist_leitura { get; private set; }
        public string? tipo_lente { get; private set; }
        public string? endereco_paciente { get; private set; }
        public string? medico_especialista { get; private set; }
        public string? endereco_medico_especialista { get; private set; }
        public string? refracionista_optico { get; private set; }
        public DateTime? data_receita { get; private set; }
        public Int32? id_produtos_opticos_tipo_aro { get; private set; }
        public decimal? dp_montagem { get; private set; }
        public Int32? id_produtos_opticos_formato_aro { get; private set; }
        public string? codigo_gerencial { get; private set; }
        public bool? migracao_dados { get; private set; }
        public string? migracao_observacao { get; private set; }
        public Int32? portal { get; private set; }
        public Int64? timestamp { get; private set; }

        [NotMapped]
        [SkipProperty]
        public string? recordKey { get; private set; }

        [NotMapped]
        [SkipProperty]
        public string? recordXml { get; private set; }

        public LinxOticoReceitas() { }

        public LinxOticoReceitas(Domain.LinxMicrovix.Outbound.WebService.Dtos.LinxMicrovix.LinxOticoReceitas record, string recordXml) {
            lastupdateon = CustomConvertersExtensions.ConvertToDateTimeValidation<DateTime>(DateTime.Now);
            this.migracao_dados = CustomConvertersExtensions.ConvertToBooleanValidation(record.migracao_dados);
            this.data_receita =  CustomConvertersExtensions.ConvertToDateTimeValidation<string>(record.data_receita);
            this.id_otico_receitas = CustomConvertersExtensions.ConvertToInt32Validation(record.id_otico_receitas);
            this.cod_cliente = CustomConvertersExtensions.ConvertToInt32Validation(record.cod_cliente);
            this.id_produtos_opticos_formato_aro = CustomConvertersExtensions.ConvertToInt32Validation(record.id_produtos_opticos_formato_aro);
            this.id_produtos_opticos_tipo_aro = CustomConvertersExtensions.ConvertToInt32Validation(record.id_produtos_opticos_tipo_aro);
            this.id_prt_pris2_oe_desc = CustomConvertersExtensions.ConvertToInt32Validation(record.id_prt_pris2_oe_desc);
            this.id_prt_pris2_od_desc = CustomConvertersExtensions.ConvertToInt32Validation(record.id_prt_pris2_od_desc);
            this.id_lng_pris2_oe_desc = CustomConvertersExtensions.ConvertToInt32Validation(record.id_lng_pris2_oe_desc);
            this.id_prt_pris2_od_desc = CustomConvertersExtensions.ConvertToInt32Validation(record.id_prt_pris2_od_desc);
            this.id_prt_pris2_oe_desc = CustomConvertersExtensions.ConvertToInt32Validation(record.id_prt_pris2_oe_desc);
            this.id_produtos_opticos_tipo_aro = CustomConvertersExtensions.ConvertToInt32Validation(record.id_produtos_opticos_tipo_aro);
            this.id_produtos_opticos_formato_aro = CustomConvertersExtensions.ConvertToInt32Validation(record.id_produtos_opticos_formato_aro);
            this.portal = CustomConvertersExtensions.ConvertToInt32Validation(record.portal);
            this.codigoproduto = CustomConvertersExtensions.ConvertToInt64Validation(record.codigoproduto);
            this.timestamp = CustomConvertersExtensions.ConvertToInt64Validation(record.timestamp);
            this.lng_esferico_od = CustomConvertersExtensions.ConvertToDecimalValidation(record.lng_esferico_od);
            this.lng_cilindrico_od = CustomConvertersExtensions.ConvertToDecimalValidation(record.lng_cilindrico_od);
            this.lng_eixo_od = CustomConvertersExtensions.ConvertToDecimalValidation(record.lng_eixo_od);
            this.lng_dpdpn_od = CustomConvertersExtensions.ConvertToDecimalValidation(record.lng_dpdpn_od);
            this.lng_altura_od = CustomConvertersExtensions.ConvertToDecimalValidation(record.lng_altura_od);
            this.prt_esferico_od = CustomConvertersExtensions.ConvertToDecimalValidation(record.prt_esferico_od);
            this.prt_cilindrico_od = CustomConvertersExtensions.ConvertToDecimalValidation(record.prt_cilindrico_od);
            this.prt_eixo_od = CustomConvertersExtensions.ConvertToDecimalValidation(record.prt_eixo_od);
            this.prt_dpdpn_od = CustomConvertersExtensions.ConvertToDecimalValidation(record.prt_dpdpn_od);
            this.lng_esferico_oe = CustomConvertersExtensions.ConvertToDecimalValidation(record.lng_esferico_oe);
            this.lng_cilindrico_oe = CustomConvertersExtensions.ConvertToDecimalValidation(record.lng_cilindrico_oe);
            this.lng_eixo_oe = CustomConvertersExtensions.ConvertToDecimalValidation(record.lng_eixo_oe);
            this.lng_dpdpn_oe = CustomConvertersExtensions.ConvertToDecimalValidation(record.lng_dpdpn_oe);
            this.lng_altura_oe = CustomConvertersExtensions.ConvertToDecimalValidation(record.lng_altura_oe);
            this.prt_esferico_oe = CustomConvertersExtensions.ConvertToDecimalValidation(record.prt_esferico_oe);
            this.prt_cilindrico_oe = CustomConvertersExtensions.ConvertToDecimalValidation(record.prt_cilindrico_oe);
            this.prt_eixo_oe = CustomConvertersExtensions.ConvertToDecimalValidation(record.prt_eixo_oe);
            this.prt_dpdpn_oe = CustomConvertersExtensions.ConvertToDecimalValidation(record.prt_dpdpn_oe);
            this.lng_adicao_od = CustomConvertersExtensions.ConvertToDecimalValidation(record.lng_adicao_od);
            this.lng_adicao_oe = CustomConvertersExtensions.ConvertToDecimalValidation(record.lng_adicao_oe);
            this.diametro_od = CustomConvertersExtensions.ConvertToDecimalValidation(record.diametro_od);
            this.diametro_oe = CustomConvertersExtensions.ConvertToDecimalValidation(record.diametro_oe);
            this.ponte = CustomConvertersExtensions.ConvertToDecimalValidation(record.ponte);
            this.aro = CustomConvertersExtensions.ConvertToDecimalValidation(record.aro);
            this.diag_maior = CustomConvertersExtensions.ConvertToDecimalValidation(record.diag_maior);
            this.cmpl_add_od = CustomConvertersExtensions.ConvertToDecimalValidation(record.cmpl_add_od);
            this.cmpl_add_oe = CustomConvertersExtensions.ConvertToDecimalValidation(record.cmpl_add_oe);
            this.base_od = CustomConvertersExtensions.ConvertToDecimalValidation(record.base_od);
            this.base_oe = CustomConvertersExtensions.ConvertToDecimalValidation(record.base_oe);
            this.dist_haste = CustomConvertersExtensions.ConvertToDecimalValidation(record.dist_haste);
            this.dist_front = CustomConvertersExtensions.ConvertToDecimalValidation(record.dist_front);
            this.curvatura = CustomConvertersExtensions.ConvertToDecimalValidation(record.curvatura);
            this.lng_pris1_od = CustomConvertersExtensions.ConvertToDecimalValidation(record.lng_pris1_od);
            this.lng_pris1_oe = CustomConvertersExtensions.ConvertToDecimalValidation(record.lng_pris1_oe);
            this.prt_pris1_od = CustomConvertersExtensions.ConvertToDecimalValidation(record.prt_pris1_od);
            this.prt_pris1_oe = CustomConvertersExtensions.ConvertToDecimalValidation(record.prt_pris1_oe);
            this.lng_pris2_od = CustomConvertersExtensions.ConvertToDecimalValidation(record.lng_pris2_od);
            this.lng_pris2_oe = CustomConvertersExtensions.ConvertToDecimalValidation(record.lng_pris2_oe);
            this.prt_pris2_od = CustomConvertersExtensions.ConvertToDecimalValidation(record.prt_pris2_od);
            this.prt_pris2_oe = CustomConvertersExtensions.ConvertToDecimalValidation(record.prt_pris2_oe);
            this.dist_vertice = CustomConvertersExtensions.ConvertToDecimalValidation(record.dist_vertice);
            this.inc_planto = CustomConvertersExtensions.ConvertToDecimalValidation(record.inc_planto);
            this.dist_visao = CustomConvertersExtensions.ConvertToDecimalValidation(record.dist_visao);
            this.pris_od = CustomConvertersExtensions.ConvertToDecimalValidation(record.pris_od);
            this.pris_oe = CustomConvertersExtensions.ConvertToDecimalValidation(record.pris_oe);
            this.eixo_od = CustomConvertersExtensions.ConvertToDecimalValidation(record.eixo_od);
            this.eixo_oe = CustomConvertersExtensions.ConvertToDecimalValidation(record.eixo_oe);
            this.borda_od = CustomConvertersExtensions.ConvertToDecimalValidation(record.borda_od);
            this.borda_oe = CustomConvertersExtensions.ConvertToDecimalValidation(record.borda_oe);
            this.centro_od = CustomConvertersExtensions.ConvertToDecimalValidation(record.centro_od);
            this.centro_oe = CustomConvertersExtensions.ConvertToDecimalValidation(record.centro_oe);
            this.furo_od = CustomConvertersExtensions.ConvertToDecimalValidation(record.furo_od);
            this.furo_oe = CustomConvertersExtensions.ConvertToDecimalValidation(record.furo_oe);
            this.dp_montagem = CustomConvertersExtensions.ConvertToDecimalValidation(record.dp_montagem);
            this.altura = CustomConvertersExtensions.ConvertToDecimalValidation(record.altura);
            this.otico_lado_lente = record.otico_lado_lente;
            this.tipo_armacao = record.tipo_armacao;
            this.observacao = record.observacao;
            this.paciente = record.paciente;
            this.ativ_princ = record.ativ_princ;
            this.otico_area_privilegiada = record.otico_area_privilegiada;
            this.personalizada = record.personalizada;
            this.format_corte = record.format_corte;
            this.dist_leitura = record.dist_leitura;
            this.tipo_lente = record.tipo_lente;
            this.endereco_paciente = record.endereco_paciente;
            this.endereco_medico_especialista = record.endereco_medico_especialista;
            this.refracionista_optico = record.refracionista_optico;
            this.codigo_gerencial = record.codigo_gerencial;
            this.migracao_observacao = record.migracao_observacao;
        }
    }
}
