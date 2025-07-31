using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Core.Data.Mappings
{
    public class TypesMap : IEntityTypeConfiguration<Domain.Core.Entities.Auditing.Type>
    {
        public void Configure(EntityTypeBuilder<Domain.Core.Entities.Auditing.Type> builder)
        {
            throw new NotImplementedException();
        }
    }
}
