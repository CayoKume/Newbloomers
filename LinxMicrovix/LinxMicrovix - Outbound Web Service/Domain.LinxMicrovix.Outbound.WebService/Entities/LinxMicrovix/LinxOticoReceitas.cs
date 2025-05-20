using Domain.LinxMicrovix.Outbound.WebService.CustomValidations;
using Domain.IntegrationsCore.Extensions;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Globalization;

namespace Domain.LinxMicrovix.Outbound.WebService.Entites.LinxMicrovix
{
    public class LinxOticoReceitas
    {
        [SkipProperty]
        public Int32 id { get; set; }

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

        [LengthValidation(length: 15, propertyName: "otico_lado_lente")]
        public string? otico_lado_lente { get; private set; }

        public decimal? diametro_od { get; private set; }

        public decimal? diametro_oe { get; private set; }

        public decimal? ponte { get; private set; }

        public decimal? altura { get; private set; }

        public decimal? aro { get; private set; }

        public decimal? diag_maior { get; private set; }

        [LengthValidation(length: 100, propertyName: "tipo_armacao")]
        public string? tipo_armacao { get; private set; }

        [LengthValidation(length: 100, propertyName: "observacao")]
        public string? observacao { get; private set; }

        [LengthValidation(length: 100, propertyName: "paciente")]
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

        [LengthValidation(length: 40, propertyName: "ativ_princ")]
        public string? ativ_princ { get; private set; }

        [LengthValidation(length: 15, propertyName: "otico_area_privilegiada")]
        public string? otico_area_privilegiada { get; private set; }

        public decimal? dist_visao { get; private set; }

        [LengthValidation(length: 100, propertyName: "personalizada")]
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

        [LengthValidation(length: 40, propertyName: "format_corte")]
        public string? format_corte { get; private set; }

        [LengthValidation(length: 40, propertyName: "dist_leitura")]
        public string? dist_leitura { get; private set; }

        [LengthValidation(length: 100, propertyName: "tipo_lente")]
        public string? tipo_lente { get; private set; }

        [LengthValidation(length: 100, propertyName: "endereco_paciente")]
        public string? endereco_paciente { get; private set; }

        [LengthValidation(length: 10, propertyName: "medico_especialista")]
        public string? medico_especialista { get; private set; }

        [LengthValidation(length: 100, propertyName: "endereco_medico_especialista")]
        public string? endereco_medico_especialista { get; private set; }

        [LengthValidation(length: 100, propertyName: "refracionista_optico")]
        public string? refracionista_optico { get; private set; }

        public DateTime? data_receita { get; private set; }

        public Int32? id_produtos_opticos_tipo_aro { get; private set; }

        public decimal? dp_montagem { get; private set; }

        public Int32? id_produtos_opticos_formato_aro { get; private set; }

        [LengthValidation(length: 40, propertyName: "codigo_gerencial")]
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

        public LinxOticoReceitas(
            List<ValidationResult> listValidations,
            string? id_otico_receitas,
            string? cod_cliente,
            string? codigoproduto,
            string? lng_esferico_od,
            string? lng_cilindrico_od,
            string? lng_eixo_od,
            string? lng_dpdpn_od,
            string? lng_altura_od,
            string? prt_esferico_od,
            string? prt_cilindrico_od,
            string? prt_eixo_od,
            string? prt_dpdpn_od,
            string? lng_esferico_oe,
            string? lng_cilindrico_oe,
            string? lng_eixo_oe,
            string? lng_dpdpn_oe,
            string? lng_altura_oe,
            string? prt_esferico_oe,
            string? prt_cilindrico_oe,
            string? prt_eixo_oe,
            string? prt_dpdpn_oe,
            string? lng_adicao_od,
            string? lng_adicao_oe,
            string? otico_lado_lente,
            string? diametro_od,
            string? diametro_oe,
            string? ponte,
            string? altura,
            string? aro,
            string? diag_maior,
            string? tipo_armacao,
            string? observacao,
            string? paciente,
            string? cmpl_add_od,
            string? cmpl_add_oe,
            string? base_od,
            string? base_oe,
            string? dist_haste,
            string? dist_front,
            string? curvatura,
            string? lng_pris1_od,
            string? id_lng_pris1_od_desc,
            string? lng_pris1_oe,
            string? id_lng_pris1_oe_desc,
            string? prt_pris1_od,
            string? id_prt_pris1_od_desc,
            string? prt_pris1_oe,
            string? id_prt_pris1_oe_desc,
            string? lng_pris2_od,
            string? id_lng_pris2_od_desc,
            string? lng_pris2_oe,
            string? id_lng_pris2_oe_desc,
            string? prt_pris2_od,
            string? id_prt_pris2_od_desc,
            string? prt_pris2_oe,
            string? id_prt_pris2_oe_desc,
            string? dist_vertice,
            string? inc_planto,
            string? ativ_princ,
            string? otico_area_privilegiada,
            string? dist_visao,
            string? personalizada,
            string? pris_od,
            string? pris_oe,
            string? eixo_od,
            string? eixo_oe,
            string? borda_od,
            string? borda_oe,
            string? centro_od,
            string? centro_oe,
            string? furo_od,
            string? furo_oe,
            string? format_corte,
            string? dist_leitura,
            string? tipo_lente,
            string? endereco_paciente,
            string? medico_especialista,
            string? endereco_medico_especialista,
            string? refracionista_optico,
            string? data_receita,
            string? id_produtos_opticos_tipo_aro,
            string? dp_montagem,
            string? id_produtos_opticos_formato_aro,
            string? codigo_gerencial,
            string? migracao_dados,
            string? migracao_observacao,
            string? portal,
            string? timestamp
        )
        {
            lastupdateon = DateTime.Now;

            this.migracao_dados =
                ConvertToBooleanValidation.IsValid(migracao_dados, "migracao_dados", listValidations) ?
                Convert.ToBoolean(migracao_dados) :
                false;

            this.data_receita =
                ConvertToDateTimeValidation.IsValid(data_receita, "data_receita", listValidations) ?
                Convert.ToDateTime(data_receita) :
                new DateTime(1990, 01, 01, 00, 00, 00, new CultureInfo("en-US").Calendar);

            this.id_otico_receitas =
                ConvertToInt32Validation.IsValid(id_otico_receitas, "id_otico_receitas", listValidations) ?
                Convert.ToInt32(id_otico_receitas) :
                0;

            this.cod_cliente =
                ConvertToInt32Validation.IsValid(cod_cliente, "cod_cliente", listValidations) ?
                Convert.ToInt32(cod_cliente) :
                0;

            this.id_produtos_opticos_formato_aro =
                ConvertToInt32Validation.IsValid(id_produtos_opticos_formato_aro, "id_produtos_opticos_formato_aro", listValidations) ?
                Convert.ToInt32(id_produtos_opticos_formato_aro) :
                0;

            this.id_produtos_opticos_tipo_aro =
                ConvertToInt32Validation.IsValid(id_produtos_opticos_tipo_aro, "id_produtos_opticos_tipo_aro", listValidations) ?
                Convert.ToInt32(id_produtos_opticos_tipo_aro) :
                0;

            this.id_prt_pris2_oe_desc =
                ConvertToInt32Validation.IsValid(id_prt_pris2_oe_desc, "id_prt_pris2_oe_desc", listValidations) ?
                Convert.ToInt32(id_prt_pris2_oe_desc) :
                0;

            this.id_prt_pris2_od_desc =
                ConvertToInt32Validation.IsValid(id_prt_pris2_od_desc, "id_prt_pris2_od_desc", listValidations) ?
                Convert.ToInt32(id_prt_pris2_od_desc) :
                0;

            this.id_lng_pris2_oe_desc =
                ConvertToInt32Validation.IsValid(id_lng_pris2_oe_desc, "id_lng_pris2_oe_desc", listValidations) ?
                Convert.ToInt32(id_lng_pris2_oe_desc) :
                0;

            this.id_prt_pris2_od_desc =
                ConvertToInt32Validation.IsValid(id_prt_pris2_od_desc, "id_prt_pris2_od_desc", listValidations) ?
                Convert.ToInt32(id_prt_pris2_od_desc) :
                0;

            this.id_prt_pris2_oe_desc =
                ConvertToInt32Validation.IsValid(id_prt_pris2_oe_desc, "id_prt_pris2_oe_desc", listValidations) ?
                Convert.ToInt32(id_prt_pris2_oe_desc) :
                0;

            this.id_produtos_opticos_tipo_aro =
                ConvertToInt32Validation.IsValid(id_produtos_opticos_tipo_aro, "id_produtos_opticos_tipo_aro", listValidations) ?
                Convert.ToInt32(id_produtos_opticos_tipo_aro) :
                0;

            this.id_produtos_opticos_formato_aro =
                ConvertToInt32Validation.IsValid(id_produtos_opticos_formato_aro, "id_produtos_opticos_formato_aro", listValidations) ?
                Convert.ToInt32(id_produtos_opticos_formato_aro) :
                0;

            this.portal =
                ConvertToInt32Validation.IsValid(portal, "portal", listValidations) ?
                Convert.ToInt32(portal) :
                0;

            this.codigoproduto =
                ConvertToInt64Validation.IsValid(codigoproduto, "codigoproduto", listValidations) ?
                Convert.ToInt64(codigoproduto) :
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

            this.lng_dpdpn_od =
                ConvertToDecimalValidation.IsValid(lng_dpdpn_od, "lng_dpdpn_od", listValidations) ?
                Convert.ToDecimal(lng_dpdpn_od, new CultureInfo("en-US")) :
                0;

            this.lng_altura_od =
                ConvertToDecimalValidation.IsValid(lng_altura_od, "lng_altura_od", listValidations) ?
                Convert.ToDecimal(lng_altura_od, new CultureInfo("en-US")) :
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

            this.prt_dpdpn_od =
                ConvertToDecimalValidation.IsValid(prt_dpdpn_od, "prt_dpdpn_od", listValidations) ?
                Convert.ToDecimal(prt_dpdpn_od, new CultureInfo("en-US")) :
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

            this.lng_dpdpn_oe =
                ConvertToDecimalValidation.IsValid(lng_dpdpn_oe, "lng_dpdpn_oe", listValidations) ?
                Convert.ToDecimal(lng_dpdpn_oe, new CultureInfo("en-US")) :
                0;

            this.lng_altura_oe =
                ConvertToDecimalValidation.IsValid(lng_altura_oe, "lng_altura_oe", listValidations) ?
                Convert.ToDecimal(lng_altura_oe, new CultureInfo("en-US")) :
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

            this.prt_dpdpn_oe =
                ConvertToDecimalValidation.IsValid(prt_dpdpn_oe, "prt_dpdpn_oe", listValidations) ?
                Convert.ToDecimal(prt_dpdpn_oe, new CultureInfo("en-US")) :
                0;

            this.lng_adicao_od =
                ConvertToDecimalValidation.IsValid(lng_adicao_od, "lng_adicao_od", listValidations) ?
                Convert.ToDecimal(lng_adicao_od, new CultureInfo("en-US")) :
                0;

            this.lng_adicao_oe =
                ConvertToDecimalValidation.IsValid(lng_adicao_oe, "lng_adicao_oe", listValidations) ?
                Convert.ToDecimal(lng_adicao_oe, new CultureInfo("en-US")) :
                0;

            this.diametro_od =
                ConvertToDecimalValidation.IsValid(diametro_od, "diametro_od", listValidations) ?
                Convert.ToDecimal(diametro_od, new CultureInfo("en-US")) :
                0;

            this.diametro_oe =
                ConvertToDecimalValidation.IsValid(diametro_oe, "diametro_oe", listValidations) ?
                Convert.ToDecimal(diametro_oe, new CultureInfo("en-US")) :
                0;

            this.ponte =
                ConvertToDecimalValidation.IsValid(ponte, "ponte", listValidations) ?
                Convert.ToDecimal(ponte, new CultureInfo("en-US")) :
                0;

            this.aro =
                ConvertToDecimalValidation.IsValid(aro, "aro", listValidations) ?
                Convert.ToDecimal(aro, new CultureInfo("en-US")) :
                0;

            this.diag_maior =
                ConvertToDecimalValidation.IsValid(diag_maior, "diag_maior", listValidations) ?
                Convert.ToDecimal(diag_maior, new CultureInfo("en-US")) :
                0;

            this.cmpl_add_od =
                ConvertToDecimalValidation.IsValid(cmpl_add_od, "cmpl_add_od", listValidations) ?
                Convert.ToDecimal(cmpl_add_od, new CultureInfo("en-US")) :
                0;

            this.cmpl_add_oe =
                ConvertToDecimalValidation.IsValid(cmpl_add_oe, "cmpl_add_oe", listValidations) ?
                Convert.ToDecimal(cmpl_add_oe, new CultureInfo("en-US")) :
                0;

            this.base_od =
                ConvertToDecimalValidation.IsValid(base_od, "base_od", listValidations) ?
                Convert.ToDecimal(base_od, new CultureInfo("en-US")) :
                0;

            this.base_oe =
                ConvertToDecimalValidation.IsValid(base_oe, "base_oe", listValidations) ?
                Convert.ToDecimal(base_oe, new CultureInfo("en-US")) :
                0;

            this.dist_haste =
                ConvertToDecimalValidation.IsValid(dist_haste, "dist_haste", listValidations) ?
                Convert.ToDecimal(dist_haste, new CultureInfo("en-US")) :
                0;

            this.dist_front =
                ConvertToDecimalValidation.IsValid(dist_front, "dist_front", listValidations) ?
                Convert.ToDecimal(dist_front, new CultureInfo("en-US")) :
                0;

            this.curvatura =
                ConvertToDecimalValidation.IsValid(curvatura, "curvatura", listValidations) ?
                Convert.ToDecimal(curvatura, new CultureInfo("en-US")) :
                0;

            this.lng_pris1_od =
                ConvertToDecimalValidation.IsValid(lng_pris1_od, "lng_pris1_od", listValidations) ?
                Convert.ToDecimal(lng_pris1_od, new CultureInfo("en-US")) :
                0;

            this.lng_pris1_oe =
                ConvertToDecimalValidation.IsValid(lng_pris1_oe, "lng_pris1_oe", listValidations) ?
                Convert.ToDecimal(lng_pris1_oe, new CultureInfo("en-US")) :
                0;

            this.prt_pris1_od =
                ConvertToDecimalValidation.IsValid(prt_pris1_od, "prt_pris1_od", listValidations) ?
                Convert.ToDecimal(prt_pris1_od, new CultureInfo("en-US")) :
                0;

            this.prt_pris1_oe =
                ConvertToDecimalValidation.IsValid(prt_pris1_oe, "prt_pris1_oe", listValidations) ?
                Convert.ToDecimal(prt_pris1_oe, new CultureInfo("en-US")) :
                0;

            this.lng_pris2_od =
                ConvertToDecimalValidation.IsValid(lng_pris2_od, "lng_pris2_od", listValidations) ?
                Convert.ToDecimal(lng_pris2_od, new CultureInfo("en-US")) :
                0;

            this.lng_pris2_oe =
                ConvertToDecimalValidation.IsValid(lng_pris2_oe, "lng_pris2_oe", listValidations) ?
                Convert.ToDecimal(lng_pris2_oe, new CultureInfo("en-US")) :
                0;

            this.prt_pris2_od =
                ConvertToDecimalValidation.IsValid(prt_pris2_od, "prt_pris2_od", listValidations) ?
                Convert.ToDecimal(prt_pris2_od, new CultureInfo("en-US")) :
                0;

            this.prt_pris2_oe =
                ConvertToDecimalValidation.IsValid(prt_pris2_oe, "prt_pris2_oe", listValidations) ?
                Convert.ToDecimal(prt_pris2_oe, new CultureInfo("en-US")) :
                0;

            this.dist_vertice =
                ConvertToDecimalValidation.IsValid(dist_vertice, "dist_vertice", listValidations) ?
                Convert.ToDecimal(dist_vertice, new CultureInfo("en-US")) :
                0;

            this.inc_planto =
                ConvertToDecimalValidation.IsValid(inc_planto, "inc_planto", listValidations) ?
                Convert.ToDecimal(inc_planto, new CultureInfo("en-US")) :
                0;

            this.dist_visao =
                ConvertToDecimalValidation.IsValid(dist_visao, "dist_visao", listValidations) ?
                Convert.ToDecimal(dist_visao, new CultureInfo("en-US")) :
                0;

            this.pris_od =
                ConvertToDecimalValidation.IsValid(pris_od, "pris_od", listValidations) ?
                Convert.ToDecimal(pris_od, new CultureInfo("en-US")) :
                0;

            this.pris_oe =
                ConvertToDecimalValidation.IsValid(pris_oe, "pris_oe", listValidations) ?
                Convert.ToDecimal(pris_oe, new CultureInfo("en-US")) :
                0;

            this.eixo_od =
                ConvertToDecimalValidation.IsValid(eixo_od, "eixo_od", listValidations) ?
                Convert.ToDecimal(eixo_od, new CultureInfo("en-US")) :
                0;

            this.eixo_oe =
                ConvertToDecimalValidation.IsValid(eixo_oe, "eixo_oe", listValidations) ?
                Convert.ToDecimal(eixo_oe, new CultureInfo("en-US")) :
                0;

            this.borda_od =
                ConvertToDecimalValidation.IsValid(borda_od, "borda_od", listValidations) ?
                Convert.ToDecimal(borda_od, new CultureInfo("en-US")) :
                0;

            this.borda_oe =
                ConvertToDecimalValidation.IsValid(borda_oe, "borda_oe", listValidations) ?
                Convert.ToDecimal(borda_oe, new CultureInfo("en-US")) :
                0;

            this.centro_od =
                ConvertToDecimalValidation.IsValid(centro_od, "centro_od", listValidations) ?
                Convert.ToDecimal(centro_od, new CultureInfo("en-US")) :
                0;

            this.centro_oe =
                ConvertToDecimalValidation.IsValid(centro_oe, "centro_oe", listValidations) ?
                Convert.ToDecimal(centro_oe, new CultureInfo("en-US")) :
                0;

            this.furo_od =
                ConvertToDecimalValidation.IsValid(furo_od, "furo_od", listValidations) ?
                Convert.ToDecimal(furo_od, new CultureInfo("en-US")) :
                0;

            this.furo_oe =
                ConvertToDecimalValidation.IsValid(furo_oe, "furo_oe", listValidations) ?
                Convert.ToDecimal(furo_oe, new CultureInfo("en-US")) :
                0;

            this.dp_montagem =
                ConvertToDecimalValidation.IsValid(dp_montagem, "dp_montagem", listValidations) ?
                Convert.ToDecimal(dp_montagem, new CultureInfo("en-US")) :
                0;

            this.altura =
                ConvertToDecimalValidation.IsValid(altura, "altura", listValidations) ?
                Convert.ToDecimal(altura, new CultureInfo("en-US")) :
                0;

            this.otico_lado_lente = otico_lado_lente;
            this.tipo_armacao = tipo_armacao;
            this.observacao = observacao;
            this.paciente = paciente;
            this.ativ_princ = ativ_princ;
            this.otico_area_privilegiada = otico_area_privilegiada;
            this.personalizada = personalizada;
            this.format_corte = format_corte;
            this.dist_leitura = dist_leitura;
            this.tipo_lente = tipo_lente;
            this.endereco_paciente = endereco_paciente;
            this.endereco_medico_especialista = endereco_medico_especialista;
            this.refracionista_optico = refracionista_optico;
            this.codigo_gerencial = codigo_gerencial;
            this.migracao_observacao = migracao_observacao;
        }
    }
}
