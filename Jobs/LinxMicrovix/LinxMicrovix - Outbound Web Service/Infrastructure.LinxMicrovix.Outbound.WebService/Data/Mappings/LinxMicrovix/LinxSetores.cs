using Infrastructure.Core.Data.Schemas;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using Domain.LinxMicrovix.Outbound.WebService.Models.LinxMicrovix;
using Infrastructure.Core.Data.Extensions;
using Domain.Core.Enums;

namespace Infrastructure.LinxMicrovix.Outbound.WebService.Data.Mappings.LinxMicrovix
{
    public class LinxSetoresMap : IEntityTypeConfiguration<LinxSetores>
    {
        public void Configure(EntityTypeBuilder<LinxSetores> builder)
        {
            var schema = SchemaContext.GetSchema(typeof(LinxSetores));

            builder.ToTable("LinxSetores");

            if (schema == "linx_microvix_erp")
            {
                builder.HasKey(e => e.id_setor);
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

            builder.Property(e => e.id_setor)
                .HasColumnType("int");

            builder.Property(e => e.desc_setor)
                .HasColumnType("varchar(30)");

            builder.Property(e => e.timestamp)
                .HasColumnType("bigint");

            builder.Property(e => e.codigo_integracao_ws)
                .HasColumnType("varchar(50)");

            builder.Property(e => e.ativo)
                .HasProviderColumnType(EnumTableColumnType.Bool);
        }
    }
}
