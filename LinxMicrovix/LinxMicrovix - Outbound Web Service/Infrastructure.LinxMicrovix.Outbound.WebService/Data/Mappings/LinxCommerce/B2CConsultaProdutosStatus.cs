using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using Domain.LinxMicrovix.Outbound.WebService.Entites.LinxCommerce;

namespace Infrastructure.LinxMicrovix.Outbound.WebService.Data.Mappings.LinxCommerce
{
    public class B2CConsultaProdutosStatusTrustedMap : IEntityTypeConfiguration<B2CConsultaProdutosStatus>
    {
        public void Configure(EntityTypeBuilder<B2CConsultaProdutosStatus> builder)
        {
            throw new NotImplementedException();
        }
    }

    public class B2CConsultaProdutosStatusRawMap : IEntityTypeConfiguration<B2CConsultaProdutosStatus>
    {
        public void Configure(EntityTypeBuilder<B2CConsultaProdutosStatus> builder)
        {
            throw new NotImplementedException();
        }
    }
}
