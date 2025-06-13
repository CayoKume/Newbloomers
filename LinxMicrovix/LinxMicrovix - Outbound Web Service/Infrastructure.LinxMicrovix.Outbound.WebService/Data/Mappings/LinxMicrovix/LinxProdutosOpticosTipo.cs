using Infrastructure.IntegrationsCore.Data.Schemas;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using Domain.LinxMicrovix.Outbound.WebService.Entities.LinxMicrovix;
using Infrastructure.IntegrationsCore.Data.Extensions;
using Domain.IntegrationsCore.Enums;

namespace Infrastructure.LinxMicrovix.Outbound.WebService.Data.Mappings.LinxMicrovix
{
    public class LinxProdutosOpticosTipoMap : IEntityTypeConfiguration<LinxProdutosOpticosTipo>
    {
        public void Configure(EntityTypeBuilder<LinxProdutosOpticosTipo> builder)
        {
            var schema = SchemaContext.GetSchema(typeof(LinxProdutosOpticosTipo));

            builder.ToTable("LinxProdutosOpticosTipo");

            if (schema == "linx_microvix_erp")
            {
                builder.HasKey(e => e.id_produtos_opticos_tipo);
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

            builder.Property(e => e.id_produtos_opticos_tipo)
                .HasColumnType("int");

            builder.Property(e => e.tipo)
                .HasColumnType("varchar(100)");

            builder.Property(e => e.timestamp)
                .HasColumnType("bigint");
        }
    }
}
