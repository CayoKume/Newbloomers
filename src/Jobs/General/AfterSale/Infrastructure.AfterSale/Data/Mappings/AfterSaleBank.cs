using Domain.AfterSale.Entities;
using Infrastructure.Core.Data.Schemas;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.AfterSale.Data.Mappings
{
    public class AfterSaleBankMap : IEntityTypeConfiguration<Bank>
    {
        public void Configure(EntityTypeBuilder<Bank> builder)
        {
            var schema = SchemaContext.GetSchema(typeof(Bank));

            builder.ToTable("AfterSaleBanks");

            builder.HasKey(x => x.id);

            builder
                .Property(x => x.id)
                .HasColumnType("int")
                .ValueGeneratedNever();

            builder.Property(e => e.name)
                .HasColumnType("varchar(60)");

            builder.Property(e => e.description)
                .HasColumnType("varchar(60)");
        }
    }
}
