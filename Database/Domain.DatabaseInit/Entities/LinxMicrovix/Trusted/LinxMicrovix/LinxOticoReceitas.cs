using Domain.LinxMicrovix.Outbound.WebService.CustomValidations;
using Domain.IntegrationsCore.Extensions;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Globalization;

namespace Domain.DatabaseInit.Entities.LinxMicrovix.Trusted.LinxMicrovix
{
    [Table("LinxOticoReceitas", Schema = "linx_microvix_erp")]
    public class LinxOticoReceitas
    {
        [Column(TypeName = "datetime")]
        public string? lastupdateon { get; private set; }

        [Key]
        [Column(TypeName = "int")]
        public string? id_otico_receitas { get; private set; }

        [Column(TypeName = "int")]
        public string? cod_cliente { get; private set; }

        [Column(TypeName = "bigint")]
        public string? codigoproduto { get; private set; }

        [Column(TypeName = "decimal(10,2)")]
        public string? lng_esferico_od { get; private set; }

        [Column(TypeName = "decimal(10,2)")]
        public string? lng_cilindrico_od { get; private set; }

        [Column(TypeName = "decimal(10,2)")]
        public string? lng_eixo_od { get; private set; }

        [Column(TypeName = "decimal(10,2)")]
        public string? lng_dpdpn_od { get; private set; }

        [Column(TypeName = "decimal(10,2)")]
        public string? lng_altura_od { get; private set; }

        [Column(TypeName = "decimal(10,2)")]
        public string? prt_esferico_od { get; private set; }

        [Column(TypeName = "decimal(10,2)")]
        public string? prt_cilindrico_od { get; private set; }

        [Column(TypeName = "decimal(10,2)")]
        public string? prt_eixo_od { get; private set; }

        [Column(TypeName = "decimal(10,2)")]
        public string? prt_dpdpn_od { get; private set; }

        [Column(TypeName = "decimal(10,2)")]
        public string? lng_esferico_oe { get; private set; }

        [Column(TypeName = "decimal(10,2)")]
        public string? lng_cilindrico_oe { get; private set; }

        [Column(TypeName = "decimal(10,2)")]
        public string? lng_eixo_oe { get; private set; }

        [Column(TypeName = "decimal(10,2)")]
        public string? lng_dpdpn_oe { get; private set; }

        [Column(TypeName = "decimal(10,2)")]
        public string? lng_altura_oe { get; private set; }

        [Column(TypeName = "decimal(10,2)")]
        public string? prt_esferico_oe { get; private set; }

        [Column(TypeName = "decimal(10,2)")]
        public string? prt_cilindrico_oe { get; private set; }

        [Column(TypeName = "decimal(10,2)")]
        public string? prt_eixo_oe { get; private set; }

        [Column(TypeName = "decimal(10,2)")]
        public string? prt_dpdpn_oe { get; private set; }

        [Column(TypeName = "decimal(10,2)")]
        public string? lng_adicao_od { get; private set; }

        [Column(TypeName = "decimal(10,2)")]
        public string? lng_adicao_oe { get; private set; }

        [Column(TypeName = "varchar(15)")]
        public string? otico_lado_lente { get; private set; }

        [Column(TypeName = "decimal(10,2)")]
        public string? diametro_od { get; private set; }

        [Column(TypeName = "decimal(10,2)")]
        public string? diametro_oe { get; private set; }

        [Column(TypeName = "decimal(10,2)")]
        public string? ponte { get; private set; }

        [Column(TypeName = "decimal(10,2)")]
        public string? altura { get; private set; }

        [Column(TypeName = "decimal(10,2)")]
        public string? aro { get; private set; }

        [Column(TypeName = "decimal(10,2)")]
        public string? diag_maior { get; private set; }

        [Column(TypeName = "varchar(100)")]
        public string? tipo_armacao { get; private set; }

        [Column(TypeName = "varchar(100)")]
        public string? observacao { get; private set; }

        [Column(TypeName = "varchar(100)")]
        public string? paciente { get; private set; }

        [Column(TypeName = "decimal(10,2)")]
        public string? cmpl_add_od { get; private set; }

        [Column(TypeName = "decimal(10,2)")]
        public string? cmpl_add_oe { get; private set; }

        [Column(TypeName = "decimal(10,2)")]
        public string? base_od { get; private set; }

        [Column(TypeName = "decimal(10,2)")]
        public string? base_oe { get; private set; }

        [Column(TypeName = "decimal(10,2)")]
        public string? dist_haste { get; private set; }

        [Column(TypeName = "decimal(10,2)")]
        public string? dist_front { get; private set; }

        [Column(TypeName = "decimal(10,2)")]
        public string? curvatura { get; private set; }

        [Column(TypeName = "decimal(10,2)")]
        public string? lng_pris1_od { get; private set; }

        [Column(TypeName = "int")]
        public string? id_lng_pris1_od_desc { get; private set; }

        [Column(TypeName = "decimal(10,2)")]
        public string? lng_pris1_oe { get; private set; }

        [Column(TypeName = "int")]
        public string? id_lng_pris1_oe_desc { get; private set; }

        [Column(TypeName = "decimal(10,2)")]
        public string? prt_pris1_od { get; private set; }

        [Column(TypeName = "int")]
        public string? id_prt_pris1_od_desc { get; private set; }

        [Column(TypeName = "decimal(10,2)")]
        public string? prt_pris1_oe { get; private set; }

        [Column(TypeName = "int")]
        public string? id_prt_pris1_oe_desc { get; private set; }

        [Column(TypeName = "decimal(10,2)")]
        public string? lng_pris2_od { get; private set; }

        [Column(TypeName = "int")]
        public string? id_lng_pris2_od_desc { get; private set; }

        [Column(TypeName = "decimal(10,2)")]
        public string? lng_pris2_oe { get; private set; }

        [Column(TypeName = "int")]
        public string? id_lng_pris2_oe_desc { get; private set; }

        [Column(TypeName = "decimal(10,2)")]
        public string? prt_pris2_od { get; private set; }

        [Column(TypeName = "int")]
        public string? id_prt_pris2_od_desc { get; private set; }

        [Column(TypeName = "decimal(10,2)")]
        public string? prt_pris2_oe { get; private set; }

        [Column(TypeName = "int")]
        public string? id_prt_pris2_oe_desc { get; private set; }

        [Column(TypeName = "decimal(10,2)")]
        public string? dist_vertice { get; private set; }

        [Column(TypeName = "decimal(10,2)")]
        public string? inc_planto { get; private set; }

        [Column(TypeName = "varchar(40)")]
        public string? ativ_princ { get; private set; }

        [Column(TypeName = "varchar(15)")]
        public string? otico_area_privilegiada { get; private set; }

        [Column(TypeName = "decimal(10,2)")]
        public string? dist_visao { get; private set; }

        [Column(TypeName = "varchar(100)")]
        public string? personalizada { get; private set; }

        [Column(TypeName = "decimal(10,2)")]
        public string? pris_od { get; private set; }

        [Column(TypeName = "decimal(10,2)")]
        public string? pris_oe { get; private set; }

        [Column(TypeName = "decimal(10,2)")]
        public string? eixo_od { get; private set; }

        [Column(TypeName = "decimal(10,2)")]
        public string? eixo_oe { get; private set; }

        [Column(TypeName = "decimal(10,2)")]
        public string? borda_od { get; private set; }

        [Column(TypeName = "decimal(10,2)")]
        public string? borda_oe { get; private set; }

        [Column(TypeName = "decimal(10,2)")]
        public string? centro_od { get; private set; }

        [Column(TypeName = "decimal(10,2)")]
        public string? centro_oe { get; private set; }

        [Column(TypeName = "decimal(10,2)")]
        public string? furo_od { get; private set; }

        [Column(TypeName = "decimal(10,2)")]
        public string? furo_oe { get; private set; }

        [Column(TypeName = "varchar(40)")]
        public string? format_corte { get; private set; }

        [Column(TypeName = "varchar(40)")]
        public string? dist_leitura { get; private set; }

        [Column(TypeName = "varchar(100)")]
        public string? tipo_lente { get; private set; }

        [Column(TypeName = "varchar(100)")]
        public string? endereco_paciente { get; private set; }

        [Column(TypeName = "varchar(100)")]
        public string? medico_especialista { get; private set; }

        [Column(TypeName = "varchar(100)")]
        public string? endereco_medico_especialista { get; private set; }

        [Column(TypeName = "varchar(100)")]
        public string? refracionista_optico { get; private set; }

        [Column(TypeName = "datetime")]
        public string? data_receita { get; private set; }

        [Column(TypeName = "int")]
        public string? id_produtos_opticos_tipo_aro { get; private set; }

        [Column(TypeName = "decimal(10,2)")]
        public string? dp_montagem { get; private set; }

        [Column(TypeName = "int")]
        public string? id_produtos_opticos_formato_aro { get; private set; }

        [Column(TypeName = "varchar(40)")]
        public string? codigo_gerencial { get; private set; }

        [Column(TypeName = "bit")]
        public string? migracao_dados { get; private set; }

        [Column(TypeName = "varchar(max)")]
        public string? migracao_observacao { get; private set; }

        [Column(TypeName = "int")]
        public string? portal { get; private set; }

        [Column(TypeName = "bigint")]
        public string? timestamp { get; private set; }
    }
}
