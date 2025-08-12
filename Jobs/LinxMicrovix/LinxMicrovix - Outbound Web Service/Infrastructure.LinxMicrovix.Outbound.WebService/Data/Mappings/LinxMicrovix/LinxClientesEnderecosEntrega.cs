using Infrastructure.Core.Data.Schemas;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using Domain.LinxMicrovix.Outbound.WebService.Models.LinxMicrovix;
using Infrastructure.Core.Data.Extensions;
using Domain.Core.Enums;

namespace Infrastructure.LinxMicrovix.Outbound.WebService.Data.Mappings.LinxMicrovix
{
    public class LinxClientesEnderecosEntregaMap : IEntityTypeConfiguration<LinxClientesEnderecosEntrega>
    {
        public void Configure(EntityTypeBuilder<LinxClientesEnderecosEntrega> builder)
        {
            var schema = SchemaContext.GetSchema(typeof(LinxClientesEnderecosEntrega));

            builder.ToTable("LinxClientesEnderecosEntrega");

            if (schema == "linx_microvix_erp")
                builder.HasKey(e => e.id_endereco_entrega);
            

            builder.Property(e => e.lastupdateon)
                .HasProviderColumnType(EnumTableColumnType.DateTime);

            builder.Property(e => e.id_endereco_entrega)
            .HasColumnType("int");

            builder.Property(e => e.cod_cliente)
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

            builder.Property(e => e.fone_cliente)
                .HasColumnType("varchar(20)");

            builder.Property(e => e.fone_celular)
                .HasColumnType("varchar(20)");

            builder.Property(e => e.timestamp)
                .HasColumnType("bigint");

            builder.Property(e => e.portal)
                .HasColumnType("int");
        }
    }
}
