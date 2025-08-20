using Infrastructure.Core.Data.Schemas;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using Domain.LinxMicrovix.Outbound.WebService.Models.LinxMicrovix;
using Infrastructure.Core.Data.Extensions;
using Domain.Core.Enums;

namespace Infrastructure.LinxMicrovix.Outbound.WebService.Data.Mappings.LinxMicrovix
{
    public class LinxDevolucaoRemanejoFabricaTipoMap : IEntityTypeConfiguration<LinxDevolucaoRemanejoFabricaTipo>
    {
        public void Configure(EntityTypeBuilder<LinxDevolucaoRemanejoFabricaTipo> builder)
        {
            var schema = SchemaContext.GetSchema(typeof(LinxDevolucaoRemanejoFabricaTipo));

            builder.ToTable("LinxDevolucaoRemanejoFabricaTipo");

            if (schema == "linx_microvix_erp")
            {
                builder.HasKey(e => e.id_devolucao_remanejo_fabrica_tipo);
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

            builder.Property(e => e.id_devolucao_remanejo_fabrica_tipo)
                .HasColumnType("int");

            builder.Property(e => e.descricao)
                .HasColumnType("varchar(100)");

            builder.Property(e => e.timestamp)
                .HasColumnType("bigint");
        }
    }
}
