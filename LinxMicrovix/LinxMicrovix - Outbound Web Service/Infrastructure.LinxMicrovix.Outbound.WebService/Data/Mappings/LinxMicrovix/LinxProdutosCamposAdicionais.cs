using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using Domain.LinxMicrovix.Outbound.WebService.Entites.LinxMicrovix;
using Domain.LinxMicrovix.Outbound.WebService.Enums;
using Infrastructure.LinxMicrovix.Outbound.WebService.Data.Extensions;


namespace Infrastructure.LinxMicrovix.Outbound.WebService.Data.Mappings.LinxMicrovix
{
    public class LinxProdutosCamposAdicionaisMap : IEntityTypeConfiguration<LinxProdutosCamposAdicionais>
    {
        

        

        public void Configure(EntityTypeBuilder<LinxProdutosCamposAdicionais> builder)
        {
            builder.ToTable("LinxProdutosCamposAdicionais");

            builder.HasKey(e => new { e.cod_produto, e.campo });

            builder.Property(e => e.lastupdateon)
                .HasProviderColumnType(LogicalColumnType.DateTime);

            builder.Property(e => e.portal)
                .HasColumnType("int");

            builder.Property(e => e.cod_produto)
                .HasColumnType("bigint");

            builder.Property(e => e.campo)
                .HasColumnType("varchar(30)");

            builder.Property(e => e.valor)
                .HasColumnType("varchar(30)");

            builder.Property(e => e.timestamp)
                .HasColumnType("bigint");
        }
    }
}
