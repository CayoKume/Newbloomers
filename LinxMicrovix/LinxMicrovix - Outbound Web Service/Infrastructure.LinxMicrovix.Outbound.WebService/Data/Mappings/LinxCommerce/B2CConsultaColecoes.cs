using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using Domain.LinxMicrovix.Outbound.WebService.Entites.LinxCommerce;

namespace Infrastructure.LinxMicrovix.Outbound.WebService.Data.Mappings.LinxCommerce
{
    public class B2CConsultaColecoesTrustedMap : IEntityTypeConfiguration<B2CConsultaColecoes>
    {
        public void Configure(EntityTypeBuilder<B2CConsultaColecoes> builder)
        {
            throw new NotImplementedException();
        }
    }

    public class B2CConsultaColecoesRawMap : IEntityTypeConfiguration<B2CConsultaColecoes>
    {
        public void Configure(EntityTypeBuilder<B2CConsultaColecoes> builder)
        {
            throw new NotImplementedException();
        }
    }
}
