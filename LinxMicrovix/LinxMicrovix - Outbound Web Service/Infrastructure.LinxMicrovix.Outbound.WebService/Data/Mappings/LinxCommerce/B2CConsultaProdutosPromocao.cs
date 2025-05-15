using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using Domain.LinxMicrovix.Outbound.WebService.Entites.LinxCommerce;

namespace Infrastructure.LinxMicrovix.Outbound.WebService.Data.Mappings.LinxCommerce
{
    public class B2CConsultaProdutosPromocaoTrustedMap : IEntityTypeConfiguration<B2CConsultaProdutosPromocao>
    {
        public void Configure(EntityTypeBuilder<B2CConsultaProdutosPromocao> builder)
        {
            throw new NotImplementedException();
        }
    }

    public class B2CConsultaProdutosPromocaoRawMap : IEntityTypeConfiguration<B2CConsultaProdutosPromocao>
    {
        public void Configure(EntityTypeBuilder<B2CConsultaProdutosPromocao> builder)
        {
            throw new NotImplementedException();
        }
    }
}
