using Domain.Core.Entities.Auditing;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Core.Data.Mappings
{
    public class LogsMap : IEntityTypeConfiguration<Log>
    {
        public void Configure(EntityTypeBuilder<Log> builder)
        {
            builder.ToTable("Logs");

            //builder.HasKey(e => e.IdParent);

            //builder.Property(e => e.IdParent)
            //    .HasColumnType("int");
        }
    }
}
