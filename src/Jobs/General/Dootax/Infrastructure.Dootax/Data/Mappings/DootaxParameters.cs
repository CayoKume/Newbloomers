using Domain.Dootax.Entities;
using Domain.Core.Enums;
using Infrastructure.Core.Data.Extensions;
using Infrastructure.Core.Data.Schemas;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Dootax.Data.Mappings
{
    public class DootaxParametersMap : IEntityTypeConfiguration<Parameters>
    {
        public void Configure(EntityTypeBuilder<Parameters> builder)
        {
            var schema = SchemaContext.GetSchema(typeof(Parameters));

            builder.ToTable("Parametros_Dootax");

            builder.HasKey(c => c.token);

            builder
                .Property(c => c.user)
                .HasColumnName("usuario")
                .HasColumnType("varchar(50)");

            builder
                .Property(c => c.token)
                .HasColumnName("token")
                .HasProviderColumnType(EnumTableColumnType.UUID);

            builder.HasData(
                new Parameters { token = new Guid("87e2c224-fb6a-48c2-82da-8c57584b3169"), user = "newbloomers", environment = "prod" },
                new Parameters { token = new Guid("78391c28-0d30-4d8d-bbcd-735006165ecf"), user = "newbloomers", environment = "homolog" }
            );
        }
    }
}
