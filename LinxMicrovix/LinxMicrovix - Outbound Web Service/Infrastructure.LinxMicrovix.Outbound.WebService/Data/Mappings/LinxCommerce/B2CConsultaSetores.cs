using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using Domain.LinxMicrovix.Outbound.WebService.Entites.LinxCommerce;
using Domain.LinxMicrovix.Outbound.WebService.Enums;
using Infrastructure.LinxMicrovix.Outbound.WebService.Data.Extensions;

namespace Infrastructure.LinxMicrovix.Outbound.WebService.Data.Mappings.LinxCommerce
{
    public class B2CConsultaSetoresTrustedMap : IEntityTypeConfiguration<B2CConsultaSetores>
    {
        public void Configure(EntityTypeBuilder<B2CConsultaSetores> builder)
        {
            builder.ToTable("B2CConsultaSetores", "linx_microvix_commerce");

            builder.HasKey(e => e.codigo_setor);

            builder.Property(e => e.lastupdateon)
                .HasProviderColumnType(LogicalColumnType.DateTime);

            builder.Property(e => e.codigo_setor)
                .HasColumnType("int");

            builder.Property(e => e.nome_setor)
                .HasColumnType("varchar(100)");

            builder.Property(e => e.timestamp)
                .HasColumnType("bigint");

            builder.Property(e => e.portal)
                .HasColumnType("int");
        }
    }

    public class B2CConsultaSetoresRawMap : IEntityTypeConfiguration<B2CConsultaSetores>
    {
        public void Configure(EntityTypeBuilder<B2CConsultaSetores> builder)
        {
            builder.ToTable("B2CConsultaSetores", "untreated");

            builder.HasKey(e => e.id);

            builder.Property(e => e.id)
                .HasColumnType("int")
                .ValueGeneratedOnAdd();

            builder.Property(e => e.lastupdateon)
                .HasProviderColumnType(LogicalColumnType.DateTime);

            builder.Property(e => e.codigo_setor)
                .HasColumnType("int");

            builder.Property(e => e.nome_setor)
                .HasColumnType("varchar(100)");

            builder.Property(e => e.timestamp)
                .HasColumnType("bigint");

            builder.Property(e => e.portal)
                .HasColumnType("int");
        }
    }
}
