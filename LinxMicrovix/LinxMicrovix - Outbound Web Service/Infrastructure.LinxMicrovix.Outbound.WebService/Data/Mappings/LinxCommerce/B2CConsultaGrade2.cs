using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using Domain.LinxMicrovix.Outbound.WebService.Entites.LinxCommerce;
using Domain.LinxMicrovix.Outbound.WebService.Enums;
using Infrastructure.LinxMicrovix.Outbound.WebService.Data.Extensions;

namespace Infrastructure.LinxMicrovix.Outbound.WebService.Data.Mappings.LinxCommerce
{
    public class B2CConsultaGrade2Map : IEntityTypeConfiguration<B2CConsultaGrade2>
    {
        public void Configure(EntityTypeBuilder<B2CConsultaGrade2> builder)
        {
            builder.ToTable("B2CConsultaGrade2", "linx_microvix_commerce");

            builder.HasKey(e => e.codigo_grade2);

            builder.Property(e => e.lastupdateon)
                .HasProviderColumnType(LogicalColumnType.DateTime);

            builder.Property(e => e.codigo_grade2)
                .HasColumnType("int");

            builder.Property(e => e.nome_grade2)
                .HasColumnType("varchar(100)");

            builder.Property(e => e.timestamp)
                .HasColumnType("bigint");

            builder.Property(e => e.portal)
                .HasColumnType("int");
        }
    }
}
