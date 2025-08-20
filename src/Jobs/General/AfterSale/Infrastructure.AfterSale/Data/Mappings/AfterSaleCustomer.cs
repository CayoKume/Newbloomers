using Domain.AfterSale.Entities;
using Infrastructure.Core.Data.Schemas;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.AfterSale.Data.Mappings
{
    public class AfterSaleCustomerMap : IEntityTypeConfiguration<Customer>
    {
        public void Configure(EntityTypeBuilder<Customer> builder)
        {
            var schema = SchemaContext.GetSchema(typeof(Customer));

            builder.ToTable("AfterSaleCustomers");

            builder.HasKey(x => x.id);

            if (schema != "untreated")
            {
                builder
                    .HasOne(x => x.address)
                    .WithMany()
                    .HasForeignKey(o => o.address_id)
                    .OnDelete(DeleteBehavior.NoAction);

                builder
                    .HasOne(x => x.address)
                    .WithMany()
                    .HasForeignKey(o => o.shipping_address_id)
                    .OnDelete(DeleteBehavior.NoAction); 
            }
            else
            {
                builder.Ignore(x => x.address);
                builder.Ignore(x => x.shipping_address);
            }

            builder
                .Property(x => x.id)
                .HasColumnType("int")
                .ValueGeneratedNever();

            builder
                .Property(x => x.address_id)
                .HasColumnType("int");

            builder.Property(e => e.contact_email)
                .HasColumnType("varchar(50)");

            builder.Property(e => e.document)
                .HasColumnType("varchar(14)");

            builder.Property(e => e.email)
                .HasColumnType("varchar(50)");

            builder.Property(e => e.first_name)
                .HasColumnType("varchar(60)");

            builder.Property(e => e.last_name)
                .HasColumnType("varchar(60)");

            builder.Property(e => e.phone)
                .HasColumnType("varchar(30)");

            builder
                .Property(x => x.shipping_address_id)
                .HasColumnType("int");
        }
    }
}
