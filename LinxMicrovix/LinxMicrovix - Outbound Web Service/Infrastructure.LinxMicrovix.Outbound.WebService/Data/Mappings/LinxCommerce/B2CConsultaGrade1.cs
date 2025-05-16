using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using Domain.LinxMicrovix.Outbound.WebService.Entites.LinxCommerce;
using Domain.LinxMicrovix.Outbound.WebService.Enums;
using Infrastructure.LinxMicrovix.Outbound.WebService.Data.Extensions;

namespace Infrastructure.LinxMicrovix.Outbound.WebService.Data.Mappings.LinxCommerce
{
    public class B2CConsultaGrade1TrustedMap : IEntityTypeConfiguration<B2CConsultaGrade1>
    {
        public void Configure(EntityTypeBuilder<B2CConsultaGrade1> builder)
        {
            builder.ToTable("B2CConsultaGrade1", "linx_microvix_commerce");

            builder.HasKey(e => e.codigo_grade1);

            builder.Property(e => e.lastupdateon)
                .HasProviderColumnType(LogicalColumnType.DateTime);

            builder.Property(e => e.codigo_grade1)
                .HasColumnType("int");

            builder.Property(e => e.nome_grade1)
                .HasColumnType("varchar(100)");

            builder.Property(e => e.timestamp)
                .HasColumnType("bigint");

            builder.Property(e => e.portal)
                .HasColumnType("int");
        }
    }

    public class B2CConsultaGrade1RawMap : IEntityTypeConfiguration<B2CConsultaGrade1>
    {
        public void Configure(EntityTypeBuilder<B2CConsultaGrade1> builder)
        {
            builder.ToTable("B2CConsultaGrade1", "untreated");

            builder.HasKey(e => e.id);

            builder.Property(e => e.id)
                .HasColumnType("int")
                .ValueGeneratedOnAdd();

            builder.Property(e => e.lastupdateon)
                .HasProviderColumnType(LogicalColumnType.DateTime);

            builder.Property(e => e.codigo_grade1)
                .HasColumnType("int");

            builder.Property(e => e.nome_grade1)
                .HasColumnType("varchar(100)");

            builder.Property(e => e.timestamp)
                .HasColumnType("bigint");

            builder.Property(e => e.portal)
                .HasColumnType("int");
        }
    }
}
