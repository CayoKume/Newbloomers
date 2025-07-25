using Infrastructure.IntegrationsCore.Data.Schemas;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using Domain.LinxMicrovix.Outbound.WebService.Models.LinxMicrovix;
using Infrastructure.IntegrationsCore.Data.Extensions;
using Domain.IntegrationsCore.Enums;

namespace Infrastructure.LinxMicrovix.Outbound.WebService.Data.Mappings.LinxMicrovix
{
    public class LinxValesComprasEnviadosAPIMap : IEntityTypeConfiguration<LinxValesComprasEnviadosAPI>
    {
        public void Configure(EntityTypeBuilder<LinxValesComprasEnviadosAPI> builder)
        {
            var schema = SchemaContext.GetSchema(typeof(LinxValesComprasEnviadosAPI));

            builder.ToTable("LinxValesComprasEnviadosAPI");

            if (schema == "linx_microvix_erp")
            {
                builder.HasKey(e => e.numero_controle);
                builder.Ignore(x => x.id);
            }
            else
            {
                builder.HasKey(x => x.id);

                builder.Property(e => e.id)
                    .HasColumnType("int")
                    .ValueGeneratedOnAdd();
            }

            builder.Property(e => e.lastupdateon)
                .HasProviderColumnType(EnumTableColumnType.DateTime);

            builder.Property(e => e.numero_controle)
                .HasColumnType("int");

            builder.Property(e => e.valor_vale)
                .HasColumnType("decimal(10,2)");

            builder.Property(e => e.doc_cliente)
                .HasColumnType("varchar(14)");

            builder.Property(e => e.status_vale)
                .HasColumnType("int");

            builder.Property(e => e.codigo_portal_resgate)
                .HasColumnType("int");

            builder.Property(e => e.codigo_empresa_resgate)
                .HasColumnType("int");

            builder.Property(e => e.codigo_usuario_resgate)
                .HasColumnType("int");

            builder.Property(e => e.codigo_vale_empresa_resgate)
                .HasColumnType("int");

            builder.Property(e => e.data_criacao)
                .HasProviderColumnType(EnumTableColumnType.DateTime);

            builder.Property(e => e.timestamp)
                .HasColumnType("bigint");

            builder.Property(e => e.cnpj_empresa_resgate)
                .HasColumnType("varchar(14)");

            builder.Property(e => e.data_resgate)
                .HasProviderColumnType(EnumTableColumnType.DateTime);
        }
    }
}
