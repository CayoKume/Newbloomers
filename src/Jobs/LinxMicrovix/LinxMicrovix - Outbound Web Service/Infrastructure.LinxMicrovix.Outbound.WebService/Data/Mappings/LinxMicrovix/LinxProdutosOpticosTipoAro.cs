using Infrastructure.Core.Data.Schemas;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using Domain.LinxMicrovix.Outbound.WebService.Models.LinxMicrovix;
using Infrastructure.Core.Data.Extensions;
using Domain.Core.Enums;

namespace Infrastructure.LinxMicrovix.Outbound.WebService.Data.Mappings.LinxMicrovix
{
    public class LinxProdutosOpticosTipoAroMap : IEntityTypeConfiguration<LinxProdutosOpticosTipoAro>
    {
        public void Configure(EntityTypeBuilder<LinxProdutosOpticosTipoAro> builder)
        {
            var schema = SchemaContext.GetSchema(typeof(LinxProdutosOpticosTipoAro));

            builder.ToTable("LinxProdutosOpticosTipoAro");

            if (schema == "linx_microvix_erp")
            {
                builder.HasKey(e => e.id_tipo_aro);
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

            builder.Property(e => e.id_tipo_aro)
                .HasColumnType("int");

            builder.Property(e => e.tipo_aro)
                .HasColumnType("varchar(100)");

            builder.Property(e => e.timestamp)
                .HasColumnType("bigint");
        }
    }
}
