using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using Domain.LinxMicrovix.Outbound.WebService.Entites.LinxCommerce;

namespace Infrastructure.LinxMicrovix.Outbound.WebService.Data.Mappings.LinxCommerce
{
    public class B2CConsultaVendedoresTrustedMap : IEntityTypeConfiguration<B2CConsultaVendedores>
    {
        public void Configure(EntityTypeBuilder<B2CConsultaVendedores> builder)
        {
            throw new NotImplementedException();
        }
    }

    public class B2CConsultaVendedoresRawMap : IEntityTypeConfiguration<B2CConsultaVendedores>
    {
        public void Configure(EntityTypeBuilder<B2CConsultaVendedores> builder)
        {
            throw new NotImplementedException();
        }
    }
}
