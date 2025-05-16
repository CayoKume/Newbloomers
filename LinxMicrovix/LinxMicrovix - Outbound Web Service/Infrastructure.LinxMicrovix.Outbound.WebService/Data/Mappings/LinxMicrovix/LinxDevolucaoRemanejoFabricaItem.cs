using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using Domain.LinxMicrovix.Outbound.WebService.Entites.LinxMicrovix;
using Infrastructure.LinxMicrovix.Outbound.WebService.Data.Extensions;
using Domain.LinxMicrovix.Outbound.WebService.Enums;

namespace Infrastructure.LinxMicrovix.Outbound.WebService.Data.Mappings.LinxMicrovix
{
    public class LinxDevolucaoRemanejoFabricaItemMap : IEntityTypeConfiguration<LinxDevolucaoRemanejoFabricaItem>
    {
        public void Configure(EntityTypeBuilder<LinxDevolucaoRemanejoFabricaItem> builder)
        {
            builder.ToTable("LinxDevolucaoRemanejoFabricaItem", "linx_microvix_erp");

            builder.HasKey(e => e.id_devolucao_remanejo_fabrica_item);

            builder.Property(e => e.lastupdateon)
                .HasProviderColumnType(LogicalColumnType.DateTime);

            builder.Property(e => e.id_devolucao_remanejo_fabrica_item)
                .HasColumnType("int");

            builder.Property(e => e.id_devolucao_remanejo_fabrica)
                .HasColumnType("int");

            builder.Property(e => e.codigoproduto)
                .HasColumnType("bigint");

            builder.Property(e => e.codigo_produto_franqueadora)
                .HasColumnType("varchar(50)");

            builder.Property(e => e.quantidade)
                .HasColumnType("int");

            builder.Property(e => e.codebar)
                .HasColumnType("varchar(20)");

            builder.Property(e => e.serial)
                .HasColumnType("varchar(50)");

            builder.Property(e => e.timestamp)
                .HasColumnType("bigint");
        }
    }

    public class LinxDevolucaoRemanejoFabricaItemRawMap : IEntityTypeConfiguration<LinxDevolucaoRemanejoFabricaItem>
    {
        public void Configure(EntityTypeBuilder<LinxDevolucaoRemanejoFabricaItem> builder)
        {
            builder.ToTable("LinxDevolucaoRemanejoFabricaItem", "untreated");

            builder.HasKey(e => e.id);

            builder.Property(e => e.id)
                .HasColumnType("int")
                .ValueGeneratedOnAdd();

            builder.Property(e => e.lastupdateon)
                .HasProviderColumnType(LogicalColumnType.DateTime);

            builder.Property(e => e.id_devolucao_remanejo_fabrica_item)
                .HasColumnType("int");

            builder.Property(e => e.id_devolucao_remanejo_fabrica)
                .HasColumnType("int");

            builder.Property(e => e.codigoproduto)
                .HasColumnType("bigint");

            builder.Property(e => e.codigo_produto_franqueadora)
                .HasColumnType("varchar(50)");

            builder.Property(e => e.quantidade)
                .HasColumnType("int");

            builder.Property(e => e.codebar)
                .HasColumnType("varchar(20)");

            builder.Property(e => e.serial)
                .HasColumnType("varchar(50)");

            builder.Property(e => e.timestamp)
                .HasColumnType("bigint");
        }
    }
}
