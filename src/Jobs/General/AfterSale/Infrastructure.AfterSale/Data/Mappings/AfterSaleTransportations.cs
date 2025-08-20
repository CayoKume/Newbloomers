using Domain.AfterSale.Entities;
using Infrastructure.Core.Data.Schemas;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.AfterSale.Data.Mappings
{
    public class AfterSaleTransportationsMap : IEntityTypeConfiguration<Transportations>
    {
        public void Configure(EntityTypeBuilder<Transportations> builder)
        {
            var schema = SchemaContext.GetSchema(typeof(Transportations));

            builder.ToTable("AfterSaleTransportations");

            builder.HasKey(x => x.id);

            builder
                .Property(x => x.id)
                .HasColumnType("int")
                .ValueGeneratedOnAdd();

            builder.Property(e => e.description)
                .HasColumnType("varchar(60)");
        }
    }
}
