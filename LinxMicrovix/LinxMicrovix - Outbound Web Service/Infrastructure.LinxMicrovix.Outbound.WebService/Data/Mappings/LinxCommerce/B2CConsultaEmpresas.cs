using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using Domain.LinxMicrovix.Outbound.WebService.Entites.LinxCommerce;

namespace Infrastructure.LinxMicrovix.Outbound.WebService.Data.Mappings.LinxCommerce
{
    public class B2CConsultaEmpresasTrustedMap : IEntityTypeConfiguration<B2CConsultaEmpresas>
    {
        public void Configure(EntityTypeBuilder<B2CConsultaEmpresas> builder)
        {
            throw new NotImplementedException();
        }
    }

    public class B2CConsultaEmpresasRawMap : IEntityTypeConfiguration<B2CConsultaEmpresas>
    {
        public void Configure(EntityTypeBuilder<B2CConsultaEmpresas> builder)
        {
            throw new NotImplementedException();
        }
    }
}
