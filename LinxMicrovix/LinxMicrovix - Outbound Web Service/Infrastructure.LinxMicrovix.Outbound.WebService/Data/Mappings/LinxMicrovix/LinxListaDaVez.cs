using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using Domain.LinxMicrovix.Outbound.WebService.Entites.LinxMicrovix;
using Domain.LinxMicrovix.Outbound.WebService.Enums;
using Infrastructure.LinxMicrovix.Outbound.WebService.Data.Extensions;


namespace Infrastructure.LinxMicrovix.Outbound.WebService.Data.Mappings.LinxMicrovix
{
    public class LinxListaDaVezMap : IEntityTypeConfiguration<LinxListaDaVez>
    {
        

        

        public void Configure(EntityTypeBuilder<LinxListaDaVez> builder)
        {
            builder.ToTable("LinxListaDaVez");

            builder.Property(e => e.lastupdateon)
                .HasProviderColumnType(LogicalColumnType.DateTime);

            builder.Property(e => e.portal)
                .HasColumnType("int");

            builder.Property(e => e.cnpj_emp)
                .HasColumnType("varchar(14)");

            builder.Property(e => e.cod_vendedor)
                .HasColumnType("int");

            builder.Property(e => e.data)
                .HasProviderColumnType(LogicalColumnType.DateTime);

            builder.Property(e => e.motivo_nao_venda)
                .HasColumnType("varchar(103)");

            builder.Property(e => e.qtde_ocorrencias)
                .HasColumnType("int");

            builder.Property(e => e.data_hora_ini_atend)
                .HasProviderColumnType(LogicalColumnType.DateTime);

            builder.Property(e => e.data_hora_fim_atend)
                .HasProviderColumnType(LogicalColumnType.DateTime);

            builder.Property(e => e.obs)
                .HasProviderColumnType(LogicalColumnType.Varchar_Max);

            builder.Property(e => e.desc_produto_neg)
                .HasColumnType("varchar(50)");

            builder.Property(e => e.valor_produto_neg)
                .HasColumnType("decimal(10,2)");
        }
    }
}
