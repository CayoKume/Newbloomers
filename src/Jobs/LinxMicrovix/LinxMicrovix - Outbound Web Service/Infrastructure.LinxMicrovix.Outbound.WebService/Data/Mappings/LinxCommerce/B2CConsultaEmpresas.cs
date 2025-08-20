using Infrastructure.Core.Data.Schemas;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using Domain.LinxMicrovix.Outbound.WebService.Models.LinxCommerce;
using Infrastructure.Core.Data.Extensions;

using Domain.Core.Enums;

namespace Infrastructure.LinxMicrovix.Outbound.WebService.Data.Mappings.LinxCommerce
{
    public class B2CConsultaEmpresasMap : IEntityTypeConfiguration<B2CConsultaEmpresas>
    {
        public void Configure(EntityTypeBuilder<B2CConsultaEmpresas> builder)
        {
            var schema = SchemaContext.GetSchema(typeof(B2CConsultaEmpresas));

            builder.ToTable("B2CConsultaEmpresas");

            if (schema == "linx_microvix_commerce")
            {
                builder.HasKey(e => new { e.empresa, e.cnpj_emp });
                builder.Ignore(e => e.id);
            }  
            else
            {
                builder.HasKey(e => e.id);

                builder.Property(e => e.id)
                    .HasColumnType("int")
                    .ValueGeneratedOnAdd();
            }
                
            builder.Property(e => e.lastupdateon)
                .HasProviderColumnType(EnumTableColumnType.DateTime);

            builder.Property(e => e.empresa)
                .HasColumnType("int");

            builder.Property(e => e.nome_emp)
                .HasColumnType("varchar(50)");

            builder.Property(e => e.cnpj_emp)
                .HasColumnType("varchar(14)");

            builder.Property(e => e.end_unidade)
                .HasColumnType("varchar(250)");

            builder.Property(e => e.complemento_end_unidade)
                .HasColumnType("varchar(60)");

            builder.Property(e => e.nr_rua_unidade)
                .HasColumnType("varchar(20)");

            builder.Property(e => e.bairro_unidade)
                .HasColumnType("varchar(60)");

            builder.Property(e => e.cep_unidade)
                .HasColumnType("varchar(9)");

            builder.Property(e => e.cidade_unidade)
                .HasColumnType("varchar(50)");

            builder.Property(e => e.uf_unidade)
                .HasColumnType("char(2)");

            builder.Property(e => e.email_unidade)
                .HasColumnType("varchar(50)");

            builder.Property(e => e.timestamp)
                .HasColumnType("bigint");

            builder.Property(e => e.data_criacao)
                .HasProviderColumnType(EnumTableColumnType.DateTime);

            builder.Property(e => e.centro_distribuicao)
                .HasProviderColumnType(EnumTableColumnType.Bool);

            builder.Property(e => e.portal)
                .HasColumnType("int");
        }
    }
}
