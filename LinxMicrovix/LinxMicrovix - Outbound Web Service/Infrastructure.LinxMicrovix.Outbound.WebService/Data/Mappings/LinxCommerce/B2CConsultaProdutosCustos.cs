using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using Domain.LinxMicrovix.Outbound.WebService.Entites.LinxCommerce;

namespace Infrastructure.LinxMicrovix.Outbound.WebService.Data.Mappings.LinxCommerce
{
    public class B2CConsultaProdutosCustosTrustedMap : IEntityTypeConfiguration<B2CConsultaProdutosCustos>
    {
        public void Configure(EntityTypeBuilder<B2CConsultaProdutosCustos> builder)
        {
            throw new NotImplementedException();
        }
    }

    public class B2CConsultaProdutosCustosRawMap : IEntityTypeConfiguration<B2CConsultaProdutosCustos>
    {
        public void Configure(EntityTypeBuilder<B2CConsultaProdutosCustos> builder)
        {
            throw new NotImplementedException();
        }
    }
}
