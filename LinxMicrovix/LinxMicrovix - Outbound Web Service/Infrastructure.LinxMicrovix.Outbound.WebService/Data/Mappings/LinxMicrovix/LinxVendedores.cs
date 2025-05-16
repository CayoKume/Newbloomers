using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using Domain.LinxMicrovix.Outbound.WebService.Entites.LinxMicrovix;
using Domain.LinxMicrovix.Outbound.WebService.Enums;
using Infrastructure.LinxMicrovix.Outbound.WebService.Data.Extensions;

namespace Infrastructure.LinxMicrovix.Outbound.WebService.Data.Mappings.LinxMicrovix
{
    public class LinxVendedoresMap : IEntityTypeConfiguration<LinxVendedores>
    {
        public void Configure(EntityTypeBuilder<LinxVendedores> builder)
        {
            builder.ToTable("LinxVendedores", "linx_microvix_erp");

            builder.HasKey(e => new { e.cod_vendedor, e.cpf_vendedor });

            builder.Property(e => e.lastupdateon)
                .HasProviderColumnType(LogicalColumnType.DateTime);

            builder.Property(e => e.cod_vendedor)
                .HasColumnType("int");

            builder.Property(e => e.nome_vendedor)
                .HasColumnType("varchar(50)");

            builder.Property(e => e.tipo_vendedor)
                .HasColumnType("char(1)");

            builder.Property(e => e.end_vend_rua)
                .HasColumnType("varchar(250)");

            builder.Property(e => e.end_vend_numero)
                .HasColumnType("varchar(20)");

            builder.Property(e => e.end_vend_complemento)
                .HasColumnType("varchar(60)");

            builder.Property(e => e.end_vend_bairro)
                .HasColumnType("varchar(60)");

            builder.Property(e => e.end_vend_cep)
                .HasColumnType("varchar(9)");

            builder.Property(e => e.end_vend_cidade)
                .HasColumnType("varchar(40)");

            builder.Property(e => e.end_vend_uf)
                .HasColumnType("char(2)");

            builder.Property(e => e.fone_vendedor)
                .HasColumnType("varchar(20)");

            builder.Property(e => e.mail_vendedor)
                .HasColumnType("varchar(50)");

            builder.Property(e => e.dt_upd)
                .HasProviderColumnType(LogicalColumnType.DateTime);

            builder.Property(e => e.cpf_vendedor)
                .HasColumnType("varchar(14)");

            builder.Property(e => e.ativo)
                .HasColumnType("char(1)");

            builder.Property(e => e.data_admissao)
                .HasProviderColumnType(LogicalColumnType.DateTime);

            builder.Property(e => e.data_saida)
                .HasProviderColumnType(LogicalColumnType.DateTime);

            builder.Property(e => e.portal)
                .HasColumnType("int");

            builder.Property(e => e.timestamp)
                .HasColumnType("bigint");

            builder.Property(e => e.matricula)
                .HasColumnType("varchar(30)");

            builder.Property(e => e.id_tipo_venda)
                .HasColumnType("int");

            builder.Property(e => e.descricao_tipo_venda)
                .HasColumnType("varchar(100)");

            builder.Property(e => e.cargo)
                .HasColumnType("varchar(20)");
        }
    }

    public class LinxVendedoresRawMap : IEntityTypeConfiguration<LinxVendedores>
    {
        public void Configure(EntityTypeBuilder<LinxVendedores> builder)
        {
            builder.ToTable("LinxVendedores", "untreated");

            builder.HasKey(e => e.id);

            builder.Property(e => e.id)
                .HasColumnType("int")
                .ValueGeneratedOnAdd();

            builder.Property(e => e.lastupdateon)
                .HasProviderColumnType(LogicalColumnType.DateTime);

            builder.Property(e => e.cod_vendedor)
                .HasColumnType("int");

            builder.Property(e => e.nome_vendedor)
                .HasColumnType("varchar(50)");

            builder.Property(e => e.tipo_vendedor)
                .HasColumnType("char(1)");

            builder.Property(e => e.end_vend_rua)
                .HasColumnType("varchar(250)");

            builder.Property(e => e.end_vend_numero)
                .HasColumnType("varchar(20)");

            builder.Property(e => e.end_vend_complemento)
                .HasColumnType("varchar(60)");

            builder.Property(e => e.end_vend_bairro)
                .HasColumnType("varchar(60)");

            builder.Property(e => e.end_vend_cep)
                .HasColumnType("varchar(9)");

            builder.Property(e => e.end_vend_cidade)
                .HasColumnType("varchar(40)");

            builder.Property(e => e.end_vend_uf)
                .HasColumnType("char(2)");

            builder.Property(e => e.fone_vendedor)
                .HasColumnType("varchar(20)");

            builder.Property(e => e.mail_vendedor)
                .HasColumnType("varchar(50)");

            builder.Property(e => e.dt_upd)
                .HasProviderColumnType(LogicalColumnType.DateTime);

            builder.Property(e => e.cpf_vendedor)
                .HasColumnType("varchar(14)");

            builder.Property(e => e.ativo)
                .HasColumnType("char(1)");

            builder.Property(e => e.data_admissao)
                .HasProviderColumnType(LogicalColumnType.DateTime);

            builder.Property(e => e.data_saida)
                .HasProviderColumnType(LogicalColumnType.DateTime);

            builder.Property(e => e.portal)
                .HasColumnType("int");

            builder.Property(e => e.timestamp)
                .HasColumnType("bigint");

            builder.Property(e => e.matricula)
                .HasColumnType("varchar(30)");

            builder.Property(e => e.id_tipo_venda)
                .HasColumnType("int");

            builder.Property(e => e.descricao_tipo_venda)
                .HasColumnType("varchar(100)");

            builder.Property(e => e.cargo)
                .HasColumnType("varchar(20)");
        }
    }
}
