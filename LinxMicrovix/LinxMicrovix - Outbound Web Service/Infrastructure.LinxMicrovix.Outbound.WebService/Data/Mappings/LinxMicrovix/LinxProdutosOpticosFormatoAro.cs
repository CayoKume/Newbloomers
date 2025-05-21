using Infrastructure.IntegrationsCore.Data.Schemas;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using Domain.LinxMicrovix.Outbound.WebService.Entites.LinxMicrovix;
using Domain.IntegrationsCore.Entities.Enums;
using Infrastructure.IntegrationsCore.Data.Extensions;

namespace Infrastructure.LinxMicrovix.Outbound.WebService.Data.Mappings.LinxMicrovix
{
    public class LinxProdutosOpticosFormatoAroMap : IEntityTypeConfiguration<LinxProdutosOpticosFormatoAro>
    {
        public void Configure(EntityTypeBuilder<LinxProdutosOpticosFormatoAro> builder)
        {
            var schema = SchemaContext.GetSchema(typeof(LinxProdutosOpticosFormatoAro));

            builder.ToTable("LinxProdutosOpticosFormatoAro");

            if (schema == "linx_microvix_erp")
            {
                builder.HasKey(e => e.id_formato_aro);
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

            builder.Property(e => e.id_formato_aro)
                .HasColumnType("int");

            builder.Property(e => e.codigo)
                .HasColumnType("varchar(16)");

            builder.Property(e => e.descricao)
                .HasColumnType("varchar(60)");

            builder.Property(e => e.timestamp)
                .HasColumnType("bigint");
        }
    }
}
