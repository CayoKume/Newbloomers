using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using Domain.LinxMicrovix.Outbound.WebService.Entites.LinxCommerce;

namespace Infrastructure.LinxMicrovix.Outbound.WebService.Data.Mappings.LinxCommerce
{
    public class B2CConsultaProdutosFlagsTrustedMap : IEntityTypeConfiguration<B2CConsultaProdutosFlags>
    {
        public void Configure(EntityTypeBuilder<B2CConsultaProdutosFlags> builder)
        {
            throw new NotImplementedException();
        }
    }

    public class B2CConsultaProdutosFlagsRawMap : IEntityTypeConfiguration<B2CConsultaProdutosFlags>
    {
        public void Configure(EntityTypeBuilder<B2CConsultaProdutosFlags> builder)
        {
            throw new NotImplementedException();
        }
    }

}
