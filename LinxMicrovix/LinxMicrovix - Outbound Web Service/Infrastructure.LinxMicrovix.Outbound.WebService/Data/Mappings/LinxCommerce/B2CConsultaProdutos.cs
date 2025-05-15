using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using Domain.LinxMicrovix.Outbound.WebService.Entites.LinxCommerce;

namespace Infrastructure.LinxMicrovix.Outbound.WebService.Data.Mappings.LinxCommerce
{
    public class B2CConsultaProdutosTrustedMap : IEntityTypeConfiguration<B2CConsultaProdutos>
    {
        public void Configure(EntityTypeBuilder<B2CConsultaProdutos> builder)
        {
            throw new NotImplementedException();
        }
    }

    public class B2CConsultaProdutosRawMap : IEntityTypeConfiguration<B2CConsultaProdutos>
    {
        public void Configure(EntityTypeBuilder<B2CConsultaProdutos> builder)
        {
            throw new NotImplementedException();
        }
    }
}
