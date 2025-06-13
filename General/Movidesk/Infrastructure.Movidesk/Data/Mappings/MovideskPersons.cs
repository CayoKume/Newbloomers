using Domain.IntegrationsCore.Enums;
using Domain.Movidesk.Entities;
using Infrastructure.IntegrationsCore.Data.Extensions;
using Infrastructure.IntegrationsCore.Data.Schemas;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Movidesk.Data.Mappings
{
    public class MovideskPersonsMap : IEntityTypeConfiguration<Person>
    {
        public void Configure(EntityTypeBuilder<Person> builder)
        {
            var schema = SchemaContext.GetSchema(typeof(Person));

            builder.ToTable("MovideskPersons");

            builder.HasKey(x => x.id);

            if (schema != "untreated")
            {
                builder
                    .HasMany(x => x.addresses)
                    .WithOne()
                    //.HasForeignKey(y => y.id)
                    .OnDelete(DeleteBehavior.NoAction);

                builder
                    .HasMany(x => x.contacts)
                    .WithOne()
                    //.HasForeignKey(y => y.id)
                    .OnDelete(DeleteBehavior.NoAction);

                builder
                    .HasMany(x => x.emails)
                    .WithOne()
                    //.HasForeignKey(y => y.id)
                    .OnDelete(DeleteBehavior.NoAction);

                builder
                    .HasMany(x => x.relationships)
                    .WithOne()
                    //.HasForeignKey(y => y.id)
                    .OnDelete(DeleteBehavior.NoAction);

                builder
                    .HasMany(x => x.customFieldValues)
                    .WithOne()
                    //.HasForeignKey(y => y.customFieldId)
                    .OnDelete(DeleteBehavior.NoAction);
            }
            else
            {
                builder.Ignore(x => x.addresses);
                builder.Ignore(x => x.contacts);
                builder.Ignore(x => x.emails);
                builder.Ignore(x => x.relationships);
                builder.Ignore(x => x.customFieldValues);
            }

            builder
                .Property(x => x.id)
                .HasColumnType("varchar(60)");

            builder
                .Property(x => x.personType)
                .HasColumnType("int");

            builder
                .Property(x => x.profileType)
                .HasColumnType("int");

            builder
                .Property(x => x.codeReferenceAdditional)
                .HasColumnType("varchar(60)");

            builder
                .Property(x => x.accessProfile)
                .HasColumnType("varchar(60)");

            builder
                .Property(x => x.businessName)
                .HasColumnType("varchar(60)");

            builder
                .Property(x => x.businessBranch)
                .HasColumnType("varchar(60)");

            builder
                .Property(x => x.corporateName)
                .HasColumnType("varchar(60)");

            builder
                .Property(x => x.cpfCnpj)
                .HasColumnType("varchar(14)");

            builder
                .Property(x => x.userName)
                .HasColumnType("varchar(60)");

            builder
                .Property(x => x.accountEmail)
                .HasColumnType("varchar(60)");

            builder
                .Property(x => x.role)
                .HasColumnType("varchar(60)");

            builder
                .Property(x => x.bossId)
                .HasColumnType("varchar(60)");

            builder
                .Property(x => x.bossName)
                .HasColumnType("varchar(60)");

            builder
                .Property(x => x.classification)
                .HasColumnType("varchar(60)");

            builder
                .Property(x => x.cultureId)
                .HasColumnType("varchar(60)");

            builder
                .Property(x => x.timeZoneId)
                .HasColumnType("varchar(60)");

            builder
                .Property(x => x.createdBy)
                .HasColumnType("varchar(60)");

            builder
                .Property(x => x.changedBy)
                .HasColumnType("varchar(60)");

            builder
                .Property(x => x.observations)
                .HasColumnType("varchar(60)");

            builder
                .Property(x => x.authenticateOn)
                .HasColumnType("varchar(60)");

            builder
                .Property(x => x.teams)
                .HasColumnType("varchar(60)");

            builder
                .Property(x => x.isActive)
                .HasProviderColumnType(EnumTableColumnType.Bool);

            builder
                .Property(x => x.createdDate)
                .HasProviderColumnType(EnumTableColumnType.DateTime);

            builder
                .Property(x => x.changedDate)
                .HasProviderColumnType(EnumTableColumnType.DateTime);
        }
    }
}