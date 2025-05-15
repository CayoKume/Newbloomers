using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using Domain.LinxMicrovix.Outbound.WebService.Entites.LinxCommerce;

namespace Infrastructure.LinxMicrovix.Outbound.WebService.Data.Mappings.LinxCommerce
{
    public class B2CConsultaPedidosPlanosTrustedMap : IEntityTypeConfiguration<B2CConsultaPedidosPlanos>
    {
        public void Configure(EntityTypeBuilder<B2CConsultaPedidosPlanos> builder)
        {
            throw new NotImplementedException();
        }
    }

    public class B2CConsultaPedidosPlanosRawMap : IEntityTypeConfiguration<B2CConsultaPedidosPlanos>
    {
        public void Configure(EntityTypeBuilder<B2CConsultaPedidosPlanos> builder)
        {
            throw new NotImplementedException();
        }
    }
}
