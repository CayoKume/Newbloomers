using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.IntegrationsCore.Data.Mappings
{
    public class TypesMap : IEntityTypeConfiguration<Domain.IntegrationsCore.Entities.Auditing.Type>
    {
        public void Configure(EntityTypeBuilder<Domain.IntegrationsCore.Entities.Auditing.Type> builder)
        {
            throw new NotImplementedException();
        }
    }
}
