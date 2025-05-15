using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using Domain.LinxMicrovix.Outbound.WebService.Entites.LinxCommerce;

namespace Infrastructure.LinxMicrovix.Outbound.WebService.Data.Mappings.LinxCommerce
{
    public class B2CConsultaLinhasTrustedMap : IEntityTypeConfiguration<B2CConsultaLinhas>
    {
        public void Configure(EntityTypeBuilder<B2CConsultaLinhas> builder)
        {
            throw new NotImplementedException();
        }
    }

    public class B2CConsultaLinhasRawMap : IEntityTypeConfiguration<B2CConsultaLinhas>
    {
        public void Configure(EntityTypeBuilder<B2CConsultaLinhas> builder)
        {
            throw new NotImplementedException();
        }
    }
}
