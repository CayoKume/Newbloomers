using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using Domain.LinxMicrovix.Outbound.WebService.Entites.LinxCommerce;

namespace Infrastructure.LinxMicrovix.Outbound.WebService.Data.Mappings.LinxCommerce
{
    public class B2CConsultaProdutosImagensTrustedMap : IEntityTypeConfiguration<B2CConsultaProdutosImagens>
    {
        public void Configure(EntityTypeBuilder<B2CConsultaProdutosImagens> builder)
        {
            throw new NotImplementedException();
        }
    }

    public class B2CConsultaProdutosImagensRawMap : IEntityTypeConfiguration<B2CConsultaProdutosImagens>
    {
        public void Configure(EntityTypeBuilder<B2CConsultaProdutosImagens> builder)
        {
            throw new NotImplementedException();
        }
    }
}
