using Domain.Dootax.Entities;
using Domain.IntegrationsCore.Entities.Enums;
using Infrastructure.IntegrationsCore.Data.Extensions;
using Infrastructure.IntegrationsCore.Data.Schemas;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Dootax.Data.Mappings
{
    public class DootaxSuccessfulLogMap : IEntityTypeConfiguration<SuccessfulLog>
    {
        public void Configure(EntityTypeBuilder<SuccessfulLog> builder)
        {
            var schema = SchemaContext.GetSchema(typeof(SuccessfulLog));

            builder.ToTable("Dootax_Successful_Log", schema);

            builder.HasKey(c => c.id);

            builder
                .Property(c => c.id)
                .HasColumnType("int")
                .ValueGeneratedOnAdd();

            builder
                .Property(c => c.cnpj_emp)
                .HasColumnName("cnpj_emp")
                .HasColumnType("varchar(14)");

            builder
                .Property(c => c.documento)
                .HasColumnName("documento")
                .HasColumnType("int");

            builder
                .Property(c => c.serie)
                .HasColumnName("serie")
                .HasColumnType("varchar(10)");

            builder
                .Property(c => c.chave_nfe)
                .HasColumnName("chave_nfe")
                .HasColumnType("varchar(44)");

            builder
                .Property(c => c.dt_insert)
                .HasColumnName("dt_insert")
                .HasProviderColumnType(EnumTableColumnType.DateTime);
        }
    }
}
