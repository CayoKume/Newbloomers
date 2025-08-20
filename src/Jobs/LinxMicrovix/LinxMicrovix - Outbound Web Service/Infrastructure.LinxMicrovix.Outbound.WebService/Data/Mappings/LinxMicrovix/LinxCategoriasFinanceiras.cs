using Infrastructure.Core.Data.Schemas;
using Microsoft.EntityFrameworkCore;
using Domain.LinxMicrovix.Outbound.WebService.Models.LinxMicrovix;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Infrastructure.Core.Data.Extensions;
using Domain.Core.Enums;

namespace Infrastructure.LinxMicrovix.Outbound.WebService.Data.Mappings.LinxMicrovix
{
    public class LinxCategoriasFinanceirasMap : IEntityTypeConfiguration<LinxCategoriasFinanceiras>
    {
        public void Configure(EntityTypeBuilder<LinxCategoriasFinanceiras> builder)
        {
            var schema = SchemaContext.GetSchema(typeof(LinxCategoriasFinanceiras));

            builder.ToTable("LinxCategoriasFinanceiras");

            if (schema == "linx_microvix_erp")
            {
                builder.HasKey(e => new { e.id_categorias_financeiras });
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

            builder.Property(e => e.id_categorias_financeiras)
                .HasColumnType("int");

            builder.Property(e => e.descricao)
                .HasColumnType("varchar(50)");

            builder.Property(e => e.ativo)
                .HasProviderColumnType(EnumTableColumnType.Bool);

            builder.Property(e => e.historico)
                .HasColumnType("bigint");

            builder.Property(e => e.timestamp)
                .HasColumnType("bigint");
        }
    }
}
