using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using Domain.LinxMicrovix.Outbound.WebService.Entites.LinxCommerce;

namespace Infrastructure.LinxMicrovix.Outbound.WebService.Data.Mappings.LinxCommerce
{
    public class B2CConsultaClientesTrustedMap : IEntityTypeConfiguration<B2CConsultaClientes>
    {
        public void Configure(EntityTypeBuilder<B2CConsultaClientes> builder)
        {
            throw new NotImplementedException();
        }
    }

    public class B2CConsultaClientesRawMap : IEntityTypeConfiguration<B2CConsultaClientes>
    {
        public void Configure(EntityTypeBuilder<B2CConsultaClientes> builder)
        {
            throw new NotImplementedException();
        }
    }
}
