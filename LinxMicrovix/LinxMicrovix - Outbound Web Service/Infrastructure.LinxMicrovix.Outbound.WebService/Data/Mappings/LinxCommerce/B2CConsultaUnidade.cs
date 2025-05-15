using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using Domain.LinxMicrovix.Outbound.WebService.Entites.LinxCommerce;

namespace Infrastructure.LinxMicrovix.Outbound.WebService.Data.Mappings.LinxCommerce
{
    public class B2CConsultaUnidadeTrustedMap : IEntityTypeConfiguration<B2CConsultaUnidade>
    {
        public void Configure(EntityTypeBuilder<B2CConsultaUnidade> builder)
        {
            throw new NotImplementedException();
        }
    }

    public class B2CConsultaUnidadeRawMap : IEntityTypeConfiguration<B2CConsultaUnidade>
    {
        public void Configure(EntityTypeBuilder<B2CConsultaUnidade> builder)
        {
            throw new NotImplementedException();
        }
    }

}
