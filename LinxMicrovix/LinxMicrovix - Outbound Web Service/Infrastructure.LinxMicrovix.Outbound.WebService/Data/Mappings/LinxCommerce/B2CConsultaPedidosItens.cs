using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using Domain.LinxMicrovix.Outbound.WebService.Entites.LinxCommerce;

namespace Infrastructure.LinxMicrovix.Outbound.WebService.Data.Mappings.LinxCommerce
{
    public class B2CConsultaPedidosItensTrustedMap : IEntityTypeConfiguration<B2CConsultaPedidosItens>
    {
        public void Configure(EntityTypeBuilder<B2CConsultaPedidosItens> builder)
        {
            throw new NotImplementedException();
        }
    }

    public class B2CConsultaPedidosItensRawMap : IEntityTypeConfiguration<B2CConsultaPedidosItens>
    {
        public void Configure(EntityTypeBuilder<B2CConsultaPedidosItens> builder)
        {
            throw new NotImplementedException();
        }
    }
}
