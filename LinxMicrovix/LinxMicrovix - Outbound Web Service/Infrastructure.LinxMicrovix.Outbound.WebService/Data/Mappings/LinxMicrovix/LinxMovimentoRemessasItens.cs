using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using Domain.LinxMicrovix.Outbound.WebService.Entites.LinxMicrovix;
using Domain.LinxMicrovix.Outbound.WebService.Enums;
using Infrastructure.LinxMicrovix.Outbound.WebService.Data.Extensions;


namespace Infrastructure.LinxMicrovix.Outbound.WebService.Data.Mappings.LinxMicrovix
{
    public class LinxMovimentoRemessasItensMap : IEntityTypeConfiguration<LinxMovimentoRemessasItens>
    {
        

        

        public void Configure(EntityTypeBuilder<LinxMovimentoRemessasItens> builder)
        {
            builder.ToTable("LinxMovimentoRemessasItens");

            builder.HasKey(e => e.id_remessas_itens);

            builder.Property(e => e.lastupdateon)
                .HasProviderColumnType(LogicalColumnType.DateTime);

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
