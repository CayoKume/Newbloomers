using Domain.Core.Entities.Auditing;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Core.Data.Mappings
{
    public class ServicesStatusMap : IEntityTypeConfiguration<ServicesStatus>
    {
        public void Configure(EntityTypeBuilder<ServicesStatus> builder)
        {
            throw new NotImplementedException();
        }
    }
}
