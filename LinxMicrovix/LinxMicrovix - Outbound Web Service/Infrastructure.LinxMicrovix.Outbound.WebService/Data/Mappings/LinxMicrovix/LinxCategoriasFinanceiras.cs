using Microsoft.EntityFrameworkCore;
using Domain.LinxMicrovix.Outbound.WebService.Entites.LinxMicrovix;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Domain.LinxMicrovix.Outbound.WebService.Enums;
using Infrastructure.LinxMicrovix.Outbound.WebService.Data.Extensions;

namespace Infrastructure.LinxMicrovix.Outbound.WebService.Data.Mappings.LinxMicrovix
{
    public class LinxCategoriasFinanceirasMap : IEntityTypeConfiguration<LinxCategoriasFinanceiras>
    {
        public void Configure(EntityTypeBuilder<LinxCategoriasFinanceiras> builder)
        {
            builder.ToTable("LinxCategoriasFinanceiras", "linx_microvix_erp");

            builder.HasKey(e => e.id_categorias_financeiras);

            builder.Property(e => e.lastupdateon)
                .HasProviderColumnType(LogicalColumnType.DateTime);

            builder.Property(e => e.id_categorias_financeiras)
                .HasColumnType("int");

            builder.Property(e => e.descricao)
                .HasColumnType("varchar(50)");

            builder.Property(e => e.ativo)
                .HasProviderColumnType(LogicalColumnType.Bool);

            builder.Property(e => e.historico)
                .HasColumnType("bigint");

            builder.Property(e => e.timestamp)
                .HasColumnType("bigint");
        }
    }

    public class LinxCategoriasFinanceirasRawMap : IEntityTypeConfiguration<LinxCategoriasFinanceiras>
    {
        public void Configure(EntityTypeBuilder<LinxCategoriasFinanceiras> builder)
        {
            builder.ToTable("LinxCategoriasFinanceiras", "untreated");

            builder.HasKey(e => e.id);

            builder.Property(e => e.id)
                .HasColumnType("int")
                .ValueGeneratedOnAdd();

            builder.Property(e => e.lastupdateon)
                .HasProviderColumnType(LogicalColumnType.DateTime);

            builder.Property(e => e.id_categorias_financeiras)
                .HasColumnType("int");

            builder.Property(e => e.descricao)
                .HasColumnType("varchar(50)");

            builder.Property(e => e.ativo)
                .HasProviderColumnType(LogicalColumnType.Bool);

            builder.Property(e => e.historico)
                .HasColumnType("bigint");

            builder.Property(e => e.timestamp)
                .HasColumnType("bigint");
        }
    }
}
