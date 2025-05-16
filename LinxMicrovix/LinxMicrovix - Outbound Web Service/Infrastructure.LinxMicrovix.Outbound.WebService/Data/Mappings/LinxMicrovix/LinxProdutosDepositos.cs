using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using Domain.LinxMicrovix.Outbound.WebService.Entites.LinxMicrovix;
using Domain.LinxMicrovix.Outbound.WebService.Enums;
using Infrastructure.LinxMicrovix.Outbound.WebService.Data.Extensions;

namespace Infrastructure.LinxMicrovix.Outbound.WebService.Data.Mappings.LinxMicrovix
{
    public class LinxProdutosDepositosTrustedMap : IEntityTypeConfiguration<LinxProdutosDepositos>
    {
        public void Configure(EntityTypeBuilder<LinxProdutosDepositos> builder)
        {
            builder.ToTable("LinxProdutosDepositos", "linx_microvix_erp");

            builder.HasKey(e => e.cod_deposito);

            builder.Property(e => e.lastupdateon)
                .HasProviderColumnType(LogicalColumnType.DateTime);

            builder.Property(e => e.portal)
                .HasColumnType("int");

            builder.Property(e => e.cod_deposito)
                .HasColumnType("int");

            builder.Property(e => e.nome_deposito)
                .HasColumnType("varchar(50)");

            builder.Property(e => e.disponivel)
                .HasProviderColumnType(LogicalColumnType.Bool);

            builder.Property(e => e.disponivel_transferencia)
                .HasProviderColumnType(LogicalColumnType.Bool);

            builder.Property(e => e.timestamp)
                .HasColumnType("bigint");
        }
    }

    public class LinxProdutosDepositosRawMap : IEntityTypeConfiguration<LinxProdutosDepositos>
    {
        public void Configure(EntityTypeBuilder<LinxProdutosDepositos> builder)
        {
            builder.ToTable("LinxProdutosDepositos", "untreated");

            builder.HasKey(e => e.id);

            builder.Property(e => e.id)
                .HasColumnType("int")
                .ValueGeneratedOnAdd();

            builder.Property(e => e.lastupdateon)
                .HasProviderColumnType(LogicalColumnType.DateTime);

            builder.Property(e => e.portal)
                .HasColumnType("int");

            builder.Property(e => e.cod_deposito)
                .HasColumnType("int");

            builder.Property(e => e.nome_deposito)
                .HasColumnType("varchar(50)");

            builder.Property(e => e.disponivel)
                .HasProviderColumnType(LogicalColumnType.Bool);

            builder.Property(e => e.disponivel_transferencia)
                .HasProviderColumnType(LogicalColumnType.Bool);

            builder.Property(e => e.timestamp)
                .HasColumnType("bigint");
        }
    }

}
