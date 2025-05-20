using Infrastructure.LinxMicrovix.Outbound.WebService.Schema;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using Domain.LinxMicrovix.Outbound.WebService.Entites.LinxCommerce;
using Domain.LinxMicrovix.Outbound.WebService.Enums;
using Infrastructure.LinxMicrovix.Outbound.WebService.Data.Extensions;
using Domain.LinxMicrovix.Outbound.WebService.Entites.LinxMicrovix;

namespace Infrastructure.LinxMicrovix.Outbound.WebService.Data.Mappings.LinxCommerce
{
    public class B2CConsultaPlanosMap : IEntityTypeConfiguration<B2CConsultaPlanos>
    {
        public void Configure(EntityTypeBuilder<B2CConsultaPlanos> builder)
        {
            var schema = SchemaContext.GetSchema(typeof(B2CConsultaPlanos));

            builder.ToTable("B2CConsultaPlanos");

            if (schema == "linx_microvix_commerce")
            {
                builder.HasKey(e => e.plano);
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
                .HasProviderColumnType(LogicalColumnType.DateTime);

            builder.Property(e => e.plano)
                .HasColumnType("int");

            builder.Property(e => e.nome_plano)
                .HasColumnType("varchar(30)");

            builder.Property(e => e.forma_pagamento)
                .HasColumnType("int");

            builder.Property(e => e.qtde_parcelas)
                .HasColumnType("int");

            builder.Property(e => e.valor_minimo_parcela)
                .HasColumnType("decimal(10,2)");

            builder.Property(e => e.indice)
                .HasColumnType("decimal(10,2)");

            builder.Property(e => e.timestamp)
                .HasColumnType("bigint");

            builder.Property(e => e.desativado)
                .HasColumnType("char(1)");

            builder.Property(e => e.tipo_plano)
                .HasColumnType("char(1)");

            builder.Property(e => e.portal)
                .HasColumnType("int");
        }
    }
}
