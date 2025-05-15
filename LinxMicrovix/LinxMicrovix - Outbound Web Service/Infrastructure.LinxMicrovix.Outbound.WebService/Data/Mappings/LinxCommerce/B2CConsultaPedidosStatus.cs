using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using Domain.LinxMicrovix.Outbound.WebService.Entites.LinxCommerce;

namespace Infrastructure.LinxMicrovix.Outbound.WebService.Data.Mappings.LinxCommerce
{
    public class B2CConsultaPedidosStatusTrustedMap : IEntityTypeConfiguration<B2CConsultaPedidosStatus>
    {
        public void Configure(EntityTypeBuilder<B2CConsultaPedidosStatus> builder)
        {
            throw new NotImplementedException();
        }
    }

    public class B2CConsultaPedidosStatusRawMap : IEntityTypeConfiguration<B2CConsultaPedidosStatus>
    {
        public void Configure(EntityTypeBuilder<B2CConsultaPedidosStatus> builder)
        {
            throw new NotImplementedException();
        }
    }
}
