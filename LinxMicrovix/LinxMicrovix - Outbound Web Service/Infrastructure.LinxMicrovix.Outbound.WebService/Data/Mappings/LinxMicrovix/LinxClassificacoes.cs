using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using Domain.LinxMicrovix.Outbound.WebService.Entites.LinxMicrovix;
using Domain.LinxMicrovix.Outbound.WebService.Enums;
using Infrastructure.LinxMicrovix.Outbound.WebService.Data.Extensions;

namespace Infrastructure.LinxMicrovix.Outbound.WebService.Data.Mappings.LinxMicrovix
{
    public class LinxClassificacoesTrustedMap : IEntityTypeConfiguration<LinxClassificacoes>
    {
        public void Configure(EntityTypeBuilder<LinxClassificacoes> builder)
        {
            builder.ToTable("LinxClassificacoes", "linx_microvix_erp");

            builder.HasKey(e => e.id_classificacao);

            builder.Property(e => e.lastupdateon)
                .HasProviderColumnType(LogicalColumnType.DateTime);

            builder.Property(e => e.id_classificacao)
                .HasColumnType("int");

            builder.Property(e => e.desc_classificacao)
                .HasColumnType("varchar(50)");

            builder.Property(e => e.timestamp)
                .HasColumnType("bigint");

            builder.Property(e => e.codigo_integracao_ws)
                .HasColumnType("varchar(50)");

            builder.Property(e => e.ativo)
                .HasProviderColumnType(LogicalColumnType.Bool);
        }
    }

    public class LinxClassificacoesRawMap : IEntityTypeConfiguration<LinxClassificacoes>
    {
        public void Configure(EntityTypeBuilder<LinxClassificacoes> builder)
        {
            builder.ToTable("LinxClassificacoes", "untreated");

            builder.HasKey(e => e.id);

            builder.Property(e => e.id)
                .HasColumnType("int")
                .ValueGeneratedOnAdd();

            builder.Property(e => e.lastupdateon)
                .HasProviderColumnType(LogicalColumnType.DateTime);

            builder.Property(e => e.id_classificacao)
                .HasColumnType("int");

            builder.Property(e => e.desc_classificacao)
                .HasColumnType("varchar(50)");

            builder.Property(e => e.timestamp)
                .HasColumnType("bigint");

            builder.Property(e => e.codigo_integracao_ws)
                .HasColumnType("varchar(50)");

            builder.Property(e => e.ativo)
                .HasProviderColumnType(LogicalColumnType.Bool);
        }
    }
}