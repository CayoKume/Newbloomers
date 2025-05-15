using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using Domain.LinxMicrovix.Outbound.WebService.Entites.LinxCommerce;

namespace Infrastructure.LinxMicrovix.Outbound.WebService.Data.Mappings.LinxCommerce
{
    public class B2CConsultaFlagsTrustedMap : IEntityTypeConfiguration<B2CConsultaFlags>
    {
        public void Configure(EntityTypeBuilder<B2CConsultaFlags> builder)
        {
            throw new NotImplementedException();
        }
    }

    public class B2CConsultaFlagsRawMap : IEntityTypeConfiguration<B2CConsultaFlags>
    {
        public void Configure(EntityTypeBuilder<B2CConsultaFlags> builder)
        {
            throw new NotImplementedException();
        }
    }
}
