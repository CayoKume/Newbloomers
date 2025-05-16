using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using Domain.LinxMicrovix.Outbound.WebService.Entities.LinxMicrovix;
using Domain.LinxMicrovix.Outbound.WebService.Enums;
using Infrastructure.LinxMicrovix.Outbound.WebService.Data.Extensions;

namespace Infrastructure.LinxMicrovix.Outbound.WebService.Data.Mappings.LinxMicrovix
{
    public class LinxUsuariosTrustedMap : IEntityTypeConfiguration<LinxUsuarios>
    {
        public void Configure(EntityTypeBuilder<LinxUsuarios> builder)
        {
            builder.ToTable("LinxUsuarios", "linx_microvix_erp");

            builder.HasKey(e => e.usuario_id);

            builder.Property(e => e.lastupdateon)
                .HasProviderColumnType(LogicalColumnType.DateTime);

            builder.Property(e => e.usuario_id)
                .HasColumnType("int");

            builder.Property(e => e.usuario_login)
                .HasColumnType("varchar(30)");

            builder.Property(e => e.usuario_nome)
                .HasColumnType("varchar(50)");

            builder.Property(e => e.usuario_email)
                .HasColumnType("varchar(60)");

            builder.Property(e => e.usuario_grupo_id)
                .HasColumnType("int");

            builder.Property(e => e.grupo_usuarios)
                .HasColumnType("char(1)");

            builder.Property(e => e.usuario_supervisor)
                .HasColumnType("char(1)");

            builder.Property(e => e.usuario_doc)
                .HasColumnType("varchar(14)");

            builder.Property(e => e.vendedor)
                .HasColumnType("int");

            builder.Property(e => e.data_criacao)
                .HasProviderColumnType(LogicalColumnType.DateTime);

            builder.Property(e => e.desativado)
                .HasColumnType("char(1)");

            builder.Property(e => e.empresas)
                .HasColumnType("varchar(MAX)");

            builder.Property(e => e.portal)
                .HasColumnType("int");

            builder.Property(e => e.timestamp)
                .HasColumnType("bigint");
        }
    }

    public class LinxUsuariosRawMap : IEntityTypeConfiguration<LinxUsuarios>
    {
        public void Configure(EntityTypeBuilder<LinxUsuarios> builder)
        {
            builder.ToTable("LinxUsuarios", "untreated");

            builder.HasKey(e => e.id);

            builder.Property(e => e.id)
                .HasColumnType("int")
                .ValueGeneratedOnAdd();

            builder.Property(e => e.lastupdateon)
                .HasProviderColumnType(LogicalColumnType.DateTime);

            builder.Property(e => e.usuario_id)
                .HasColumnType("int");

            builder.Property(e => e.usuario_login)
                .HasColumnType("varchar(30)");

            builder.Property(e => e.usuario_nome)
                .HasColumnType("varchar(50)");

            builder.Property(e => e.usuario_email)
                .HasColumnType("varchar(60)");

            builder.Property(e => e.usuario_grupo_id)
                .HasColumnType("int");

            builder.Property(e => e.grupo_usuarios)
                .HasColumnType("char(1)");

            builder.Property(e => e.usuario_supervisor)
                .HasColumnType("char(1)");

            builder.Property(e => e.usuario_doc)
                .HasColumnType("varchar(14)");

            builder.Property(e => e.vendedor)
                .HasColumnType("int");

            builder.Property(e => e.data_criacao)
                .HasProviderColumnType(LogicalColumnType.DateTime);

            builder.Property(e => e.desativado)
                .HasColumnType("char(1)");

            builder.Property(e => e.empresas)
                .HasColumnType("varchar(MAX)");

            builder.Property(e => e.portal)
                .HasColumnType("int");

            builder.Property(e => e.timestamp)
                .HasColumnType("bigint");
        }
    }
}
