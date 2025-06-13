using Domain.IntegrationsCore.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.IntegrationsCore.Data.Mappings
{
    public class MessageLevelsMap : IEntityTypeConfiguration<MessageLevel>
    {
        public void Configure(EntityTypeBuilder<MessageLevel> builder)
        {
            throw new NotImplementedException();
        }
    }
}
