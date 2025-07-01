using Domain.Stone.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Stone.Data.Mappings
{
    public class StonePickupAddressMap : IEntityTypeConfiguration<PickupAddress>
    {
        public void Configure(EntityTypeBuilder<PickupAddress> builder)
        {
            throw new NotImplementedException();
        }
    }
}
