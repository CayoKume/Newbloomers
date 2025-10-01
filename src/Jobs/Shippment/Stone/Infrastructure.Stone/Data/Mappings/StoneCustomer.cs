using Domain.Core.Enums;
using Domain.Stone.Entities;
using Infrastructure.Core.Data.Schemas;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Stone.Data.Mappings
{
    //public class StoneCustomerMap : IEntityTypeConfiguration<Customer>
    //{
    //    public void Configure(EntityTypeBuilder<Customer> builder)
    //    {
    //        var schema = SchemaContext.GetSchema(typeof(Customer));

    //        builder.ToTable("StoneCustomers");

    //        builder.HasKey(x => x.id);

    //        builder
    //        .Property(x => x.id)
    //        .HasColumnType("int")
    //        .ValueGeneratedOnAdd();

    //        builder.Property(e => e.name)
    //            .HasColumnType("varchar(60)");

    //        builder.Property(e => e.phoneNumber)
    //            .HasColumnType("varchar(60)");

    //        builder.Property(e => e.document)
    //            .HasColumnType("varchar(60)");
    //    }
    //}
}
