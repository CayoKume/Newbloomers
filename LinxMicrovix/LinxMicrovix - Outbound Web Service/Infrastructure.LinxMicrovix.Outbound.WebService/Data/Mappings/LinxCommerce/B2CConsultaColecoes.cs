using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using Domain.LinxMicrovix.Outbound.WebService.Entites.LinxCommerce;
using Domain.LinxMicrovix.Outbound.WebService.Enums;
using Infrastructure.LinxMicrovix.Outbound.WebService.Data.Extensions;

namespace Infrastructure.LinxMicrovix.Outbound.WebService.Data.Mappings.LinxCommerce
{
    public class B2CConsultaColecoesTrustedMap : IEntityTypeConfiguration<B2CConsultaColecoes>
    {
        public void Configure(EntityTypeBuilder<B2CConsultaColecoes> builder)
        {
            builder.ToTable("B2CConsultaColecoes", "linx_microvix_commerce");

            builder.HasKey(e => e.codigo_colecao);

            builder.Property(e => e.lastupdateon)
                .HasProviderColumnType(LogicalColumnType.DateTime);

            builder.Property(e => e.codigo_colecao)
                .HasColumnType("int");

            builder.Property(e => e.nome_colecao)
                .HasColumnType("varchar(100)");

            builder.Property(e => e.timestamp)
                .HasColumnType("bigint");

            builder.Property(e => e.marcas)
                .HasColumnType("varchar(250)");

            builder.Property(e => e.portal)
                .HasColumnType("int");
        }
    }

    public class B2CConsultaColecoesRawMap : IEntityTypeConfiguration<B2CConsultaColecoes>
    {
        public void Configure(EntityTypeBuilder<B2CConsultaColecoes> builder)
        {
            builder.ToTable("B2CConsultaColecoes", "untreated");

            builder.HasKey(e => e.id);

            builder.Property(e => e.id)
                .HasColumnType("int")
                .ValueGeneratedOnAdd();

            builder.Property(e => e.lastupdateon)
                .HasProviderColumnType(LogicalColumnType.DateTime);

            builder.Property(e => e.codigo_colecao)
                .HasColumnType("int");

            builder.Property(e => e.nome_colecao)
                .HasColumnType("varchar(100)");

            builder.Property(e => e.timestamp)
                .HasColumnType("bigint");

            builder.Property(e => e.marcas)
                .HasColumnType("varchar(250)");

            builder.Property(e => e.portal)
                .HasColumnType("int");
        }
    }
}
