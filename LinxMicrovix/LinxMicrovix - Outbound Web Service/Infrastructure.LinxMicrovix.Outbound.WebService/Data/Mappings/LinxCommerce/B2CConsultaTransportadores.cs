using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using Domain.LinxMicrovix.Outbound.WebService.Entites.LinxCommerce;

namespace Infrastructure.LinxMicrovix.Outbound.WebService.Data.Mappings.LinxCommerce
{
    public class B2CConsultaTransportadoresTrustedMap : IEntityTypeConfiguration<B2CConsultaTransportadores>
    {
        public void Configure(EntityTypeBuilder<B2CConsultaTransportadores> builder)
        {
            throw new NotImplementedException();
        }
    }

    public class B2CConsultaTransportadoresRawMap : IEntityTypeConfiguration<B2CConsultaTransportadores>
    {
        public void Configure(EntityTypeBuilder<B2CConsultaTransportadores> builder)
        {
            throw new NotImplementedException();
        }
    }
}
