using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using Domain.LinxMicrovix.Outbound.WebService.Entites.LinxCommerce;

namespace Infrastructure.LinxMicrovix.Outbound.WebService.Data.Mappings.LinxCommerce
{
    public class B2CConsultaTiposCobrancaFreteTrustedMap : IEntityTypeConfiguration<B2CConsultaTiposCobrancaFrete>
    {
        public void Configure(EntityTypeBuilder<B2CConsultaTiposCobrancaFrete> builder)
        {
            throw new NotImplementedException();
        }
    }

    public class B2CConsultaTiposCobrancaFreteRawMap : IEntityTypeConfiguration<B2CConsultaTiposCobrancaFrete>
    {
        public void Configure(EntityTypeBuilder<B2CConsultaTiposCobrancaFrete> builder)
        {
            throw new NotImplementedException();
        }
    }
}
