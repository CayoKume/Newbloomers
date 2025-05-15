using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using Domain.LinxMicrovix.Outbound.WebService.Entites.LinxCommerce;

namespace Infrastructure.LinxMicrovix.Outbound.WebService.Data.Mappings.LinxCommerce
{
    public class B2CConsultaCNPJsChaveTrustedMap : IEntityTypeConfiguration<B2CConsultaCNPJsChave>
    {
        public void Configure(EntityTypeBuilder<B2CConsultaCNPJsChave> builder)
        {
            throw new NotImplementedException();
        }
    }

    public class B2CConsultaCNPJsChaveRawMap : IEntityTypeConfiguration<B2CConsultaCNPJsChave>
    {
        public void Configure(EntityTypeBuilder<B2CConsultaCNPJsChave> builder)
        {
            throw new NotImplementedException();
        }
    }
}
