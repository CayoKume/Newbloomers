using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using Domain.LinxMicrovix.Outbound.WebService.Entites.LinxCommerce;

namespace Infrastructure.LinxMicrovix.Outbound.WebService.Data.Mappings.LinxCommerce
{
    public class B2CConsultaEspessurasTrustedMap : IEntityTypeConfiguration<B2CConsultaEspessuras>
    {
        public void Configure(EntityTypeBuilder<B2CConsultaEspessuras> builder)
        {
            throw new NotImplementedException();
        }
    }

    public class B2CConsultaEspessurasRawMap : IEntityTypeConfiguration<B2CConsultaEspessuras>
    {
        public void Configure(EntityTypeBuilder<B2CConsultaEspessuras> builder)
        {
            throw new NotImplementedException();
        }
    }
}
