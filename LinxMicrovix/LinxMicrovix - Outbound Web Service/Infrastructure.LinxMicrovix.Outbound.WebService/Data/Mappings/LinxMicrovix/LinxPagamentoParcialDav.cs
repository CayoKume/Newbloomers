using Infrastructure.IntegrationsCore.Data.Schemas;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using Domain.LinxMicrovix.Outbound.WebService.Entities.LinxMicrovix;
using Domain.IntegrationsCore.Entities.Enums;
using Infrastructure.IntegrationsCore.Data.Extensions;

namespace Infrastructure.LinxMicrovix.Outbound.WebService.Data.Mappings.LinxMicrovix
{
    public class LinxPagamentoParcialDavMap : IEntityTypeConfiguration<LinxPagamentoParcialDav>
    {
        public void Configure(EntityTypeBuilder<LinxPagamentoParcialDav> builder)
        {
            var schema = SchemaContext.GetSchema(typeof(LinxPagamentoParcialDav));

            builder.ToTable("LinxPagamentoParcialDav");

            if (schema == "linx_microvix_erp")
            {
                builder.HasKey(e => e.id_pagamento_parcial_tmp);
                builder.Ignore(x => x.id);
            }
            else
            {
                builder.HasKey(x => x.id);

                builder.Property(e => e.id)
                    .HasColumnType("int")
                    .ValueGeneratedOnAdd();
            }

            builder.Property(e => e.lastupdateon)
                .HasProviderColumnType(EnumTableColumnType.DateTime);

            builder.Property(e => e.id_pagamento_parcial_tmp)
                .HasColumnType("int");

            builder.Property(e => e.id_vendas_pos)
                .HasColumnType("int");

            builder.Property(e => e.valor)
                .HasColumnType("decimal(10,2)");

            builder.Property(e => e.ajuste_valor_desc_acresc_plano)
                .HasColumnType("decimal(10,2)");

            builder.Property(e => e.timestamp)
                .HasColumnType("bigint");

            builder.Property(e => e.plano)
                .HasColumnType("int");

            builder.Property(e => e.forma_pgto)
                .HasColumnType("varchar(50)");

            builder.Property(e => e.id_bandeira)
                .HasColumnType("int");

            builder.Property(e => e.qtde_parcelas)
                .HasColumnType("int");

            builder.Property(e => e.credito_debito)
                .HasColumnType("varchar(1)");

            builder.Property(e => e.portal)
                .HasColumnType("int");
        }
    }
}
