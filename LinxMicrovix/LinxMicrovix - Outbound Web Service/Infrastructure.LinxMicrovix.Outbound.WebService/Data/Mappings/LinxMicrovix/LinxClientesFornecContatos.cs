using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using Domain.LinxMicrovix.Outbound.WebService.Entites.LinxMicrovix;
using Infrastructure.LinxMicrovix.Outbound.WebService.Data.Extensions;
using Domain.LinxMicrovix.Outbound.WebService.Enums;

namespace Infrastructure.LinxMicrovix.Outbound.WebService.Data.Mappings.LinxMicrovix
{
    public class LinxClientesFornecContatosTrustedMap : IEntityTypeConfiguration<LinxClientesFornecContatos>
    {
        public void Configure(EntityTypeBuilder<LinxClientesFornecContatos> builder)
        {
            builder.ToTable("LinxClientesFornecContatos", "linx_microvix_erp");

            builder.HasKey(e => e.cod_cliente);

            builder.Property(e => e.lastupdateon)
                .HasProviderColumnType(LogicalColumnType.DateTime);

            builder.Property(e => e.portal)
                .HasColumnType("int");

            builder.Property(e => e.cod_cliente)
                .HasColumnType("int");

            builder.Property(e => e.nome_contato)
                .HasColumnType("varchar(50)");

            builder.Property(e => e.sexo_contato)
                .HasColumnType("char(1)");

            builder.Property(e => e.contatos_clientes_parentesco)
                .HasColumnType("int");

            builder.Property(e => e.fone1_contato)
                .HasColumnType("varchar(20)");

            builder.Property(e => e.fone2_contato)
                .HasColumnType("varchar(20)");

            builder.Property(e => e.celular_contato)
                .HasColumnType("varchar(20)");

            builder.Property(e => e.email_contato)
                .HasColumnType("varchar(50)");

            builder.Property(e => e.data_nasc_contato)
                .HasProviderColumnType(LogicalColumnType.DateTime);

            builder.Property(e => e.tipo_contato)
                .HasColumnType("varchar(20)");
        }
    }

    public class LinxClientesFornecContatosRawMap : IEntityTypeConfiguration<LinxClientesFornecContatos>
    {
        public void Configure(EntityTypeBuilder<LinxClientesFornecContatos> builder)
        {
            builder.ToTable("LinxClientesFornecContatos", "untreated");

            builder.HasKey(e => e.id);

            builder.Property(e => e.id)
                .HasColumnType("int")
                .ValueGeneratedOnAdd();

            builder.Property(e => e.lastupdateon)
            .HasProviderColumnType(LogicalColumnType.DateTime);

            builder.Property(e => e.portal)
                .HasColumnType("int");

            builder.Property(e => e.cod_cliente)
                .HasColumnType("int");

            builder.Property(e => e.nome_contato)
                .HasColumnType("varchar(50)");

            builder.Property(e => e.sexo_contato)
                .HasColumnType("char(1)");

            builder.Property(e => e.contatos_clientes_parentesco)
                .HasColumnType("int");

            builder.Property(e => e.fone1_contato)
                .HasColumnType("varchar(20)");

            builder.Property(e => e.fone2_contato)
                .HasColumnType("varchar(20)");

            builder.Property(e => e.celular_contato)
                .HasColumnType("varchar(20)");

            builder.Property(e => e.email_contato)
                .HasColumnType("varchar(50)");

            builder.Property(e => e.data_nasc_contato)
                .HasProviderColumnType(LogicalColumnType.DateTime);

            builder.Property(e => e.tipo_contato)
                .HasColumnType("varchar(20)");
        }
    }
}
