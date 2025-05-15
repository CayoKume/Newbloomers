using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using Domain.LinxMicrovix.Outbound.WebService.Entites.LinxCommerce;

namespace Infrastructure.LinxMicrovix.Outbound.WebService.Data.Mappings.LinxCommerce
{
    public class B2CConsultaProdutosCamposAdicionaisDetalhesTrustedMap : IEntityTypeConfiguration<B2CConsultaProdutosCamposAdicionaisDetalhes>
    {
        public void Configure(EntityTypeBuilder<B2CConsultaProdutosCamposAdicionaisDetalhes> builder)
        {
            throw new NotImplementedException();
        }
    }

    public class B2CConsultaProdutosCamposAdicionaisDetalhesRawMap : IEntityTypeConfiguration<B2CConsultaProdutosCamposAdicionaisDetalhes>
    {
        public void Configure(EntityTypeBuilder<B2CConsultaProdutosCamposAdicionaisDetalhes> builder)
        {
            throw new NotImplementedException();
        }
    }
}
