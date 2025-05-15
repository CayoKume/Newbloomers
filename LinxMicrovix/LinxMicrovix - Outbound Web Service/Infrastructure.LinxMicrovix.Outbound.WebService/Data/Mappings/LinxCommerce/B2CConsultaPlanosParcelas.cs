using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using Domain.LinxMicrovix.Outbound.WebService.Entites.LinxCommerce;

namespace Infrastructure.LinxMicrovix.Outbound.WebService.Data.Mappings.LinxCommerce
{
    public class B2CConsultaPlanosParcelasTrustedMap : IEntityTypeConfiguration<B2CConsultaPlanosParcelas>
    {
        public void Configure(EntityTypeBuilder<B2CConsultaPlanosParcelas> builder)
        {
            throw new NotImplementedException();
        }
    }

    public class B2CConsultaPlanosParcelasRawMap : IEntityTypeConfiguration<B2CConsultaPlanosParcelas>
    {
        public void Configure(EntityTypeBuilder<B2CConsultaPlanosParcelas> builder)
        {
            throw new NotImplementedException();
        }
    }
}
