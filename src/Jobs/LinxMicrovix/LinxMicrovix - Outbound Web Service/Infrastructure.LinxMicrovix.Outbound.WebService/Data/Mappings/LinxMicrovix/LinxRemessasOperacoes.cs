using Infrastructure.Core.Data.Schemas;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using Domain.LinxMicrovix.Outbound.WebService.Models.LinxMicrovix;
using Infrastructure.Core.Data.Extensions;
using Domain.Core.Enums;

namespace Infrastructure.LinxMicrovix.Outbound.WebService.Data.Mappings.LinxMicrovix
{
    public class LinxRemessasOperacoesMap : IEntityTypeConfiguration<LinxRemessasOperacoes>
    {
        public void Configure(EntityTypeBuilder<LinxRemessasOperacoes> builder)
        {
            var schema = SchemaContext.GetSchema(typeof(LinxRemessasOperacoes));

            builder.ToTable("LinxRemessasOperacoes");

            if (schema == "linx_microvix_erp")
                builder.HasKey(e => e.id_remessa_operacoes);
            

            builder.Property(e => e.lastupdateon)
                .HasProviderColumnType(EnumTableColumnType.DateTime);

            builder.Property(e => e.id_remessa_operacoes)
                .HasColumnType("int");

            builder.Property(e => e.portal)
                .HasColumnType("int");

            builder.Property(e => e.descricao)
                .HasColumnType("varchar(30)");

            builder.Property(e => e.timestamp)
                .HasColumnType("bigint");
        }
    }
}
