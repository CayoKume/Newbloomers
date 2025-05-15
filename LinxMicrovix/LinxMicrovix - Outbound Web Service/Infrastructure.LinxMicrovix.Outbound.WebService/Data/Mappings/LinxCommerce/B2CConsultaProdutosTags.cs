using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using Domain.LinxMicrovix.Outbound.WebService.Entites.LinxCommerce;

namespace Infrastructure.LinxMicrovix.Outbound.WebService.Data.Mappings.LinxCommerce
{
    public class B2CConsultaProdutosTagsTrustedMap : IEntityTypeConfiguration<B2CConsultaProdutosTags>
    {
        public void Configure(EntityTypeBuilder<B2CConsultaProdutosTags> builder)
        {
            throw new NotImplementedException();
        }
    }

    public class B2CConsultaProdutosTagsRawMap : IEntityTypeConfiguration<B2CConsultaProdutosTags>
    {
        public void Configure(EntityTypeBuilder<B2CConsultaProdutosTags> builder)
        {
            throw new NotImplementedException();
        }
    }
}
