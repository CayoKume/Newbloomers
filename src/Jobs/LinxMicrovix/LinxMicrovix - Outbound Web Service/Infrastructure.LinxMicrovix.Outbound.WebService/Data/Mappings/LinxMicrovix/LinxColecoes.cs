using Infrastructure.Core.Data.Schemas;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using Domain.LinxMicrovix.Outbound.WebService.Models.LinxMicrovix;
using Infrastructure.Core.Data.Extensions;
using Domain.Core.Enums;

namespace Infrastructure.LinxMicrovix.Outbound.WebService.Data.Mappings.LinxMicrovix
{
    public class LinxColecoesMap : IEntityTypeConfiguration<LinxColecoes>
    {
        public void Configure(EntityTypeBuilder<LinxColecoes> builder)
        {
            var schema = SchemaContext.GetSchema(typeof(LinxColecoes));

            builder.ToTable("LinxColecoes");

            if (schema == "linx_microvix_erp")
                builder.HasKey(e => e.id_colecao);
            

            builder.Property(e => e.lastupdateon)
                .HasProviderColumnType(EnumTableColumnType.DateTime);

            builder.Property(e => e.id_colecao)
                .HasColumnType("int");

            builder.Property(e => e.desc_colecao)
                .HasColumnType("varchar(50)");

            builder.Property(e => e.timestamp)
                .HasColumnType("bigint");

            builder.Property(e => e.codigo_integracao_ws)
                .HasColumnType("varchar(50)");
        }
    }
}
