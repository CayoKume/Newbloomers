using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using Domain.LinxMicrovix.Outbound.WebService.Entites.LinxCommerce;

namespace Infrastructure.LinxMicrovix.Outbound.WebService.Data.Mappings.LinxCommerce
{
    public class B2CConsultaTipoEncomendaTrustedMap : IEntityTypeConfiguration<B2CConsultaTipoEncomenda>
    {
        public void Configure(EntityTypeBuilder<B2CConsultaTipoEncomenda> builder)
        {
            throw new NotImplementedException();
        }
    }

    public class B2CConsultaTipoEncomendaRawMap : IEntityTypeConfiguration<B2CConsultaTipoEncomenda>
    {
        public void Configure(EntityTypeBuilder<B2CConsultaTipoEncomenda> builder)
        {
            throw new NotImplementedException();
        }
    }
}
