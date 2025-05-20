using Infrastructure.LinxMicrovix.Outbound.WebService.Schema;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using Domain.LinxMicrovix.Outbound.WebService.Entites.LinxMicrovix;
using Infrastructure.LinxMicrovix.Outbound.WebService.Data.Extensions;
using Domain.LinxMicrovix.Outbound.WebService.Enums;

namespace Infrastructure.LinxMicrovix.Outbound.WebService.Data.Mappings.LinxMicrovix
{
    public class LinxMovimentoPrincipalMap : IEntityTypeConfiguration<LinxMovimentoPrincipal>
    {
        public void Configure(EntityTypeBuilder<LinxMovimentoPrincipal> builder)
        {
            var schema = SchemaContext.GetSchema(typeof(LinxMovimentoPrincipal));

            builder.ToTable("LinxMovimentoPrincipal");

            if (schema == "linx_microvix_erp")
            {
                builder.HasKey(e => e.id_movimento_principal);
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
                .HasProviderColumnType(LogicalColumnType.DateTime);

            builder.Property(e => e.id_movimento_principal)
                .HasColumnType("int");

            builder.Property(e => e.identificador)
                .HasProviderColumnType(LogicalColumnType.UUID);

            builder.Property(e => e.codigoproduto_manutencao)
                .HasColumnType("bigint");

            builder.Property(e => e.timestamp)
                .HasColumnType("bigint");

            builder.Property(e => e.id_pergunta_venda)
                .HasColumnType("int");

            builder.Property(e => e.id_resposta_venda)
                .HasColumnType("int");

            builder.Property(e => e.total_fidelidade_cashback)
                .HasColumnType("decimal(10,2)");

            builder.Property(e => e.plano_fidelidade_cashback)
                .HasColumnType("int");

            builder.Property(e => e.remessa_pedido_compra)
                .HasColumnType("varchar(30)");

            builder.Property(e => e.id_motivo_desconto)
                .HasColumnType("int");

            builder.Property(e => e.valor_nota)
                .HasColumnType("decimal(10,2)");
        }
    }
}
