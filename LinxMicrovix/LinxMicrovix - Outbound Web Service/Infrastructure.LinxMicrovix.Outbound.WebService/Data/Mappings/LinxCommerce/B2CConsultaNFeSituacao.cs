using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using Domain.LinxMicrovix.Outbound.WebService.Entites.LinxCommerce;

namespace Infrastructure.LinxMicrovix.Outbound.WebService.Data.Mappings.LinxCommerce
{
    public class B2CConsultaNFeSituacaoTrustedMap : IEntityTypeConfiguration<B2CConsultaNFeSituacao>
    {
        public void Configure(EntityTypeBuilder<B2CConsultaNFeSituacao> builder)
        {
            throw new NotImplementedException();
        }
    }

    public class B2CConsultaNFeSituacaoRawMap : IEntityTypeConfiguration<B2CConsultaNFeSituacao>
    {
        public void Configure(EntityTypeBuilder<B2CConsultaNFeSituacao> builder)
        {
            throw new NotImplementedException();
        }
    }
}
