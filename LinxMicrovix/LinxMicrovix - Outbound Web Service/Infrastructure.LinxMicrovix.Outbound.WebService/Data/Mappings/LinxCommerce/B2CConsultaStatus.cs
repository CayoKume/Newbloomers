using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using Domain.LinxMicrovix.Outbound.WebService.Entites.LinxCommerce;

namespace Infrastructure.LinxMicrovix.Outbound.WebService.Data.Mappings.LinxCommerce
{
    public class B2CConsultaStatusTrustedMap : IEntityTypeConfiguration<B2CConsultaStatus>
    {
        public void Configure(EntityTypeBuilder<B2CConsultaStatus> builder)
        {
            throw new NotImplementedException();
        }
    }

    public class B2CConsultaStatusRawMap : IEntityTypeConfiguration<B2CConsultaStatus>
    {
        public void Configure(EntityTypeBuilder<B2CConsultaStatus> builder)
        {
            throw new NotImplementedException();
        }
    }
}
