using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using Domain.LinxMicrovix.Outbound.WebService.Entites.LinxCommerce;

namespace Infrastructure.LinxMicrovix.Outbound.WebService.Data.Mappings.LinxCommerce
{
    public class B2CConsultaPedidosTrustedMap : IEntityTypeConfiguration<B2CConsultaPedidos>
    {
        public void Configure(EntityTypeBuilder<B2CConsultaPedidos> builder)
        {
            throw new NotImplementedException();
        }
    }

    public class B2CConsultaPedidosRawMap : IEntityTypeConfiguration<B2CConsultaPedidos>
    {
        public void Configure(EntityTypeBuilder<B2CConsultaPedidos> builder)
        {
            throw new NotImplementedException();
        }
    }
}
