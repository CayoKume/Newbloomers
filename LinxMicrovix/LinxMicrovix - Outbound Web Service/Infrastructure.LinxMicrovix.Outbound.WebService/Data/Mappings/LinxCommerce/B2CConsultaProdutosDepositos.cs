using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using Domain.LinxMicrovix.Outbound.WebService.Entites.LinxCommerce;

namespace Infrastructure.LinxMicrovix.Outbound.WebService.Data.Mappings.LinxCommerce
{
    public class B2CConsultaProdutosDepositosTrustedMap : IEntityTypeConfiguration<B2CConsultaProdutosDepositos>
    {
        public void Configure(EntityTypeBuilder<B2CConsultaProdutosDepositos> builder)
        {
            throw new NotImplementedException();
        }
    }

    public class B2CConsultaProdutosDepositosRawMap : IEntityTypeConfiguration<B2CConsultaProdutosDepositos>
    {
        public void Configure(EntityTypeBuilder<B2CConsultaProdutosDepositos> builder)
        {
            throw new NotImplementedException();
        }
    }
}
