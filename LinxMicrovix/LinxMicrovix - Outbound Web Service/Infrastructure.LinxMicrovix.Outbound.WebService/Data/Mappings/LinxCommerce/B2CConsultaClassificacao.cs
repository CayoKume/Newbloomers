using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using Domain.LinxMicrovix.Outbound.WebService.Entites.LinxCommerce;

namespace Infrastructure.LinxMicrovix.Outbound.WebService.Data.Mappings.LinxCommerce
{
    public class B2CConsultaClassificacaoTrustedMap : IEntityTypeConfiguration<B2CConsultaClassificacao>
    {
        public void Configure(EntityTypeBuilder<B2CConsultaClassificacao> builder)
        {
            throw new NotImplementedException();
        }
    }

    public class B2CConsultaClassificacaoRawMap : IEntityTypeConfiguration<B2CConsultaClassificacao>
    {
        public void Configure(EntityTypeBuilder<B2CConsultaClassificacao> builder)
        {
            throw new NotImplementedException();
        }
    }
}