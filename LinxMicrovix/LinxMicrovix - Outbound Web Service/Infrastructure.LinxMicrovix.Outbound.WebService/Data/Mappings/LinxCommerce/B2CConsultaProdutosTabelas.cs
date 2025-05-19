using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using Domain.LinxMicrovix.Outbound.WebService.Entites.LinxCommerce;
using Domain.LinxMicrovix.Outbound.WebService.Enums;
using Infrastructure.LinxMicrovix.Outbound.WebService.Data.Extensions;


namespace Infrastructure.LinxMicrovix.Outbound.WebService.Data.Mappings.LinxCommerce
{
    public class B2CConsultaProdutosTabelasMap : IEntityTypeConfiguration<B2CConsultaProdutosTabelas>
    {
        

        

        public void Configure(EntityTypeBuilder<B2CConsultaProdutosTabelas> builder)
        {
            builder.ToTable("B2CConsultaProdutosTabelas");

            builder.HasKey(e => e.id_tabela);

            builder.Property(e => e.lastupdateon)
                .HasProviderColumnType(LogicalColumnType.DateTime);

            builder.Property(e => e.id_tabela)
                .HasColumnType("int");

            builder.Property(e => e.nome_tabela)
                .HasColumnType("varchar(50)");

            builder.Property(e => e.ativa)
                .HasColumnType("char(1)");

            builder.Property(e => e.timestamp)
                .HasColumnType("bigint");

            builder.Property(e => e.portal)
                .HasColumnType("int");
        }
    }
}
