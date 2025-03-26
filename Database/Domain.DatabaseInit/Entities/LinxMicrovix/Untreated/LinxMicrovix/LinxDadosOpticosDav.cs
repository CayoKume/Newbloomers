using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Globalization;

namespace Domain.DatabaseInit.Entities.LinxMicrovix.Untreated.LinxMicrovix
{
    [Table("LinxDadosOpticosDav", Schema = "untreated")]
    public class LinxDadosOpticosDav
    {
        [Column(TypeName = "datetime")]
        public string? lastupdateon { get; private set; }

        [Key]
        [Column(TypeName = "bigint")]
        public string? id_vendas_pos_produtos { get; private set; }

        [Column(TypeName = "bigint")]
        public string? cod_produto { get; private set; }

        [Column(TypeName = "int")]
        public string? dav { get; private set; }

        [Column(TypeName = "varchar(20)")]
        public string? tipo_lente { get; private set; }

        [Column(TypeName = "varchar(2)")]
        public string? od_oe { get; private set; }

        [Column(TypeName = "decimal(10,2)")]
        public string? lng_esferico_od { get; private set; }

        [Column(TypeName = "decimal(10,2)")]
        public string? lng_cilindrico_od { get; private set; }

        [Column(TypeName = "decimal(10,2)")]
        public string? lng_eixo_od { get; private set; }

        [Column(TypeName = "decimal(10,2)")]
        public string? lng_esferico_oe { get; private set; }

        [Column(TypeName = "decimal(10,2)")]
        public string? lng_cilindrico_oe { get; private set; }

        [Column(TypeName = "decimal(10,2)")]
        public string? lng_eixo_oe { get; private set; }

        [Column(TypeName = "decimal(10,2)")]
        public string? prt_esferico_od { get; private set; }

        [Column(TypeName = "decimal(10,2)")]
        public string? prt_cilindrico_od { get; private set; }

        [Column(TypeName = "decimal(10,2)")]
        public string? prt_eixo_od { get; private set; }

        [Column(TypeName = "decimal(10,2)")]
        public string? prt_esferico_oe { get; private set; }

        [Column(TypeName = "decimal(10,2)")]
        public string? prt_cilindrico_oe { get; private set; }

        [Column(TypeName = "decimal(10,2)")]
        public string? prt_eixo_oe { get; private set; }

        [Column(TypeName = "decimal(10,2)")]
        public string? cmpl_add_od { get; private set; }

        [Column(TypeName = "decimal(10,2)")]
        public string? base_od { get; private set; }

        [Column(TypeName = "decimal(10,2)")]
        public string? diametro_od { get; private set; }

        [Column(TypeName = "decimal(10,2)")]
        public string? cmpl_add_oe { get; private set; }

        [Column(TypeName = "decimal(10,2)")]
        public string? base_oe { get; private set; }

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

        [Column(TypeName = "decimal(10,2)")]
        public string? dist_haste { get; private set; }

        [Column(TypeName = "decimal(10,2)")]
        public string? dist_front { get; private set; }

        [Column(TypeName = "varchar(1)")]
        public string? tipo_armacao { get; private set; }

        [Column(TypeName = "decimal(10,2)")]
        public string? curvatura { get; private set; }

        [Column(TypeName = "int")]
        public string? id_produtos_opticos_tipo_aro { get; private set; }

        [Column(TypeName = "int")]
        public string? id_produtos_opticos_formato_aro { get; private set; }

        [Column(TypeName = "decimal(10,2)")]
        public string? lng_dpdpn_od { get; private set; }

        [Column(TypeName = "decimal(10,2)")]
        public string? prt_dpdpn_od { get; private set; }

        [Column(TypeName = "decimal(10,2)")]
        public string? lng_dpdpn_oe { get; private set; }

        [Column(TypeName = "decimal(10,2)")]
        public string? prt_dpdpn_oe { get; private set; }

        [Column(TypeName = "decimal(10,2)")]
        public string? lng_altura_od { get; private set; }

        [Column(TypeName = "decimal(10,2)")]
        public string? prt_altura_od { get; private set; }

        [Column(TypeName = "decimal(10,2)")]
        public string? lng_altura_oe { get; private set; }

        [Column(TypeName = "decimal(10,2)")]
        public string? prt_altura_oe { get; private set; }

        [Column(TypeName = "decimal(10,2)")]
        public string? calibre { get; private set; }

        [Column(TypeName = "decimal(10,2)")]
        public string? dp_montagem { get; private set; }

        [Column(TypeName = "varchar(max)")]
        public string? observacao { get; private set; }

        [Column(TypeName = "varchar(100)")]
        public string? paciente { get; private set; }

        [Column(TypeName = "varchar(100)")]
        public string? endereco_paciente { get; private set; }

        [Column(TypeName = "varchar(100)")]
        public string? medico_especialista { get; private set; }

        [Column(TypeName = "varchar(100)")]
        public string? endereco_medico_especialista { get; private set; }

        [Column(TypeName = "varchar(100)")]
        public string? refracionista_optico { get; private set; }

        [Column(TypeName = "bigint")]
        public string? data_receita { get; private set; }

        [Column(TypeName = "bigint")]
        public string? timestamp { get; private set; }

        [Column(TypeName = "int")]
        public string? id_ordservprod { get; private set; }

        [Column(TypeName = "int")]
        public string? id_vendas_pos_produtos_tmp { get; private set; }

        [Column(TypeName = "bigint")]
        public string? id_vendas_pos { get; private set; }

        [Column(TypeName = "bit")]
        public string? cancelado { get; private set; }

        [Column(TypeName = "datetime")]
        public string? previsao_entrega { get; private set; }

        [Column(TypeName = "bigint")]
        public string? numero_ficha { get; private set; }

        [Column(TypeName = "int")]
        public string? id_vendas_pos_produtos_campos_adicionais_tmp { get; private set; }

        [Column(TypeName = "int")]
        public string? id_link_pagamento_linx_pay_hub { get; private set; }

        [Column(TypeName = "varchar(20)")]
        public string? codigo_gerencial { get; private set; }

        [Column(TypeName = "int")]
        public string? empresa { get; private set; }

        [Column(TypeName = "int")]
        public string? origem { get; private set; }

        [Column(TypeName = "decimal(10,2)")]
        public string? acoes_promocionais_desconto { get; private set; }

        [Column(TypeName = "decimal(10,2)")]
        public string? desconto { get; private set; }

        [Column(TypeName = "decimal(10,2)")]
        public string? acrescimo { get; private set; }

        [Column(TypeName = "decimal(10,2)")]
        public string? frete { get; private set; }

        [Column(TypeName = "decimal(10,2)")]
        public string? descontos_impostos { get; private set; }

        [Column(TypeName = "decimal(10,2)")]
        public string? acrescimos_impostos { get; private set; }

        [Column(TypeName = "decimal(10,2)")]
        public string? preco_unitario { get; private set; }

        [Column(TypeName = "decimal(10,2)")]
        public string? quantidade { get; private set; }

        [Column(TypeName = "decimal(10,2)")]
        public string? desconto_item { get; private set; }

        [Column(TypeName = "decimal(10,2)")]
        public string? acrescimo_item_valor { get; private set; }

        [Column(TypeName = "decimal(10,2)")]
        public string? desconto_item_valor { get; private set; }
    }
}
