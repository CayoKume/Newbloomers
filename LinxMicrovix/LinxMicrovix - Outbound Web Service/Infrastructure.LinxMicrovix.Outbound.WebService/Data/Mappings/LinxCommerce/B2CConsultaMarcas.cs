using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using Domain.LinxMicrovix.Outbound.WebService.Entites.LinxCommerce;

namespace Infrastructure.LinxMicrovix.Outbound.WebService.Data.Mappings.LinxCommerce
{
    public class B2CConsultaMarcasTrustedMap : IEntityTypeConfiguration<B2CConsultaMarcas>
    {
        public void Configure(EntityTypeBuilder<B2CConsultaMarcas> builder)
        {
            throw new NotImplementedException();
        }
    }

    public class B2CConsultaMarcasRawMap : IEntityTypeConfiguration<B2CConsultaMarcas>
    {
        public void Configure(EntityTypeBuilder<B2CConsultaMarcas> builder)
        {
            throw new NotImplementedException();
        }
    }
}
