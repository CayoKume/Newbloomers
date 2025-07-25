using Infrastructure.IntegrationsCore.Data.Schemas;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using Domain.LinxMicrovix.Outbound.WebService.Models.LinxCommerce;
using Infrastructure.IntegrationsCore.Data.Extensions;

using Domain.IntegrationsCore.Enums;

namespace Infrastructure.LinxMicrovix.Outbound.WebService.Data.Mappings.LinxCommerce
{
    public class B2CConsultaPedidosPlanosMap : IEntityTypeConfiguration<B2CConsultaPedidosPlanos>
    {
        public void Configure(EntityTypeBuilder<B2CConsultaPedidosPlanos> builder)
        {
            var schema = SchemaContext.GetSchema(typeof(B2CConsultaPedidosPlanos));

            builder.ToTable("B2CConsultaPedidosPlanos");

            if (schema == "linx_microvix_commerce")
            {
                builder.HasKey(e => new { e.id_pedido_planos, e.id_pedido });
                builder.Ignore(e => e.id);
            }    
            else
            {
                builder.HasKey(e => e.id);

                builder.Property(e => e.id)
                    .HasColumnType("int")
                    .ValueGeneratedOnAdd();
            }
            
            builder.Property(e => e.lastupdateon)
                .HasProviderColumnType(EnumTableColumnType.DateTime);

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
                .HasProviderColumnType(EnumTableColumnType.Varchar_Max);

            builder.Property(e => e.cod_loja_sitef)
                .HasColumnType("varchar(10)");

            builder.Property(e => e.timestamp)
                .HasColumnType("bigint");

            builder.Property(e => e.portal)
                .HasColumnType("int");
        }
    }
}
