using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using Domain.LinxMicrovix.Outbound.WebService.Entites.LinxMicrovix;
using Domain.LinxMicrovix.Outbound.WebService.Enums;
using Infrastructure.LinxMicrovix.Outbound.WebService.Data.Extensions;

namespace Infrastructure.LinxMicrovix.Outbound.WebService.Data.Mappings.LinxMicrovix
{
    public class LinxRemessasOperacoesMap : IEntityTypeConfiguration<LinxRemessasOperacoes>
    {
        public void Configure(EntityTypeBuilder<LinxRemessasOperacoes> builder)
        {
            builder.ToTable("LinxRemessasOperacoes", "linx_microvix_erp");

            builder.HasKey(e => e.id_remessa_operacoes);

            builder.Property(e => e.lastupdateon)
                .HasProviderColumnType(LogicalColumnType.DateTime);

            builder.Property(e => e.id_remessa_operacoes)
                .HasColumnType("int");

            builder.Property(e => e.portal)
                .HasColumnType("int");

            builder.Property(e => e.descricao)
                .HasColumnType("varchar(30)");

            builder.Property(e => e.timestamp)
                .HasColumnType("bigint");
        }
    }

    public class LinxRemessasOperacoesRawMap : IEntityTypeConfiguration<LinxRemessasOperacoes>
    {
        public void Configure(EntityTypeBuilder<LinxRemessasOperacoes> builder)
        {
            builder.ToTable("LinxRemessasOperacoes", "untreated");

            builder.HasKey(e => e.id);

            builder.Property(e => e.id)
                .HasColumnType("int")
                .ValueGeneratedOnAdd();

            builder.Property(e => e.lastupdateon)
                .HasProviderColumnType(LogicalColumnType.DateTime);

            builder.Property(e => e.id_remessa_operacoes)
                .HasColumnType("int");

            builder.Property(e => e.portal)
                .HasColumnType("int");

            builder.Property(e => e.descricao)
                .HasColumnType("varchar(30)");

            builder.Property(e => e.timestamp)
                .HasColumnType("bigint");
        }
    }
}
