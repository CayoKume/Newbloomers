using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using Domain.LinxMicrovix.Outbound.WebService.Entites.LinxCommerce;
using Domain.LinxMicrovix.Outbound.WebService.Enums;
using Infrastructure.LinxMicrovix.Outbound.WebService.Data.Extensions;


namespace Infrastructure.LinxMicrovix.Outbound.WebService.Data.Mappings.LinxCommerce
{
    public class B2CConsultaCNPJsChaveMap : IEntityTypeConfiguration<B2CConsultaCNPJsChave>
    {
        

        

        public void Configure(EntityTypeBuilder<B2CConsultaCNPJsChave> builder)
        {
            builder.ToTable("B2CConsultaCNPJsChave");

            builder.HasKey(e => new { e.cnpj, e.id_empresas_rede, e.empresa });

            builder.Property(e => e.lastupdateon)
                .HasProviderColumnType(LogicalColumnType.DateTime);

            builder.Property(e => e.cnpj)
                .HasColumnType("varchar(14)");

            builder.Property(e => e.nome_empresa)
                .HasColumnType("varchar(250)");

            builder.Property(e => e.id_empresas_rede)
                .HasColumnType("smallint");

            builder.Property(e => e.rede)
                .HasColumnType("varchar(100)");

            builder.Property(e => e.portal)
                .HasColumnType("int");

            builder.Property(e => e.nome_portal)
                .HasColumnType("varchar(50)");

            builder.Property(e => e.empresa)
                .HasColumnType("int");

            builder.Property(e => e.classificacao_portal)
                .HasColumnType("varchar(50)");

            builder.Property(e => e.b2c)
                .HasProviderColumnType(LogicalColumnType.Bool);

            builder.Property(e => e.oms)
                .HasProviderColumnType(LogicalColumnType.Bool);
        }
    }
}
