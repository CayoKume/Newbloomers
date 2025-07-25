using Infrastructure.IntegrationsCore.Data.Schemas;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using Domain.LinxMicrovix.Outbound.WebService.Models.LinxMicrovix;
using Infrastructure.IntegrationsCore.Data.Extensions;
using Domain.IntegrationsCore.Enums;

namespace Infrastructure.LinxMicrovix.Outbound.WebService.Data.Mappings.LinxMicrovix
{
    public class LinxOrdensServicoProdutosMap : IEntityTypeConfiguration<LinxOrdensServicoProdutos>
    {
        public void Configure(EntityTypeBuilder<LinxOrdensServicoProdutos> builder)
        {
            var schema = SchemaContext.GetSchema(typeof(LinxOrdensServicoProdutos));

            builder.ToTable("LinxOrdensServicoProdutos");

            if (schema == "linx_microvix_erp")
            {
                builder.HasKey(e => e.id_ordservprod);
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
