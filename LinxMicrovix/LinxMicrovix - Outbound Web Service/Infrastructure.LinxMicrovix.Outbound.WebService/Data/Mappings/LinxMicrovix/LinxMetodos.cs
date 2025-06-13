using Infrastructure.IntegrationsCore.Data.Schemas;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using Domain.LinxMicrovix.Outbound.WebService.Entities.LinxMicrovix;
using Infrastructure.IntegrationsCore.Data.Extensions;
using Domain.IntegrationsCore.Enums;

namespace Infrastructure.LinxMicrovix.Outbound.WebService.Data.Mappings.LinxMicrovix
{
    public class LinxMetodosMap : IEntityTypeConfiguration<LinxMetodos>
    {
        public void Configure(EntityTypeBuilder<LinxMetodos> builder)
        {
            var schema = SchemaContext.GetSchema(typeof(LinxMetodos));

            builder.ToTable("LinxMetodos");

            builder.HasKey(e => e.methodID);

            builder.Property(e => e.lastupdateon)
                .HasProviderColumnType(EnumTableColumnType.DateTime);

            builder.Property(e => e.methodID)
                .HasColumnType("int")
                .ValueGeneratedOnAdd();

            builder.Property(e => e.Retorno)
                .HasProviderColumnType(EnumTableColumnType.Varchar_Max);
        }
    }
}
