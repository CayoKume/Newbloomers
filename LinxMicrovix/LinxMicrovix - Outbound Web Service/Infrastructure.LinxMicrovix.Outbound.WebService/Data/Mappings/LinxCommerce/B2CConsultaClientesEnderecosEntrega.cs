using Infrastructure.IntegrationsCore.Data.Schemas;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using Domain.LinxMicrovix.Outbound.WebService.Models.LinxCommerce;
using Infrastructure.IntegrationsCore.Data.Extensions;

using Domain.IntegrationsCore.Enums;

namespace Infrastructure.LinxMicrovix.Outbound.WebService.Data.Mappings.LinxCommerce
{
    public class B2CConsultaClientesEnderecosEntregaMap : IEntityTypeConfiguration<B2CConsultaClientesEnderecosEntrega>
    {
        public void Configure(EntityTypeBuilder<B2CConsultaClientesEnderecosEntrega> builder)
        {
            var schema = SchemaContext.GetSchema(typeof(B2CConsultaClientesEnderecosEntrega));

            builder.ToTable("B2CConsultaClientesEnderecosEntrega");

            if (schema == "linx_microvix_commerce")
            {
                builder.HasKey(e => new { e.id_endereco_entrega, e.cod_cliente_erp, e.cod_cliente_b2c, e.id_cidade });
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

            builder.Property(e => e.id_endereco_entrega)
                .HasColumnType("int");

            builder.Property(e => e.cod_cliente_erp)
                .HasColumnType("int");

            builder.Property(e => e.cod_cliente_b2c)
                .HasColumnType("int");

            builder.Property(e => e.endereco_cliente)
                .HasColumnType("varchar(250)");

            builder.Property(e => e.numero_rua_cliente)
                .HasColumnType("varchar(20)");

            builder.Property(e => e.complemento_end_cli)
                .HasColumnType("varchar(60)");

            builder.Property(e => e.cep_cliente)
                .HasColumnType("char(9)");

            builder.Property(e => e.bairro_cliente)
                .HasColumnType("varchar(60)");

            builder.Property(e => e.cidade_cliente)
                .HasColumnType("varchar(40)");

            builder.Property(e => e.uf_cliente)
                .HasColumnType("char(2)");

            builder.Property(e => e.descricao)
                .HasColumnType("varchar(250)");

            builder.Property(e => e.principal)
                .HasProviderColumnType(EnumTableColumnType.Bool);

            builder.Property(e => e.id_cidade)
                .HasColumnType("int");

            builder.Property(e => e.timestamp)
                .HasColumnType("bigint");

            builder.Property(e => e.portal)
                .HasColumnType("int");
        }
    }
}
