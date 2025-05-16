using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using Domain.LinxMicrovix.Outbound.WebService.Entites.LinxMicrovix;
using Domain.LinxMicrovix.Outbound.WebService.Enums;
using Infrastructure.LinxMicrovix.Outbound.WebService.Data.Extensions;

namespace Infrastructure.LinxMicrovix.Outbound.WebService.Data.Mappings.LinxMicrovix
{
    public class LinxProdutosOpticosFormatoAroTrustedMap : IEntityTypeConfiguration<LinxProdutosOpticosFormatoAro>
    {
        public void Configure(EntityTypeBuilder<LinxProdutosOpticosFormatoAro> builder)
        {
            builder.ToTable("LinxProdutosOpticosFormatoAro", "linx_microvix_erp");

            builder.HasKey(e => e.id_formato_aro);

            builder.Property(e => e.lastupdateon)
                .HasProviderColumnType(LogicalColumnType.DateTime);

            builder.Property(e => e.id_formato_aro)
                .HasColumnType("int");

            builder.Property(e => e.codigo)
                .HasColumnType("varchar(16)");

            builder.Property(e => e.descricao)
                .HasColumnType("varchar(60)");

            builder.Property(e => e.timestamp)
                .HasColumnType("bigint");
        }
    }

    public class LinxProdutosOpticosFormatoAroRawMap : IEntityTypeConfiguration<LinxProdutosOpticosFormatoAro>
    {
        public void Configure(EntityTypeBuilder<LinxProdutosOpticosFormatoAro> builder)
        {
            builder.ToTable("LinxProdutosOpticosFormatoAro", "untreated");

            builder.HasKey(e => e.id);

            builder.Property(e => e.id)
                .HasColumnType("int")
                .ValueGeneratedOnAdd();

            builder.Property(e => e.lastupdateon)
                .HasProviderColumnType(LogicalColumnType.DateTime);

            builder.Property(e => e.id_formato_aro)
                .HasColumnType("int");

            builder.Property(e => e.codigo)
                .HasColumnType("varchar(16)");

            builder.Property(e => e.descricao)
                .HasColumnType("varchar(60)");

            builder.Property(e => e.timestamp)
                .HasColumnType("bigint");
        }
    }
}
