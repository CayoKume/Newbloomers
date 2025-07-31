using Domain.Stone.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Stone.Data.Mappings
{
    public class StonePlaceMap : IEntityTypeConfiguration<Place>
    {
        public void Configure(EntityTypeBuilder<Place> builder)
        {
            throw new NotImplementedException();
        }
    }
}
