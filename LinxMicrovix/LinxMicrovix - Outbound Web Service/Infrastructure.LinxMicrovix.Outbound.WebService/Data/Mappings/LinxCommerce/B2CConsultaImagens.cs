using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using Domain.LinxMicrovix.Outbound.WebService.Entites.LinxCommerce;

namespace Infrastructure.LinxMicrovix.Outbound.WebService.Data.Mappings.LinxCommerce
{
    public class B2CConsultaImagensTrustedMap : IEntityTypeConfiguration<B2CConsultaImagens>
    {
        public void Configure(EntityTypeBuilder<B2CConsultaImagens> builder)
        {
            throw new NotImplementedException();
        }
    }

    public class B2CConsultaImagensRawMap : IEntityTypeConfiguration<B2CConsultaImagens>
    {
        public void Configure(EntityTypeBuilder<B2CConsultaImagens> builder)
        {
            throw new NotImplementedException();
        }
    }

}
