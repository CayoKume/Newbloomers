using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using Domain.LinxMicrovix.Outbound.WebService.Entites.LinxCommerce;

namespace Infrastructure.LinxMicrovix.Outbound.WebService.Data.Mappings.LinxCommerce
{
    public class B2CConsultaProdutosCamposAdicionaisNomesTrustedMap : IEntityTypeConfiguration<B2CConsultaProdutosCamposAdicionaisNomes>
    {
        public void Configure(EntityTypeBuilder<B2CConsultaProdutosCamposAdicionaisNomes> builder)
        {
            throw new NotImplementedException();
        }
    }

    public class B2CConsultaProdutosCamposAdicionaisNomesRawMap : IEntityTypeConfiguration<B2CConsultaProdutosCamposAdicionaisNomes>
    {
        public void Configure(EntityTypeBuilder<B2CConsultaProdutosCamposAdicionaisNomes> builder)
        {
            throw new NotImplementedException();
        }
    }
}
