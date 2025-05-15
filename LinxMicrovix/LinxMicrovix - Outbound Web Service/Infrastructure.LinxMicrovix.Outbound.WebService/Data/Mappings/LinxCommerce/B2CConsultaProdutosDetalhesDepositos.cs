using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using Domain.LinxMicrovix.Outbound.WebService.Entites.LinxCommerce;

namespace Infrastructure.LinxMicrovix.Outbound.WebService.Data.Mappings.LinxCommerce
{
    public class B2CConsultaProdutosDetalhesDepositosTrustedMap : IEntityTypeConfiguration<B2CConsultaProdutosDetalhesDepositos>
    {
        public void Configure(EntityTypeBuilder<B2CConsultaProdutosDetalhesDepositos> builder)
        {
            throw new NotImplementedException();
        }
    }

    public class B2CConsultaProdutosDetalhesDepositosRawMap : IEntityTypeConfiguration<B2CConsultaProdutosDetalhesDepositos>
    {
        public void Configure(EntityTypeBuilder<B2CConsultaProdutosDetalhesDepositos> builder)
        {
            throw new NotImplementedException();
        }
    }
}
