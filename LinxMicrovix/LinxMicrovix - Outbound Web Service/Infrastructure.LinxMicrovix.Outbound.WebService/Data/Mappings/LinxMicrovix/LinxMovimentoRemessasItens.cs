using Infrastructure.IntegrationsCore.Data.Schemas;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using Domain.LinxMicrovix.Outbound.WebService.Models.LinxMicrovix;
using Infrastructure.IntegrationsCore.Data.Extensions;
using Domain.IntegrationsCore.Enums;

namespace Infrastructure.LinxMicrovix.Outbound.WebService.Data.Mappings.LinxMicrovix
{
    public class LinxMovimentoRemessasItensMap : IEntityTypeConfiguration<LinxMovimentoRemessasItens>
    {
        public void Configure(EntityTypeBuilder<LinxMovimentoRemessasItens> builder)
        {
            var schema = SchemaContext.GetSchema(typeof(LinxMovimentoRemessasItens));

            builder.ToTable("LinxMovimentoRemessasItens");

            if (schema == "linx_microvix_erp")
            {
                builder.HasKey(e => e.id_remessas_itens);
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

            builder.Property(e => e.id_remessas_itens)
                .HasColumnType("int");

            builder.Property(e => e.empresa)
                .HasColumnType("int");

            builder.Property(e => e.portal)
                .HasColumnType("int");

            builder.Property(e => e.id_remessas)
                .HasColumnType("int");

            builder.Property(e => e.transacao)
                .HasColumnType("int");

            builder.Property(e => e.qtde_total)
                .HasColumnType("decimal(10,2)");

            builder.Property(e => e.qtde_venda)
                .HasColumnType("decimal(10,2)");

            builder.Property(e => e.qtde_devolvido)
                .HasColumnType("decimal(10,2)");

            builder.Property(e => e.qtde_pendente)
                .HasColumnType("decimal(10,2)");

            builder.Property(e => e.qtde_pendente_pagamento)
                .HasColumnType("decimal(10,2)");

            builder.Property(e => e.timestamp)
                .HasColumnType("bigint");
        }
    }
}
