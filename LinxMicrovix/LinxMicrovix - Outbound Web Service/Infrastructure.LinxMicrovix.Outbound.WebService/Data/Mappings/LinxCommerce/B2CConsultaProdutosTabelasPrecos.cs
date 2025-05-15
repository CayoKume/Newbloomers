using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using Domain.LinxMicrovix.Outbound.WebService.Entites.LinxCommerce;

namespace Infrastructure.LinxMicrovix.Outbound.WebService.Data.Mappings.LinxCommerce
{
    public class B2CConsultaProdutosTabelasPrecosTrustedMap : IEntityTypeConfiguration<B2CConsultaProdutosTabelasPrecos>
    {
        public void Configure(EntityTypeBuilder<B2CConsultaProdutosTabelasPrecos> builder)
        {
            throw new NotImplementedException();
        }
    }

    public class B2CConsultaProdutosTabelasPrecosRawMap : IEntityTypeConfiguration<B2CConsultaProdutosTabelasPrecos>
    {
        public void Configure(EntityTypeBuilder<B2CConsultaProdutosTabelasPrecos> builder)
        {
            throw new NotImplementedException();
        }
    }
}
