using Domain.Stone.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Stone.Data.Mappings
{
    public class StoneDeliveryOptionsMap : IEntityTypeConfiguration<DeliveryOptions>
    {
        public void Configure(EntityTypeBuilder<DeliveryOptions> builder)
        {
            throw new NotImplementedException();
        }
    }
}
