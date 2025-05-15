using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using Domain.LinxMicrovix.Outbound.WebService.Entites.LinxCommerce;

namespace Infrastructure.LinxMicrovix.Outbound.WebService.Data.Mappings.LinxCommerce
{
    public class B2CConsultaPlanosTrustedMap : IEntityTypeConfiguration<B2CConsultaPlanos>
    {
        public void Configure(EntityTypeBuilder<B2CConsultaPlanos> builder)
        {
            throw new NotImplementedException();
        }
    }

    public class B2CConsultaPlanosRawMap : IEntityTypeConfiguration<B2CConsultaPlanos>
    {
        public void Configure(EntityTypeBuilder<B2CConsultaPlanos> builder)
        {
            throw new NotImplementedException();
        }
    }
}
