using Infrastructure.Core.Data.Schemas;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using Domain.LinxMicrovix.Outbound.WebService.Models.LinxMicrovix;
using Infrastructure.Core.Data.Extensions;
using Domain.Core.Enums;

namespace Infrastructure.LinxMicrovix.Outbound.WebService.Data.Mappings.LinxMicrovix
{
    public class LinxProdutosCodBarMap : IEntityTypeConfiguration<LinxProdutosCodBar>
    {
        public void Configure(EntityTypeBuilder<LinxProdutosCodBar> builder)
        {
            var schema = SchemaContext.GetSchema(typeof(LinxProdutosCodBar));

            builder.ToTable("LinxProdutosCodBar");

            if (schema == "linx_microvix_erp")
            {
                builder.HasKey(e => e.cod_produto);
                builder.Ignore(x => x.id);
            }
            else
            {
                builder.HasKey(x => x.id);

                builder.Property(e => e.id)
                    .HasColumnType("int")
                    .ValueGeneratedOnAdd();
            }

            builder.Property(e => e.lastupdateon)
                .HasProviderColumnType(EnumTableColumnType.DateTime);

            builder.Property(e => e.portal)
                .HasColumnType("int");

            builder.Property(e => e.cod_produto)
                .HasColumnType("bigint");

            builder.Property(e => e.cod_barra)
                .HasColumnType("varchar(20)");

            builder.Property(e => e.timestamp)
                .HasColumnType("bigint");
        }
    }
}
