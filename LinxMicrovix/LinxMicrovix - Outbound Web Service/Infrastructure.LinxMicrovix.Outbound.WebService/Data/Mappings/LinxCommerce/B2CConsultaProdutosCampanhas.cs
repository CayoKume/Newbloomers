using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using Domain.LinxMicrovix.Outbound.WebService.Entites.LinxCommerce;
using Domain.LinxMicrovix.Outbound.WebService.Enums;
using Infrastructure.LinxMicrovix.Outbound.WebService.Data.Extensions;

namespace Infrastructure.LinxMicrovix.Outbound.WebService.Data.Mappings.LinxCommerce
{
    public class B2CConsultaProdutosCampanhasTrustedMap : IEntityTypeConfiguration<B2CConsultaProdutosCampanhas>
    {
        public void Configure(EntityTypeBuilder<B2CConsultaProdutosCampanhas> builder)
        {
            builder.ToTable("B2CConsultaProdutosCampanhas", "linx_microvix_commerce");

            builder.HasKey(e => e.codigo_campanha);

            builder.Property(e => e.lastupdateon)
                .HasProviderColumnType(LogicalColumnType.DateTime);

            builder.Property(e => e.codigo_campanha)
                .HasColumnType("int");

            builder.Property(e => e.nome_campanha)
                .HasColumnType("varchar(60)");

            builder.Property(e => e.vigencia_inicio)
                .HasProviderColumnType(LogicalColumnType.DateTime);

            builder.Property(e => e.vigencia_fim)
                .HasProviderColumnType(LogicalColumnType.DateTime);

            builder.Property(e => e.observacao)
                .HasColumnType("varchar(MAX)");

            builder.Property(e => e.ativo)
                .HasProviderColumnType(LogicalColumnType.Bool);

            builder.Property(e => e.timestamp)
                .HasColumnType("bigint");

            builder.Property(e => e.portal)
                .HasColumnType("int");
        }
    }

    public class B2CConsultaProdutosCampanhasRawMap : IEntityTypeConfiguration<B2CConsultaProdutosCampanhas>
    {
        public void Configure(EntityTypeBuilder<B2CConsultaProdutosCampanhas> builder)
        {
            builder.ToTable("B2CConsultaProdutosCampanhas", "untreated");

            builder.HasKey(e => e.id);

            builder.Property(e => e.id)
                .HasColumnType("int")
                .ValueGeneratedOnAdd();

            builder.Property(e => e.lastupdateon)
                .HasProviderColumnType(LogicalColumnType.DateTime);

            builder.Property(e => e.codigo_campanha)
                .HasColumnType("int");

            builder.Property(e => e.nome_campanha)
                .HasColumnType("varchar(60)");

            builder.Property(e => e.vigencia_inicio)
                .HasProviderColumnType(LogicalColumnType.DateTime);

            builder.Property(e => e.vigencia_fim)
                .HasProviderColumnType(LogicalColumnType.DateTime);

            builder.Property(e => e.observacao)
                .HasColumnType("varchar(MAX)");

            builder.Property(e => e.ativo)
                .HasProviderColumnType(LogicalColumnType.Bool);

            builder.Property(e => e.timestamp)
                .HasColumnType("bigint");

            builder.Property(e => e.portal)
                .HasColumnType("int");
        }
    }
}
