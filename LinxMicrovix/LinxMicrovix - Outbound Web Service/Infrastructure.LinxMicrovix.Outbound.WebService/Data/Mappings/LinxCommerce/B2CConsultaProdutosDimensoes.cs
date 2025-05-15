using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using Domain.LinxMicrovix.Outbound.WebService.Entites.LinxCommerce;

namespace Infrastructure.LinxMicrovix.Outbound.WebService.Data.Mappings.LinxCommerce
{
    public class B2CConsultaProdutosDimensoesTrustedMap : IEntityTypeConfiguration<B2CConsultaProdutosDimensoes>
    {
        public void Configure(EntityTypeBuilder<B2CConsultaProdutosDimensoes> builder)
        {
            throw new NotImplementedException();
        }
    }

    public class B2CConsultaProdutosDimensoesRawMap : IEntityTypeConfiguration<B2CConsultaProdutosDimensoes>
    {
        public void Configure(EntityTypeBuilder<B2CConsultaProdutosDimensoes> builder)
        {
            throw new NotImplementedException();
        }
    }
}
