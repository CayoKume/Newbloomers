using Infrastructure.Core.Data.Schemas;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using Domain.LinxMicrovix.Outbound.WebService.Models.LinxMicrovix;
using Infrastructure.Core.Data.Extensions;
using Domain.Core.Enums;

namespace Infrastructure.LinxMicrovix.Outbound.WebService.Data.Mappings.LinxMicrovix
{
    public class LinxDevolucaoRemanejoFabricaItemMap : IEntityTypeConfiguration<LinxDevolucaoRemanejoFabricaItem>
    {
        public void Configure(EntityTypeBuilder<LinxDevolucaoRemanejoFabricaItem> builder)
        {
            var schema = SchemaContext.GetSchema(typeof(LinxDevolucaoRemanejoFabricaItem));

            builder.ToTable("LinxDevolucaoRemanejoFabricaItem");

            if (schema == "linx_microvix_erp")
                builder.HasKey(e => new { e.id_devolucao_remanejo_fabrica_item });
            

            builder.Property(e => e.lastupdateon)
                .HasProviderColumnType(EnumTableColumnType.DateTime);

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
