using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using Domain.LinxMicrovix.Outbound.WebService.Entites.LinxMicrovix;
using Domain.LinxMicrovix.Outbound.WebService.Enums;
using Infrastructure.LinxMicrovix.Outbound.WebService.Data.Extensions;

namespace Infrastructure.LinxMicrovix.Outbound.WebService.Data.Mappings.LinxMicrovix
{
    public class LinxOrdensServicoProdutosMap : IEntityTypeConfiguration<LinxOrdensServicoProdutos>
    {
        public void Configure(EntityTypeBuilder<LinxOrdensServicoProdutos> builder)
        {
            builder.ToTable("LinxOrdensServicoProdutos", "linx_microvix_erp");

            builder.HasKey(e => e.id_ordservprod);

            builder.Property(e => e.lastupdateon)
                .HasProviderColumnType(LogicalColumnType.DateTime);

            builder.Property(e => e.id_ordservprod)
                .HasColumnType("int");

            builder.Property(e => e.cod_produto_serv)
                .HasColumnType("bigint");

            builder.Property(e => e.numero_os)
                .HasColumnType("int");

            builder.Property(e => e.timestamp)
                .HasColumnType("bigint");
        }
    }

    public class LinxOrdensServicoProdutosRawMap : IEntityTypeConfiguration<LinxOrdensServicoProdutos>
    {
        public void Configure(EntityTypeBuilder<LinxOrdensServicoProdutos> builder)
        {
            builder.ToTable("LinxOrdensServicoProdutos", "untreated");

            builder.HasKey(e => e.id);

            builder.Property(e => e.id)
                .HasColumnType("int")
                .ValueGeneratedOnAdd();

            builder.Property(e => e.lastupdateon)
                .HasProviderColumnType(LogicalColumnType.DateTime);

            builder.Property(e => e.id_ordservprod)
                .HasColumnType("int");

            builder.Property(e => e.cod_produto_serv)
                .HasColumnType("bigint");

            builder.Property(e => e.numero_os)
                .HasColumnType("int");

            builder.Property(e => e.timestamp)
                .HasColumnType("bigint");
        }
    }
}
