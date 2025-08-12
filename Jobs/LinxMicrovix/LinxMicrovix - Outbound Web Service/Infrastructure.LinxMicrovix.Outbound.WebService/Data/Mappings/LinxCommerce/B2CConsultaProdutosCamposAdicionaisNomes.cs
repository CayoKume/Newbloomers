using Infrastructure.Core.Data.Schemas;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using Domain.LinxMicrovix.Outbound.WebService.Models.LinxCommerce;
using Infrastructure.Core.Data.Extensions;

using Domain.Core.Enums;

namespace Infrastructure.LinxMicrovix.Outbound.WebService.Data.Mappings.LinxCommerce
{
    public class B2CConsultaProdutosCamposAdicionaisNomesMap : IEntityTypeConfiguration<B2CConsultaProdutosCamposAdicionaisNomes>
    {
        public void Configure(EntityTypeBuilder<B2CConsultaProdutosCamposAdicionaisNomes> builder)
        {
            var schema = SchemaContext.GetSchema(typeof(B2CConsultaProdutosCamposAdicionaisNomes));

            builder.ToTable("B2CConsultaProdutosCamposAdicionaisNomes");

            if (schema == "linx_microvix_commerce")
                builder.HasKey(e => e.id_campo);
            

            builder.Property(e => e.lastupdateon)
                .HasProviderColumnType(EnumTableColumnType.DateTime);

            builder.Property(e => e.id_campo)
                .HasColumnType("int");

            builder.Property(e => e.ordem)
                .HasProviderColumnType(EnumTableColumnType.TinyInt);

            builder.Property(e => e.legenda)
                .HasColumnType("varchar(30)");

            builder.Property(e => e.tipo)
                .HasColumnType("char(1)");

            builder.Property(e => e.timestamp)
                .HasColumnType("bigint");

            builder.Property(e => e.portal)
                .HasColumnType("int");
        }
    }
}
