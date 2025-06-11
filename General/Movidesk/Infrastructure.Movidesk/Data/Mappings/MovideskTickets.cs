using Domain.Movidesk.Entities;
using Infrastructure.IntegrationsCore.Data.Schemas;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Movidesk.Data.Mappings
{
    public class MovideskTicketsMap : IEntityTypeConfiguration<Ticket>
    {
        public void Configure(EntityTypeBuilder<Ticket> builder)
        {
            var schema = SchemaContext.GetSchema(typeof(Ticket));

            builder.ToTable("MovideskTickets");

            builder.HasKey(x => x.id);

            builder
                .Property(x => x.id)
                .HasColumnType("int");
        }
    }
}
