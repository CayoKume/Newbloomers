using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using Domain.LinxMicrovix.Outbound.WebService.Entites.LinxCommerce;

namespace Infrastructure.LinxMicrovix.Outbound.WebService.Data.Mappings.LinxCommerce
{
    public class B2CConsultaProdutosAssociadosTrustedMap : IEntityTypeConfiguration<B2CConsultaProdutosAssociados>
    {
        public void Configure(EntityTypeBuilder<B2CConsultaProdutosAssociados> builder)
        {
            throw new NotImplementedException();
        }
    }

    public class B2CConsultaProdutosAssociadosRawMap : IEntityTypeConfiguration<B2CConsultaProdutosAssociados>
    {
        public void Configure(EntityTypeBuilder<B2CConsultaProdutosAssociados> builder)
        {
            throw new NotImplementedException();
        }
    }
}
