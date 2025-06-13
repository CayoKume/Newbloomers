using Domain.IntegrationsCore.Enums;
using Domain.Movidesk.Entities;
using Infrastructure.IntegrationsCore.Data.Extensions;
using Infrastructure.IntegrationsCore.Data.Schemas;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Movidesk.Data.Mappings
{
    public class MovideskParametersMap : IEntityTypeConfiguration<Parameters>
    {
        public void Configure(EntityTypeBuilder<Parameters> builder)
        {
            var schema = SchemaContext.GetSchema(typeof(Parameters));

            builder.ToTable("Parametros_Movidesk");

            builder.HasKey(c => c.Token);

            builder
                .Property(c => c.Token)
                .HasProviderColumnType(EnumTableColumnType.UUID);

            builder.HasData(
                new Parameters { Token = new Guid("7b034c69-b176-46f7-bc71-d6a290f18b73") }
            );
        }
    }
}
