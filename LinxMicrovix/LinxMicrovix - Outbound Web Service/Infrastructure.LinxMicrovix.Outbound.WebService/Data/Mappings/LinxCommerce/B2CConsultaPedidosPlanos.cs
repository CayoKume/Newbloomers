using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using Domain.LinxMicrovix.Outbound.WebService.Entites.LinxCommerce;
using Domain.LinxMicrovix.Outbound.WebService.Enums;
using Infrastructure.LinxMicrovix.Outbound.WebService.Data.Extensions;

namespace Infrastructure.LinxMicrovix.Outbound.WebService.Data.Mappings.LinxCommerce
{
    public class B2CConsultaPedidosPlanosMap : IEntityTypeConfiguration<B2CConsultaPedidosPlanos>
    {
        public void Configure(EntityTypeBuilder<B2CConsultaPedidosPlanos> builder)
        {
            builder.ToTable("B2CConsultaPedidosPlanos", "linx_microvix_commerce");

            builder.HasKey(e => new { e.id_pedido_planos, e.id_pedido });

            builder.Property(e => e.lastupdateon)
                .HasProviderColumnType(LogicalColumnType.DateTime);

            builder.Property(e => e.id_pedido_planos)
                .HasColumnType("bigint");

            builder.Property(e => e.id_pedido)
                .HasColumnType("int");

            builder.Property(e => e.plano_pagamento)
                .HasColumnType("int");

            builder.Property(e => e.valor_plano)
                .HasColumnType("decimal(10,2)");

            builder.Property(e => e.nsu_sitef)
                .HasColumnType("varchar(20)");

            builder.Property(e => e.cod_autorizacao)
                .HasColumnType("varchar(50)");

            builder.Property(e => e.texto_comprovante)
                .HasProviderColumnType(LogicalColumnType.Varchar_Max);

            builder.Property(e => e.cod_loja_sitef)
                .HasColumnType("varchar(10)");

            builder.Property(e => e.timestamp)
                .HasColumnType("bigint");

            builder.Property(e => e.portal)
                .HasColumnType("int");
        }
    }
}
