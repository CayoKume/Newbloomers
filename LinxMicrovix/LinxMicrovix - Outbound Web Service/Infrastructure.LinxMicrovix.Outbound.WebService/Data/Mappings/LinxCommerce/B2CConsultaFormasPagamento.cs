using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using Domain.LinxMicrovix.Outbound.WebService.Entites.LinxCommerce;

namespace Infrastructure.LinxMicrovix.Outbound.WebService.Data.Mappings.LinxCommerce
{
    public class B2CConsultaFormasPagamentoTrustedMap : IEntityTypeConfiguration<B2CConsultaFormasPagamento>
    {
        public void Configure(EntityTypeBuilder<B2CConsultaFormasPagamento> builder)
        {
            throw new NotImplementedException();
        }
    }

    public class B2CConsultaFormasPagamentoRawMap : IEntityTypeConfiguration<B2CConsultaFormasPagamento>
    {
        public void Configure(EntityTypeBuilder<B2CConsultaFormasPagamento> builder)
        {
            throw new NotImplementedException();
        }
    }
}
