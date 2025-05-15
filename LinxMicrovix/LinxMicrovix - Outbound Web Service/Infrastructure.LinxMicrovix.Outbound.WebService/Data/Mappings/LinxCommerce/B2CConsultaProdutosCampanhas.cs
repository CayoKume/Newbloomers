using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using Domain.LinxMicrovix.Outbound.WebService.Entites.LinxCommerce;

namespace Infrastructure.LinxMicrovix.Outbound.WebService.Data.Mappings.LinxCommerce
{
    public class B2CConsultaProdutosCampanhasTrustedMap : IEntityTypeConfiguration<B2CConsultaProdutosCampanhas>
    {
        public void Configure(EntityTypeBuilder<B2CConsultaProdutosCampanhas> builder)
        {
            throw new NotImplementedException();
        }
    }

    public class B2CConsultaProdutosCampanhasRawMap : IEntityTypeConfiguration<B2CConsultaProdutosCampanhas>
    {
        public void Configure(EntityTypeBuilder<B2CConsultaProdutosCampanhas> builder)
        {
            throw new NotImplementedException();
        }
    }
}
