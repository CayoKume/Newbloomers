using Infrastructure.IntegrationsCore.Data.Schemas;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using Domain.LinxMicrovix.Outbound.WebService.Models.LinxCommerce;
using Infrastructure.IntegrationsCore.Data.Extensions;

using Domain.IntegrationsCore.Enums;

namespace Infrastructure.LinxMicrovix.Outbound.WebService.Data.Mappings.LinxCommerce
{
    public class B2CConsultaProdutosCamposAdicionaisValoresMap : IEntityTypeConfiguration<B2CConsultaProdutosCamposAdicionaisValores>
    {
        public void Configure(EntityTypeBuilder<B2CConsultaProdutosCamposAdicionaisValores> builder)
        {
            var schema = SchemaContext.GetSchema(typeof(B2CConsultaProdutosCamposAdicionaisValores));

            builder.ToTable("B2CConsultaProdutosCamposAdicionaisValores");

            if (schema == "linx_microvix_commerce")
            {
                builder.HasKey(e => e.id_campo_valor);
                builder.Ignore(e => e.id);
            }
            else
            {
                builder.HasKey(e => e.id);

                builder.Property(e => e.id)
                    .HasColumnType("int")
                    .ValueGeneratedOnAdd();
            }

            builder.Property(e => e.lastupdateon)
                .HasProviderColumnType(EnumTableColumnType.DateTime);

            builder.Property(e => e.id_campo_valor)
                .HasColumnType("int");

            builder.Property(e => e.codigoproduto)
                .HasColumnType("bigint");

            builder.Property(e => e.id_campo_detalhe)
                .HasColumnType("int");

            builder.Property(e => e.timestamp)
                .HasColumnType("bigint");

            builder.Property(e => e.portal)
                .HasColumnType("int");
        }
    }
}
