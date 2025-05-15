using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using Domain.LinxMicrovix.Outbound.WebService.Entites.LinxCommerce;

namespace Infrastructure.LinxMicrovix.Outbound.WebService.Data.Mappings.LinxCommerce
{
    public class B2CConsultaProdutosDetalhesTrustedMap : IEntityTypeConfiguration<B2CConsultaProdutosDetalhes>
    {
        public void Configure(EntityTypeBuilder<B2CConsultaProdutosDetalhes> builder)
        {
            throw new NotImplementedException();
        }
    }

    public class B2CConsultaProdutosDetalhesRawMap : IEntityTypeConfiguration<B2CConsultaProdutosDetalhes>
    {
        public void Configure(EntityTypeBuilder<B2CConsultaProdutosDetalhes> builder)
        {
            throw new NotImplementedException();
        }
    }
}
