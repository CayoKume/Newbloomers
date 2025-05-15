using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using Domain.LinxMicrovix.Outbound.WebService.Entites.LinxMicrovix;

namespace Infrastructure.LinxMicrovix.Outbound.WebService.Data.Mappings.LinxMicrovix
{
    public class LinxReducoesZTrustedMap : IEntityTypeConfiguration<LinxReducoesZ>
    {
        public void Configure(EntityTypeBuilder<LinxReducoesZ> builder)
        {
            throw new NotImplementedException();
        }
    }

    public class LinxReducoesZRawMap : IEntityTypeConfiguration<LinxReducoesZ>
    {
        public void Configure(EntityTypeBuilder<LinxReducoesZ> builder)
        {
            throw new NotImplementedException();
        }
    }
}
