using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using Domain.LinxMicrovix.Outbound.WebService.Entites.LinxCommerce;

namespace Infrastructure.LinxMicrovix.Outbound.WebService.Data.Mappings.LinxCommerce
{
    public class B2CConsultaClientesContatosTrustedMap : IEntityTypeConfiguration<B2CConsultaClientesContatos>
    {
        public void Configure(EntityTypeBuilder<B2CConsultaClientesContatos> builder)
        {
            throw new NotImplementedException();
        }
    }

    public class B2CConsultaClientesContatosRawMap : IEntityTypeConfiguration<B2CConsultaClientesContatos>
    {
        public void Configure(EntityTypeBuilder<B2CConsultaClientesContatos> builder)
        {
            throw new NotImplementedException();
        }
    }
}
