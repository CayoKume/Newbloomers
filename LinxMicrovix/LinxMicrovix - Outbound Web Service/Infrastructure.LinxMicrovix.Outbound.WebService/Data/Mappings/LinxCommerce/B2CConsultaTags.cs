using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using Domain.LinxMicrovix.Outbound.WebService.Entites.LinxCommerce;

namespace Infrastructure.LinxMicrovix.Outbound.WebService.Data.Mappings.LinxCommerce
{
    public class B2CConsultaTagsTrustedMap : IEntityTypeConfiguration<B2CConsultaTags>
    {
        public void Configure(EntityTypeBuilder<B2CConsultaTags> builder)
        {
            throw new NotImplementedException();
        }
    }

    public class B2CConsultaTagsRawMap : IEntityTypeConfiguration<B2CConsultaTags>
    {
        public void Configure(EntityTypeBuilder<B2CConsultaTags> builder)
        {
            throw new NotImplementedException();
        }
    }
}
