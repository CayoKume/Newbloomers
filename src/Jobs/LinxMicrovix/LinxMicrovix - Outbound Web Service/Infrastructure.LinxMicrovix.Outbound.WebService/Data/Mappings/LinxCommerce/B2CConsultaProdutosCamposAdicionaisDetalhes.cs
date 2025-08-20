using Infrastructure.Core.Data.Schemas;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using Domain.LinxMicrovix.Outbound.WebService.Models.LinxCommerce;
using Infrastructure.Core.Data.Extensions;

using Domain.Core.Enums;

namespace Infrastructure.LinxMicrovix.Outbound.WebService.Data.Mappings.LinxCommerce
{
    public class B2CConsultaProdutosCamposAdicionaisDetalhesMap : IEntityTypeConfiguration<B2CConsultaProdutosCamposAdicionaisDetalhes>
    {
        public void Configure(EntityTypeBuilder<B2CConsultaProdutosCamposAdicionaisDetalhes> builder)
        {
            var schema = SchemaContext.GetSchema(typeof(B2CConsultaProdutosCamposAdicionaisDetalhes));

            builder.ToTable("B2CConsultaProdutosCamposAdicionaisDetalhes");

            if (schema == "linx_microvix_commerce")
            {
                builder.HasKey(e => e.id_campo_detalhe);
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

            builder.Property(e => e.id_campo_detalhe)
                .HasColumnType("int");

            builder.Property(e => e.ordem)
                .HasColumnType("int");

            builder.Property(e => e.descricao)
                .HasColumnType("varchar(30)");

            builder.Property(e => e.id_campo)
                .HasColumnType("int");

            builder.Property(e => e.ativo)
                .HasProviderColumnType(EnumTableColumnType.Bool);

            builder.Property(e => e.timestamp)
                .HasColumnType("bigint");

            builder.Property(e => e.portal)
                .HasColumnType("int");
        }
    }
}
