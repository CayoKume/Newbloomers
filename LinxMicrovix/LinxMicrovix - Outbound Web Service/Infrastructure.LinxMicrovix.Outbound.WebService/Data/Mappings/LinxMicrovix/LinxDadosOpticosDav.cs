using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using Domain.LinxMicrovix.Outbound.WebService.Entites.LinxMicrovix;
using Domain.LinxMicrovix.Outbound.WebService.Enums;
using Infrastructure.LinxMicrovix.Outbound.WebService.Data.Extensions;


namespace Infrastructure.LinxMicrovix.Outbound.WebService.Data.Mappings.LinxMicrovix
{
    public class LinxDadosOpticosDavMap : IEntityTypeConfiguration<LinxDadosOpticosDav>
    {
        

        

        public void Configure(EntityTypeBuilder<LinxDadosOpticosDav> builder)
        {
            builder.ToTable("LinxDadosOpticosDav");

            builder.HasKey(e => e.id_vendas_pos_produtos);

            builder.Property(e => e.lastupdateon)
                .HasProviderColumnType(LogicalColumnType.DateTime);

            builder.Property(e => e.id_vendas_pos_produtos)
                .HasColumnType("bigint");

            builder.Property(e => e.cod_produto)
                .HasColumnType("bigint");

            builder.Property(e => e.dav)
                .HasColumnType("int");

            builder.Property(e => e.tipo_lente)
                .HasColumnType("varchar(20)");

            builder.Property(e => e.od_oe)
                .HasColumnType("varchar(2)");

            builder.Property(e => e.lng_esferico_od)
                .HasColumnType("decimal(10,2)");

            builder.Property(e => e.lng_cilindrico_od)
                .HasColumnType("decimal(10,2)");

            builder.Property(e => e.lng_eixo_od)
                .HasColumnType("decimal(10,2)");

            builder.Property(e => e.lng_esferico_oe)
                .HasColumnType("decimal(10,2)");

            builder.Property(e => e.lng_cilindrico_oe)
                .HasColumnType("decimal(10,2)");

            builder.Property(e => e.lng_eixo_oe)
                .HasColumnType("decimal(10,2)");

            builder.Property(e => e.prt_esferico_od)
                .HasColumnType("decimal(10,2)");

            builder.Property(e => e.prt_cilindrico_od)
                .HasColumnType("decimal(10,2)");

            builder.Property(e => e.prt_eixo_od)
                .HasColumnType("decimal(10,2)");

            builder.Property(e => e.prt_esferico_oe)
                .HasColumnType("decimal(10,2)");

            builder.Property(e => e.prt_cilindrico_oe)
                .HasColumnType("decimal(10,2)");

            builder.Property(e => e.prt_eixo_oe)
                .HasColumnType("decimal(10,2)");

            builder.Property(e => e.cmpl_add_od)
                .HasColumnType("decimal(10,2)");

            builder.Property(e => e.base_od)
                .HasColumnType("decimal(10,2)");

            builder.Property(e => e.diametro_od)
                .HasColumnType("decimal(10,2)");

            builder.Property(e => e.cmpl_add_oe)
                .HasColumnType("decimal(10,2)");

            builder.Property(e => e.base_oe)
                .HasColumnType("decimal(10,2)");

            builder.Property(e => e.diametro_oe)
                .HasColumnType("decimal(10,2)");

            builder.Property(e => e.ponte)
                .HasColumnType("decimal(10,2)");

            builder.Property(e => e.altura)
                .HasColumnType("decimal(10,2)");

            builder.Property(e => e.aro)
                .HasColumnType("decimal(10,2)");

            builder.Property(e => e.diag_maior)
                .HasColumnType("decimal(10,2)");

            builder.Property(e => e.dist_haste)
                .HasColumnType("decimal(10,2)");

            builder.Property(e => e.dist_front)
                .HasColumnType("decimal(10,2)");

            builder.Property(e => e.tipo_armacao)
                .HasColumnType("varchar(1)");

            builder.Property(e => e.curvatura)
                .HasColumnType("decimal(10,2)");

            builder.Property(e => e.id_produtos_opticos_tipo_aro)
                .HasColumnType("int");

            builder.Property(e => e.id_produtos_opticos_formato_aro)
                .HasColumnType("int");

            builder.Property(e => e.lng_dpdpn_od)
                .HasColumnType("decimal(10,2)");

            builder.Property(e => e.prt_dpdpn_od)
                .HasColumnType("decimal(10,2)");

            builder.Property(e => e.lng_dpdpn_oe)
                .HasColumnType("decimal(10,2)");

            builder.Property(e => e.prt_dpdpn_oe)
                .HasColumnType("decimal(10,2)");

            builder.Property(e => e.lng_altura_od)
                .HasColumnType("decimal(10,2)");

            builder.Property(e => e.prt_altura_od)
                .HasColumnType("decimal(10,2)");

            builder.Property(e => e.lng_altura_oe)
                .HasColumnType("decimal(10,2)");

            builder.Property(e => e.prt_altura_oe)
                .HasColumnType("decimal(10,2)");

            builder.Property(e => e.calibre)
                .HasColumnType("decimal(10,2)");

            builder.Property(e => e.dp_montagem)
                .HasColumnType("decimal(10,2)");

            builder.Property(e => e.observacao)
                .HasProviderColumnType(LogicalColumnType.Varchar_Max);

            builder.Property(e => e.paciente)
                .HasColumnType("varchar(100)");

            builder.Property(e => e.endereco_paciente)
                .HasColumnType("varchar(100)");

            builder.Property(e => e.medico_especialista)
                .HasColumnType("varchar(100)");

            builder.Property(e => e.endereco_medico_especialista)
                .HasColumnType("varchar(100)");

            builder.Property(e => e.refracionista_optico)
                .HasColumnType("varchar(100)");

            builder.Property(e => e.data_receita)
                .HasColumnType("bigint");

            builder.Property(e => e.timestamp)
                .HasColumnType("bigint");

            builder.Property(e => e.id_ordservprod)
                .HasColumnType("int");

            builder.Property(e => e.id_vendas_pos_produtos_tmp)
                .HasColumnType("int");

            builder.Property(e => e.id_vendas_pos)
                .HasColumnType("bigint");

            builder.Property(e => e.cancelado)
                .HasProviderColumnType(LogicalColumnType.Bool);

            builder.Property(e => e.previsao_entrega)
                .HasProviderColumnType(LogicalColumnType.DateTime);

            builder.Property(e => e.numero_ficha)
                .HasColumnType("bigint");

            builder.Property(e => e.id_vendas_pos_produtos_campos_adicionais_tmp)
                .HasColumnType("int");

            builder.Property(e => e.id_link_pagamento_linx_pay_hub)
                .HasColumnType("int");

            builder.Property(e => e.codigo_gerencial)
                .HasColumnType("varchar(20)");

            builder.Property(e => e.empresa)
                .HasColumnType("int");

            builder.Property(e => e.origem)
                .HasColumnType("int");

            builder.Property(e => e.acoes_promocionais_desconto)
                .HasColumnType("decimal(10,2)");

            builder.Property(e => e.desconto)
                .HasColumnType("decimal(10,2)");

            builder.Property(e => e.acrescimo)
                .HasColumnType("decimal(10,2)");

            builder.Property(e => e.frete)
                .HasColumnType("decimal(10,2)");

            builder.Property(e => e.descontos_impostos)
                .HasColumnType("decimal(10,2)");

            builder.Property(e => e.acrescimos_impostos)
                .HasColumnType("decimal(10,2)");

            builder.Property(e => e.preco_unitario)
                .HasColumnType("decimal(10,2)");

            builder.Property(e => e.quantidade)
                .HasColumnType("decimal(10,2)");

            builder.Property(e => e.desconto_item)
                .HasColumnType("decimal(10,2)");

            builder.Property(e => e.acrescimo_item_valor)
                .HasColumnType("decimal(10,2)");

            builder.Property(e => e.desconto_item_valor)
                .HasColumnType("decimal(10,2)");
        }
    }
}
