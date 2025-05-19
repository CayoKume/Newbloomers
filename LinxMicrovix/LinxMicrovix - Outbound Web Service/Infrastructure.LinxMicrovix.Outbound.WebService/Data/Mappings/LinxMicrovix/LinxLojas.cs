using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using Domain.LinxMicrovix.Outbound.WebService.Entites.LinxMicrovix;
using Domain.LinxMicrovix.Outbound.WebService.Enums;
using Infrastructure.LinxMicrovix.Outbound.WebService.Data.Extensions;


namespace Infrastructure.LinxMicrovix.Outbound.WebService.Data.Mappings.LinxMicrovix
{
    public class LinxLojasMap : IEntityTypeConfiguration<LinxLojas>
    {
        

        

        public void Configure(EntityTypeBuilder<LinxLojas> builder)
        {
            builder.ToTable("LinxLojas");

            builder.HasKey(e => e.empresa);

            builder.Property(e => e.lastupdateon)
                .HasProviderColumnType(LogicalColumnType.DateTime);

            builder.Property(e => e.portal)
                .HasColumnType("int");

            builder.Property(e => e.empresa)
                .HasColumnType("int");

            builder.Property(e => e.nome_emp)
                .HasColumnType("varchar(50)");

            builder.Property(e => e.razao_emp)
                .HasColumnType("varchar(200)");

            builder.Property(e => e.cnpj_emp)
                .HasColumnType("varchar(14)");

            builder.Property(e => e.inscricao_emp)
                .HasColumnType("varchar(20)");

            builder.Property(e => e.endereco_emp)
                .HasColumnType("varchar(250)");

            builder.Property(e => e.num_emp)
                .HasColumnType("int");

            builder.Property(e => e.complement_emp)
                .HasColumnType("varchar(60)");

            builder.Property(e => e.bairro_emp)
                .HasColumnType("varchar(50)");

            builder.Property(e => e.cep_emp)
                .HasColumnType("char(9)");

            builder.Property(e => e.cidade_emp)
                .HasColumnType("varchar(50)");

            builder.Property(e => e.estado_emp)
                .HasColumnType("char(2)");

            builder.Property(e => e.fone_emp)
                .HasColumnType("varchar(70)");

            builder.Property(e => e.email_emp)
                .HasColumnType("varchar(50)");

            builder.Property(e => e.cod_ibge_municipio)
                .HasColumnType("int");

            builder.Property(e => e.data_criacao_emp)
                .HasProviderColumnType(LogicalColumnType.DateTime);

            builder.Property(e => e.data_criacao_portal)
                .HasProviderColumnType(LogicalColumnType.DateTime);

            builder.Property(e => e.sistema_tributacao)
                .HasColumnType("char(1)");

            builder.Property(e => e.regime_tributario)
                .HasColumnType("int");

            builder.Property(e => e.area_empresa)
                .HasColumnType("decimal(10,2)");

            builder.Property(e => e.timestamp)
                .HasColumnType("int");

            builder.Property(e => e.sigla_empresa)
                .HasColumnType("varchar(10)");

            builder.Property(e => e.id_classe_fiscal)
                .HasColumnType("int");

            builder.Property(e => e.centro_distribuicao)
                .HasProviderColumnType(LogicalColumnType.Bool);

            builder.Property(e => e.inscricao_municipal_emp)
                .HasColumnType("varchar(30)");

            builder.Property(e => e.cnae_emp)
                .HasColumnType("varchar(7)");

            builder.Property(e => e.cod_cliente_linx)
                .HasColumnType("varchar(6)");

            builder.Property(e => e.tabela_preco_preferencial)
                .HasColumnType("int");
        }
    }
}
