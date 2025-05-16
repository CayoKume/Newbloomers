using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using Domain.LinxMicrovix.Outbound.WebService.Entites.LinxCommerce;
using Domain.LinxMicrovix.Outbound.WebService.Enums;
using Infrastructure.LinxMicrovix.Outbound.WebService.Data.Extensions;

namespace Infrastructure.LinxMicrovix.Outbound.WebService.Data.Mappings.LinxCommerce
{
    public class B2CConsultaStatusMap : IEntityTypeConfiguration<B2CConsultaStatus>
    {
        public void Configure(EntityTypeBuilder<B2CConsultaStatus> builder)
        {
            builder.ToTable("B2CConsultaStatus", "linx_microvix_commerce");

            builder.HasKey(e => e.id_status);

            builder.Property(e => e.lastupdateon)
                .HasProviderColumnType(LogicalColumnType.DateTime);

            builder.Property(e => e.id_status)
                .HasColumnType("int");

            builder.Property(e => e.descricao_status)
                .HasColumnType("varchar(30)");

            builder.Property(e => e.timestamp)
                .HasColumnType("bigint");

            builder.Property(e => e.portal)
                .HasColumnType("int");
        }
    }

    public class B2CConsultaStatusRawMap : IEntityTypeConfiguration<B2CConsultaStatus>
    {
        public void Configure(EntityTypeBuilder<B2CConsultaStatus> builder)
        {
            builder.ToTable("B2CConsultaStatus", "untreated");

            builder.HasKey(e => e.id);

            builder.Property(e => e.id)
                .HasColumnType("int")
                .ValueGeneratedOnAdd();

            builder.Property(e => e.lastupdateon)
                .HasProviderColumnType(LogicalColumnType.DateTime);

            builder.Property(e => e.id_status)
                .HasColumnType("int");

            builder.Property(e => e.descricao_status)
                .HasColumnType("varchar(30)");

            builder.Property(e => e.timestamp)
                .HasColumnType("bigint");

            builder.Property(e => e.portal)
                .HasColumnType("int");
        }
    }
}
