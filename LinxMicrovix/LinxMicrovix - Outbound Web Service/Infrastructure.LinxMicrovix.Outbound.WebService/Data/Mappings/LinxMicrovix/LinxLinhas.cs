using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using Domain.LinxMicrovix.Outbound.WebService.Entites.LinxMicrovix;
using Domain.LinxMicrovix.Outbound.WebService.Enums;
using Infrastructure.LinxMicrovix.Outbound.WebService.Data.Extensions;

namespace Infrastructure.LinxMicrovix.Outbound.WebService.Data.Mappings.LinxMicrovix
{
    public class LinxLinhasMap : IEntityTypeConfiguration<LinxLinhas>
    {
        public void Configure(EntityTypeBuilder<LinxLinhas> builder)
        {
            builder.ToTable("LinxLinhas", "linx_microvix_erp");

            builder.HasKey(e => e.id_linha);

            builder.Property(e => e.lastupdateon)
                .HasProviderColumnType(LogicalColumnType.DateTime);

            builder.Property(e => e.id_linha)
                .HasColumnType("int");

            builder.Property(e => e.desc_linha)
                .HasColumnType("varchar(30)");

            builder.Property(e => e.timestamp)
                .HasColumnType("bigint");

            builder.Property(e => e.codigo_integracao_ws)
                .HasColumnType("varchar(50)");

            builder.Property(e => e.portal)
                .HasColumnType("int");

            builder.Property(e => e.coeficiente_comissao)
                .HasColumnType("decimal(10,2)");
        }
    }

    public class LinxLinhasRawMap : IEntityTypeConfiguration<LinxLinhas>
    {
        public void Configure(EntityTypeBuilder<LinxLinhas> builder)
        {
            builder.ToTable("LinxLinhas", "untreated");

            builder.HasKey(e => e.id);

            builder.Property(e => e.id)
                .HasColumnType("int")
                .ValueGeneratedOnAdd();

            builder.Property(e => e.lastupdateon)
                .HasProviderColumnType(LogicalColumnType.DateTime);

            builder.Property(e => e.id_linha)
                .HasColumnType("int");

            builder.Property(e => e.desc_linha)
                .HasColumnType("varchar(30)");

            builder.Property(e => e.timestamp)
                .HasColumnType("bigint");

            builder.Property(e => e.codigo_integracao_ws)
                .HasColumnType("varchar(50)");

            builder.Property(e => e.portal)
                .HasColumnType("int");

            builder.Property(e => e.coeficiente_comissao)
                .HasColumnType("decimal(10,2)");
        }
    }
}
