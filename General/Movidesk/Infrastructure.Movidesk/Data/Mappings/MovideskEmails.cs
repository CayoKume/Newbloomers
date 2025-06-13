using Domain.IntegrationsCore.Enums;
using Domain.Movidesk.Entities;
using Infrastructure.IntegrationsCore.Data.Extensions;
using Infrastructure.IntegrationsCore.Data.Schemas;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Movidesk.Data.Mappings
{
    public class MovideskEmailsMap : IEntityTypeConfiguration<Email>
    {
        public void Configure(EntityTypeBuilder<Email> builder)
        {
            var schema = SchemaContext.GetSchema(typeof(Email));

            builder.ToTable("MovideskEmails");

            builder.HasKey(x => x.id);

            builder
                .Property(x => x.id)
                .HasColumnType("int")
                .ValueGeneratedOnAdd();

            builder
                .Property(x => x.emailType)
                .HasColumnType("varchar(60)");

            builder
                .Property(x => x.email)
                .HasColumnType("varchar(50)");

            builder
                .Property(x => x.isDefault)
                .HasProviderColumnType(EnumTableColumnType.Bool);
        }
    }
}
