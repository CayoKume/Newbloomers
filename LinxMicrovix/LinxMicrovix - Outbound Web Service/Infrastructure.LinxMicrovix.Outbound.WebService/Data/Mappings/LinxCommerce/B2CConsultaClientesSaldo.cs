using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using Domain.LinxMicrovix.Outbound.WebService.Entites.LinxCommerce;

namespace Infrastructure.LinxMicrovix.Outbound.WebService.Data.Mappings.LinxCommerce
{
    public class B2CConsultaClientesSaldoTrustedMap : IEntityTypeConfiguration<B2CConsultaClientesSaldo>
    {
        public void Configure(EntityTypeBuilder<B2CConsultaClientesSaldo> builder)
        {
            throw new NotImplementedException();
        }
    }

    public class B2CConsultaClientesSaldoRawMap : IEntityTypeConfiguration<B2CConsultaClientesSaldo>
    {
        public void Configure(EntityTypeBuilder<B2CConsultaClientesSaldo> builder)
        {
            throw new NotImplementedException();
        }
    }
}
