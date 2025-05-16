using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using Domain.LinxMicrovix.Outbound.WebService.Entites.LinxCommerce;
using Domain.LinxMicrovix.Outbound.WebService.Enums;
using Infrastructure.LinxMicrovix.Outbound.WebService.Data.Extensions;

namespace Infrastructure.LinxMicrovix.Outbound.WebService.Data.Mappings.LinxCommerce
{
    public class B2CConsultaProdutosDetalhesDepositosTrustedMap : IEntityTypeConfiguration<B2CConsultaProdutosDetalhesDepositos>
    {
        public void Configure(EntityTypeBuilder<B2CConsultaProdutosDetalhesDepositos> builder)
        {
            builder.ToTable("B2CConsultaProdutosDetalhesDepositos", "linx_microvix_commerce");

            builder.HasKey(e => e.id_deposito);

            builder.Property(e => e.lastupdateon)
                .HasProviderColumnType(LogicalColumnType.DateTime);

            builder.Property(e => e.codigoproduto)
                .HasColumnType("bigint");

            builder.Property(e => e.empresa)
                .HasColumnType("int");

            builder.Property(e => e.id_deposito)
                .HasColumnType("int");

            builder.Property(e => e.saldo)
                .HasColumnType("decimal(10,2)");

            builder.Property(e => e.timestamp)
                .HasColumnType("bigint");

            builder.Property(e => e.portal)
                .HasColumnType("int");

            builder.Property(e => e.deposito)
                .HasColumnType("int");

            builder.Property(e => e.tempo_preparacao_estoque)
                .HasColumnType("smallint");
        }
    }

    public class B2CConsultaProdutosDetalhesDepositosRawMap : IEntityTypeConfiguration<B2CConsultaProdutosDetalhesDepositos>
    {
        public void Configure(EntityTypeBuilder<B2CConsultaProdutosDetalhesDepositos> builder)
        {
            builder.ToTable("B2CConsultaProdutosDetalhesDepositos", "untreated");

            builder.HasKey(e => e.id);

            builder.Property(e => e.id)
                .HasColumnType("int")
                .ValueGeneratedOnAdd();

            builder.Property(e => e.lastupdateon)
                .HasProviderColumnType(LogicalColumnType.DateTime);

            builder.Property(e => e.codigoproduto)
                .HasColumnType("bigint");

            builder.Property(e => e.empresa)
                .HasColumnType("int");

            builder.Property(e => e.id_deposito)
                .HasColumnType("int");

            builder.Property(e => e.saldo)
                .HasColumnType("decimal(10,2)");

            builder.Property(e => e.timestamp)
                .HasColumnType("bigint");

            builder.Property(e => e.portal)
                .HasColumnType("int");

            builder.Property(e => e.deposito)
                .HasColumnType("int");

            builder.Property(e => e.tempo_preparacao_estoque)
                .HasColumnType("smallint");
        }
    }
}
