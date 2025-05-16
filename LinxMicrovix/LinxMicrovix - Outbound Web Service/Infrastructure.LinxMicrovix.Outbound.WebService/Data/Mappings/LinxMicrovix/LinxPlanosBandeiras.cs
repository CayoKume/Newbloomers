using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using Domain.LinxMicrovix.Outbound.WebService.Entites.LinxMicrovix;
using Domain.LinxMicrovix.Outbound.WebService.Enums;
using Infrastructure.LinxMicrovix.Outbound.WebService.Data.Extensions;

namespace Infrastructure.LinxMicrovix.Outbound.WebService.Data.Mappings.LinxMicrovix
{
    public class LinxPlanosBandeirasMap : IEntityTypeConfiguration<LinxPlanosBandeiras>
    {
        public void Configure(EntityTypeBuilder<LinxPlanosBandeiras> builder)
        {
            builder.ToTable("LinxPlanosBandeiras", "linx_microvix_erp");

            builder.HasKey(e => e.plano);

            builder.Property(e => e.lastupdateon)
                .HasProviderColumnType(LogicalColumnType.DateTime);

            builder.Property(e => e.plano)
                .HasColumnType("int");

            builder.Property(e => e.portal)
                .HasColumnType("int");

            builder.Property(e => e.bandeira)
                .HasColumnType("varchar(30)");

            builder.Property(e => e.tipo_bandeira)
                .HasColumnType("varchar(100)");

            builder.Property(e => e.adquirente)
                .HasColumnType("int");

            builder.Property(e => e.nome_adquirente)
                .HasColumnType("varchar(60)");

            builder.Property(e => e.codigo_bandeira_sitef)
                .HasColumnType("varchar(10)");
        }
    }

    public class LinxPlanosBandeirasRawMap : IEntityTypeConfiguration<LinxPlanosBandeiras>
    {
        public void Configure(EntityTypeBuilder<LinxPlanosBandeiras> builder)
        {
            builder.ToTable("LinxPlanosBandeiras", "untreated");

            builder.HasKey(e => e.id);

            builder.Property(e => e.id)
                .HasColumnType("int")
                .ValueGeneratedOnAdd();

            builder.Property(e => e.lastupdateon)
                .HasProviderColumnType(LogicalColumnType.DateTime);

            builder.Property(e => e.plano)
                .HasColumnType("int");

            builder.Property(e => e.portal)
                .HasColumnType("int");

            builder.Property(e => e.bandeira)
                .HasColumnType("varchar(30)");

            builder.Property(e => e.tipo_bandeira)
                .HasColumnType("varchar(100)");

            builder.Property(e => e.adquirente)
                .HasColumnType("int");

            builder.Property(e => e.nome_adquirente)
                .HasColumnType("varchar(60)");

            builder.Property(e => e.codigo_bandeira_sitef)
                .HasColumnType("varchar(10)");
        }
    }
}
