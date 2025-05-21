using Infrastructure.IntegrationsCore.Data.Schemas;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using Domain.LinxMicrovix.Outbound.WebService.Entites.LinxCommerce;
using Domain.IntegrationsCore.Entities.Enums;
using Infrastructure.IntegrationsCore.Data.Extensions;
using Domain.LinxMicrovix.Outbound.WebService.Entites.LinxMicrovix;

namespace Infrastructure.LinxMicrovix.Outbound.WebService.Data.Mappings.LinxCommerce
{
    public class B2CConsultaFornecedoresMap : IEntityTypeConfiguration<B2CConsultaFornecedores>
    {
        public void Configure(EntityTypeBuilder<B2CConsultaFornecedores> builder)
        {
            var schema = SchemaContext.GetSchema(typeof(B2CConsultaFornecedores));

            builder.ToTable("B2CConsultaFornecedores");

            if (schema == "linx_microvix_commerce")
            {
                builder.HasKey(e => new { e.cod_fornecedor, e.documento });
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

            builder.Property(e => e.cod_fornecedor)
                .HasColumnType("int");

            builder.Property(e => e.nome)
                .HasColumnType("varchar(60)");

            builder.Property(e => e.nome_fantasia)
                .HasColumnType("varchar(60)");

            builder.Property(e => e.tipo_pessoa)
                .HasColumnType("char(1)");

            builder.Property(e => e.tipo_fornecedor)
                .HasColumnType("char(1)");

            builder.Property(e => e.endereco)
                .HasColumnType("varchar(250)");

            builder.Property(e => e.numero_rua)
                .HasColumnType("varchar(20)");

            builder.Property(e => e.bairro)
                .HasColumnType("varchar(60)");

            builder.Property(e => e.cep)
                .HasColumnType("char(9)");

            builder.Property(e => e.cidade)
                .HasColumnType("varchar(40)");

            builder.Property(e => e.uf)
                .HasColumnType("char(2)");

            builder.Property(e => e.documento)
                .HasColumnType("varchar(14)");

            builder.Property(e => e.fone)
                .HasColumnType("varchar(20)");

            builder.Property(e => e.email)
                .HasColumnType("varchar(50)");

            builder.Property(e => e.pais)
                .HasColumnType("varchar(80)");

            builder.Property(e => e.obs)
                .HasProviderColumnType(EnumTableColumnType.Varchar_Max);

            builder.Property(e => e.timestamp)
                .HasColumnType("bigint");

            builder.Property(e => e.portal)
                .HasColumnType("int");
        }
    }
}
