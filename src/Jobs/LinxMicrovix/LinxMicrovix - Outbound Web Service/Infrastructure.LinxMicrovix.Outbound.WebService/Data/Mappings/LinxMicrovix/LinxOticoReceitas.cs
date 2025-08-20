using Infrastructure.Core.Data.Schemas;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using Domain.LinxMicrovix.Outbound.WebService.Models.LinxMicrovix;
using Infrastructure.Core.Data.Extensions;
using Domain.Core.Enums;

namespace Infrastructure.LinxMicrovix.Outbound.WebService.Data.Mappings.LinxMicrovix
{
    public class LinxOticoReceitasMap : IEntityTypeConfiguration<LinxOticoReceitas>
    {
        public void Configure(EntityTypeBuilder<LinxOticoReceitas> builder)
        {
            var schema = SchemaContext.GetSchema(typeof(LinxOticoReceitas));

            builder.ToTable("LinxOticoReceitas");

            if (schema == "linx_microvix_erp")
                builder.HasKey(e => e.id_otico_receitas);
            

            builder.Property(e => e.lastupdateon)
                .HasProviderColumnType(EnumTableColumnType.DateTime);

            builder.Property(e => e.id_otico_receitas)
                .HasColumnType("int");

            builder.Property(e => e.cod_cliente)
                .HasColumnType("int");

            builder.Property(e => e.codigoproduto)
                .HasColumnType("bigint");

            builder.Property(e => e.lng_esferico_od)
                .HasColumnType("decimal(10,2)");

            builder.Property(e => e.lng_cilindrico_od)
                .HasColumnType("decimal(10,2)");

            builder.Property(e => e.lng_eixo_od)
                .HasColumnType("decimal(10,2)");

            builder.Property(e => e.lng_dpdpn_od)
                .HasColumnType("decimal(10,2)");

            builder.Property(e => e.lng_altura_od)
                .HasColumnType("decimal(10,2)");

            builder.Property(e => e.prt_esferico_od)
                .HasColumnType("decimal(10,2)");

            builder.Property(e => e.prt_cilindrico_od)
                .HasColumnType("decimal(10,2)");

            builder.Property(e => e.prt_eixo_od)
                .HasColumnType("decimal(10,2)");

            builder.Property(e => e.prt_dpdpn_od)
                .HasColumnType("decimal(10,2)");

            builder.Property(e => e.lng_esferico_oe)
                .HasColumnType("decimal(10,2)");

            builder.Property(e => e.lng_cilindrico_oe)
                .HasColumnType("decimal(10,2)");

            builder.Property(e => e.lng_eixo_oe)
                .HasColumnType("decimal(10,2)");

            builder.Property(e => e.lng_dpdpn_oe)
                .HasColumnType("decimal(10,2)");

            builder.Property(e => e.lng_altura_oe)
                .HasColumnType("decimal(10,2)");

            builder.Property(e => e.prt_esferico_oe)
                .HasColumnType("decimal(10,2)");

            builder.Property(e => e.prt_cilindrico_oe)
                .HasColumnType("decimal(10,2)");

            builder.Property(e => e.prt_eixo_oe)
                .HasColumnType("decimal(10,2)");

            builder.Property(e => e.prt_dpdpn_oe)
                .HasColumnType("decimal(10,2)");

            builder.Property(e => e.lng_adicao_od)
                .HasColumnType("decimal(10,2)");

            builder.Property(e => e.lng_adicao_oe)
                .HasColumnType("decimal(10,2)");

            builder.Property(e => e.otico_lado_lente)
                .HasColumnType("varchar(15)");

            builder.Property(e => e.diametro_od)
                .HasColumnType("decimal(10,2)");

            builder.Property(e => e.diametro_oe)
                .HasColumnType("decimal(10,2)");

            builder.Property(e => e.ponte)
                .HasColumnType("decimal(10,2)");

            builder.Property(e => e.altura)
                .HasColumnType("decimal(10,2)");

            builder.Property(e => e.aro)
                .HasColumnType("decimal(10,2)");

            builder.Property(e => e.diag_maior)
                .HasColumnType("decimal(10,2)");

            builder.Property(e => e.tipo_armacao)
                .HasColumnType("varchar(100)");

            builder.Property(e => e.observacao)
                .HasColumnType("varchar(100)");

            builder.Property(e => e.paciente)
                .HasColumnType("varchar(100)");

            builder.Property(e => e.cmpl_add_od)
                .HasColumnType("decimal(10,2)");

            builder.Property(e => e.cmpl_add_oe)
                .HasColumnType("decimal(10,2)");

            builder.Property(e => e.base_od)
                .HasColumnType("decimal(10,2)");

            builder.Property(e => e.base_oe)
                .HasColumnType("decimal(10,2)");

            builder.Property(e => e.dist_haste)
                .HasColumnType("decimal(10,2)");

            builder.Property(e => e.dist_front)
                .HasColumnType("decimal(10,2)");

            builder.Property(e => e.curvatura)
                .HasColumnType("decimal(10,2)");

            builder.Property(e => e.lng_pris1_od)
                .HasColumnType("decimal(10,2)");

            builder.Property(e => e.id_lng_pris1_od_desc)
                .HasColumnType("int");

            builder.Property(e => e.lng_pris1_oe)
                .HasColumnType("decimal(10,2)");

            builder.Property(e => e.id_lng_pris1_oe_desc)
                .HasColumnType("int");

            builder.Property(e => e.prt_pris1_od)
                .HasColumnType("decimal(10,2)");

            builder.Property(e => e.id_prt_pris1_od_desc)
                .HasColumnType("int");

            builder.Property(e => e.prt_pris1_oe)
                .HasColumnType("decimal(10,2)");

            builder.Property(e => e.id_prt_pris1_oe_desc)
                .HasColumnType("int");

            builder.Property(e => e.lng_pris2_od)
                .HasColumnType("decimal(10,2)");

            builder.Property(e => e.id_lng_pris2_od_desc)
                .HasColumnType("int");

            builder.Property(e => e.lng_pris2_oe)
                .HasColumnType("decimal(10,2)");

            builder.Property(e => e.id_lng_pris2_oe_desc)
                .HasColumnType("int");

            builder.Property(e => e.prt_pris2_od)
                .HasColumnType("decimal(10,2)");

            builder.Property(e => e.id_prt_pris2_od_desc)
                .HasColumnType("int");

            builder.Property(e => e.prt_pris2_oe)
                .HasColumnType("decimal(10,2)");

            builder.Property(e => e.id_prt_pris2_oe_desc)
                .HasColumnType("int");

            builder.Property(e => e.dist_vertice)
                .HasColumnType("decimal(10,2)");

            builder.Property(e => e.inc_planto)
                .HasColumnType("decimal(10,2)");

            builder.Property(e => e.ativ_princ)
                .HasColumnType("varchar(40)");

            builder.Property(e => e.otico_area_privilegiada)
                .HasColumnType("varchar(15)");

            builder.Property(e => e.dist_visao)
                .HasColumnType("decimal(10,2)");

            builder.Property(e => e.personalizada)
                .HasColumnType("varchar(100)");

            builder.Property(e => e.pris_od)
                .HasColumnType("decimal(10,2)");

            builder.Property(e => e.pris_oe)
                .HasColumnType("decimal(10,2)");

            builder.Property(e => e.eixo_od)
                .HasColumnType("decimal(10,2)");

            builder.Property(e => e.eixo_oe)
                .HasColumnType("decimal(10,2)");

            builder.Property(e => e.borda_od)
                .HasColumnType("decimal(10,2)");

            builder.Property(e => e.borda_oe)
                .HasColumnType("decimal(10,2)");

            builder.Property(e => e.centro_od)
                .HasColumnType("decimal(10,2)");

            builder.Property(e => e.centro_oe)
                .HasColumnType("decimal(10,2)");

            builder.Property(e => e.furo_od)
                .HasColumnType("decimal(10,2)");

            builder.Property(e => e.furo_oe)
                .HasColumnType("decimal(10,2)");

            builder.Property(e => e.format_corte)
                .HasColumnType("varchar(40)");

            builder.Property(e => e.dist_leitura)
                .HasColumnType("varchar(40)");

            builder.Property(e => e.tipo_lente)
                .HasColumnType("varchar(100)");

            builder.Property(e => e.endereco_paciente)
                .HasColumnType("varchar(100)");

            builder.Property(e => e.medico_especialista)
                .HasColumnType("varchar(100)");

            builder.Property(e => e.endereco_medico_especialista)
                .HasColumnType("varchar(100)");

            builder.Property(e => e.refracionista_optico)
                .HasColumnType("varchar(100)");

            builder.Property(e => e.data_receita)
                .HasProviderColumnType(EnumTableColumnType.DateTime);

            builder.Property(e => e.id_produtos_opticos_tipo_aro)
                .HasColumnType("int");

            builder.Property(e => e.dp_montagem)
                .HasColumnType("decimal(10,2)");

            builder.Property(e => e.id_produtos_opticos_formato_aro)
                .HasColumnType("int");

            builder.Property(e => e.codigo_gerencial)
                .HasColumnType("varchar(40)");

            builder.Property(e => e.migracao_dados)
                .HasProviderColumnType(EnumTableColumnType.Bool);

            builder.Property(e => e.migracao_observacao)
                .HasProviderColumnType(EnumTableColumnType.Varchar_Max);

            builder.Property(e => e.portal)
                .HasColumnType("int");

            builder.Property(e => e.timestamp)
                .HasColumnType("bigint");
        }
    }
}
