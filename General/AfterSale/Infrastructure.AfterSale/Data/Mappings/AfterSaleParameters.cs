using Domain.AfterSale.Entities;
using Infrastructure.IntegrationsCore.Data.Schemas;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.AfterSale.Data.Mappings
{
    public class AfterSaleParametersMap : IEntityTypeConfiguration<Parameters>
    {
        public void Configure(EntityTypeBuilder<Parameters> builder)
        {
            var schema = SchemaContext.GetSchema(typeof(Parameters));

            builder.ToTable("Parametros_AfterSale");

            builder.HasKey(c => c.doc_company);

            builder
                .Property(c => c.doc_company)
                .HasColumnName("CNPJ_EMP");

            builder
                .Property(c => c.Token)
                .HasColumnName("TOKEN");

            builder.HasData(
                new Parameters { Token = new Guid("69EA80A0-0472-11EE-993E-37EECAAE1115"), doc_company = "38367316000199" },
                new Parameters { Token = new Guid("56DFD210-0472-11EE-BFA0-99577F33D6F0"), doc_company = "42538267000268" }
            );
        }
    }
}
