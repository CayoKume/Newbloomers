using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using Domain.LinxMicrovix.Outbound.WebService.Entites.LinxCommerce;

namespace Infrastructure.LinxMicrovix.Outbound.WebService.Data.Mappings.LinxCommerce
{
    public class B2CConsultaFornecedoresTrustedMap : IEntityTypeConfiguration<B2CConsultaFornecedores>
    {
        public void Configure(EntityTypeBuilder<B2CConsultaFornecedores> builder)
        {
            throw new NotImplementedException();
        }
    }

    public class B2CConsultaFornecedoresRawMap : IEntityTypeConfiguration<B2CConsultaFornecedores>
    {
        public void Configure(EntityTypeBuilder<B2CConsultaFornecedores> builder)
        {
            throw new NotImplementedException();
        }
    }
}
