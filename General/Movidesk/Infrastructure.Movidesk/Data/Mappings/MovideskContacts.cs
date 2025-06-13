using Domain.IntegrationsCore.Enums;
using Domain.Movidesk.Entities;
using Infrastructure.IntegrationsCore.Data.Extensions;
using Infrastructure.IntegrationsCore.Data.Schemas;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Movidesk.Data.Mappings
{
    public class MovideskContactsMap : IEntityTypeConfiguration<Contact>
    {
        public void Configure(EntityTypeBuilder<Contact> builder)
        {
            var schema = SchemaContext.GetSchema(typeof(Contact));

            builder.ToTable("MovideskContacts");

            builder.HasKey(x => x.id);

            builder
                .Property(x => x.id)
                .HasColumnType("int")
                .ValueGeneratedNever();

            builder
                .Property(x => x.contactType)
                .HasColumnType("varchar(60)");

            builder
                .Property(x => x.contact)
                .HasColumnType("varchar(50)");

            builder
                .Property(x => x.isDefault)
                .HasProviderColumnType(EnumTableColumnType.Bool);
        }
    }
}
