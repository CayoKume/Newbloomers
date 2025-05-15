using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using Domain.LinxMicrovix.Outbound.WebService.Entites.LinxCommerce;

namespace Infrastructure.LinxMicrovix.Outbound.WebService.Data.Mappings.LinxCommerce
{
    public class B2CConsultaProdutosInformacoesTrustedMap : IEntityTypeConfiguration<B2CConsultaProdutosInformacoes>
    {
        public void Configure(EntityTypeBuilder<B2CConsultaProdutosInformacoes> builder)
        {
            throw new NotImplementedException();
        }
    }

    public class B2CConsultaProdutosInformacoesRawMap : IEntityTypeConfiguration<B2CConsultaProdutosInformacoes>
    {
        public void Configure(EntityTypeBuilder<B2CConsultaProdutosInformacoes> builder)
        {
            throw new NotImplementedException();
        }
    }
}
