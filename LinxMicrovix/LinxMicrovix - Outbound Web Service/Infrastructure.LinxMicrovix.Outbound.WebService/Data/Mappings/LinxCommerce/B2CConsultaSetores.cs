using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using Domain.LinxMicrovix.Outbound.WebService.Entites.LinxCommerce;

namespace Infrastructure.LinxMicrovix.Outbound.WebService.Data.Mappings.LinxCommerce
{
    public class B2CConsultaSetoresTrustedMap : IEntityTypeConfiguration<B2CConsultaSetores>
    {
        public void Configure(EntityTypeBuilder<B2CConsultaSetores> builder)
        {
            throw new NotImplementedException();
        }
    }

    public class B2CConsultaSetoresRawMap : IEntityTypeConfiguration<B2CConsultaSetores>
    {
        public void Configure(EntityTypeBuilder<B2CConsultaSetores> builder)
        {
            throw new NotImplementedException();
        }
    }
}
