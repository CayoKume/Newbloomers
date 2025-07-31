using Domain.LinxMicrovix.Outbound.WebService.CustomValidations;

namespace Domain.LinxMicrovix.Outbound.WebService.Dtos.LinxMicrovix
{
    public class LinxOticoReceitas
    {
        public string? id_otico_receitas { get; private set; }
        public string? cod_cliente { get; private set; }
        public string? codigoproduto { get; private set; }
        public string? lng_esferico_od { get; private set; }
        public string? lng_cilindrico_od { get; private set; }
        public string? lng_eixo_od { get; private set; }
        public string? lng_dpdpn_od { get; private set; }
        public string? lng_altura_od { get; private set; }
        public string? prt_esferico_od { get; private set; }
        public string? prt_cilindrico_od { get; private set; }
        public string? prt_eixo_od { get; private set; }
        public string? prt_dpdpn_od { get; private set; }
        public string? lng_esferico_oe { get; private set; }
        public string? lng_cilindrico_oe { get; private set; }
        public string? lng_eixo_oe { get; private set; }
        public string? lng_dpdpn_oe { get; private set; }
        public string? lng_altura_oe { get; private set; }
        public string? prt_esferico_oe { get; private set; }
        public string? prt_cilindrico_oe { get; private set; }
        public string? prt_eixo_oe { get; private set; }
        public string? prt_dpdpn_oe { get; private set; }
        public string? lng_adicao_od { get; private set; }
        public string? lng_adicao_oe { get; private set; }
        public string? otico_lado_lente { get; private set; }
        public string? diametro_od { get; private set; }
        public string? diametro_oe { get; private set; }
        public string? ponte { get; private set; }
        public string? altura { get; private set; }
        public string? aro { get; private set; }
        public string? diag_maior { get; private set; }
        public string? tipo_armacao { get; private set; }
        public string? observacao { get; private set; }
        public string? paciente { get; private set; }
        public string? cmpl_add_od { get; private set; }
        public string? cmpl_add_oe { get; private set; }
        public string? base_od { get; private set; }
        public string? base_oe { get; private set; }
        public string? dist_haste { get; private set; }
        public string? dist_front { get; private set; }
        public string? curvatura { get; private set; }
        public string? lng_pris1_od { get; private set; }
        public string? id_lng_pris1_od_desc { get; private set; }
        public string? lng_pris1_oe { get; private set; }
        public string? id_lng_pris1_oe_desc { get; private set; }
        public string? prt_pris1_od { get; private set; }
        public string? id_prt_pris1_od_desc { get; private set; }
        public string? prt_pris1_oe { get; private set; }
        public string? id_prt_pris1_oe_desc { get; private set; }
        public string? lng_pris2_od { get; private set; }
        public string? id_lng_pris2_od_desc { get; private set; }
        public string? lng_pris2_oe { get; private set; }
        public string? id_lng_pris2_oe_desc { get; private set; }
        public string? prt_pris2_od { get; private set; }
        public string? id_prt_pris2_od_desc { get; private set; }
        public string? prt_pris2_oe { get; private set; }
        public string? id_prt_pris2_oe_desc { get; private set; }
        public string? dist_vertice { get; private set; }
        public string? inc_planto { get; private set; }
        public string? ativ_princ { get; private set; }
        public string? otico_area_privilegiada { get; private set; }
        public string? dist_visao { get; private set; }
        public string? personalizada { get; private set; }
        public string? pris_od { get; private set; }
        public string? pris_oe { get; private set; }
        public string? eixo_od { get; private set; }
        public string? eixo_oe { get; private set; }
        public string? borda_od { get; private set; }
        public string? borda_oe { get; private set; }
        public string? centro_od { get; private set; }
        public string? centro_oe { get; private set; }
        public string? furo_od { get; private set; }
        public string? furo_oe { get; private set; }
        public string? format_corte { get; private set; }
        public string? dist_leitura { get; private set; }
        public string? tipo_lente { get; private set; }
        public string? endereco_paciente { get; private set; }
        public string? medico_especialista { get; private set; }
        public string? endereco_medico_especialista { get; private set; }
        public string? refracionista_optico { get; private set; }
        public string? data_receita { get; private set; }
        public string? id_produtos_opticos_tipo_aro { get; private set; }
        public string? dp_montagem { get; private set; }
        public string? id_produtos_opticos_formato_aro { get; private set; }
        public string? codigo_gerencial { get; private set; }
        public bool? migracao_dados { get; private set; }
        public string? migracao_observacao { get; private set; }
        public string? portal { get; private set; }
        public string? timestamp { get; private set; }


        public LinxOticoReceitas() { }

        public LinxOticoReceitas(
            string? id_otico_receitas,
            string? cod_cliente,
            string? codigoproduto,
            string? lng_esferico_od,
            string? lng_cilindrico_od,
            string? lng_eixo_od,
            string? lng_dpdpn_od,
            string? lng_altura_od,
            string? prt_esferico_od,
            string? prt_cilindrico_od,
            string? prt_eixo_od,
            string? prt_dpdpn_od,
            string? lng_esferico_oe,
            string? lng_cilindrico_oe,
            string? lng_eixo_oe,
            string? lng_dpdpn_oe,
            string? lng_altura_oe,
            string? prt_esferico_oe,
            string? prt_cilindrico_oe,
            string? prt_eixo_oe,
            string? prt_dpdpn_oe,
            string? lng_adicao_od,
            string? lng_adicao_oe,
            string? otico_lado_lente,
            string? diametro_od,
            string? diametro_oe,
            string? ponte,
            string? altura,
            string? aro,
            string? diag_maior,
            string? tipo_armacao,
            string? observacao,
            string? paciente,
            string? cmpl_add_od,
            string? cmpl_add_oe,
            string? base_od,
            string? base_oe,
            string? dist_haste,
            string? dist_front,
            string? curvatura,
            string? lng_pris1_od,
            string? id_lng_pris1_od_desc,
            string? lng_pris1_oe,
            string? id_lng_pris1_oe_desc,
            string? prt_pris1_od,
            string? id_prt_pris1_od_desc,
            string? prt_pris1_oe,
            string? id_prt_pris1_oe_desc,
            string? lng_pris2_od,
            string? id_lng_pris2_od_desc,
            string? lng_pris2_oe,
            string? id_lng_pris2_oe_desc,
            string? prt_pris2_od,
            string? id_prt_pris2_od_desc,
            string? prt_pris2_oe,
            string? id_prt_pris2_oe_desc,
            string? dist_vertice,
            string? inc_planto,
            string? ativ_princ,
            string? otico_area_privilegiada,
            string? dist_visao,
            string? personalizada,
            string? pris_od,
            string? pris_oe,
            string? eixo_od,
            string? eixo_oe,
            string? borda_od,
            string? borda_oe,
            string? centro_od,
            string? centro_oe,
            string? furo_od,
            string? furo_oe,
            string? format_corte,
            string? dist_leitura,
            string? tipo_lente,
            string? endereco_paciente,
            string? medico_especialista,
            string? endereco_medico_especialista,
            string? refracionista_optico,
            string? data_receita,
            string? id_produtos_opticos_tipo_aro,
            string? dp_montagem,
            string? id_produtos_opticos_formato_aro,
            string? codigo_gerencial,
            bool? migracao_dados,
            string? migracao_observacao,
            string? portal,
            string? timestamp
        )
        {
            this.id_otico_receitas = id_otico_receitas;
            this.cod_cliente = cod_cliente;
            this.codigoproduto = codigoproduto;
            this.lng_esferico_od = lng_esferico_od;
            this.lng_cilindrico_od = lng_cilindrico_od;
            this.lng_eixo_od = lng_eixo_od;
            this.lng_dpdpn_od = lng_dpdpn_od;
            this.lng_altura_od = lng_altura_od;
            this.prt_esferico_od = prt_esferico_od;
            this.prt_cilindrico_od = prt_cilindrico_od;
            this.prt_eixo_od = prt_eixo_od;
            this.prt_dpdpn_od = prt_dpdpn_od;
            this.lng_esferico_oe = lng_esferico_oe;
            this.lng_cilindrico_oe = lng_cilindrico_oe;
            this.lng_eixo_oe = lng_eixo_oe;
            this.lng_dpdpn_oe = lng_dpdpn_oe;
            this.lng_altura_oe = lng_altura_oe;
            this.prt_esferico_oe = prt_esferico_oe;
            this.prt_cilindrico_oe = prt_cilindrico_oe;
            this.prt_eixo_oe = prt_eixo_oe;
            this.prt_dpdpn_oe = prt_dpdpn_oe;
            this.lng_adicao_od = lng_adicao_od;
            this.lng_adicao_oe = lng_adicao_oe;
            this.otico_lado_lente = otico_lado_lente;
            this.diametro_od = diametro_od;
            this.diametro_oe = diametro_oe;
            this.ponte = ponte;
            this.altura = altura;
            this.aro = aro;
            this.diag_maior = diag_maior;
            this.tipo_armacao = tipo_armacao;
            this.observacao = observacao;
            this.paciente = paciente;
            this.cmpl_add_od = cmpl_add_od;
            this.cmpl_add_oe = cmpl_add_oe;
            this.base_od = base_od;
            this.base_oe = base_oe;
            this.dist_haste = dist_haste;
            this.dist_front = dist_front;
            this.curvatura = curvatura;
            this.lng_pris1_od = lng_pris1_od;
            this.id_lng_pris1_od_desc = id_lng_pris1_od_desc;
            this.lng_pris1_oe = lng_pris1_oe;
            this.id_lng_pris1_oe_desc = id_lng_pris1_oe_desc;
            this.prt_pris1_od = prt_pris1_od;
            this.id_prt_pris1_od_desc = id_prt_pris1_od_desc;
            this.prt_pris1_oe = prt_pris1_oe;
            this.id_prt_pris1_oe_desc = id_prt_pris1_oe_desc;
            this.lng_pris2_od = lng_pris2_od;
            this.id_lng_pris2_od_desc = id_lng_pris2_od_desc;
            this.lng_pris2_oe = lng_pris2_oe;
            this.id_lng_pris2_oe_desc = id_lng_pris2_oe_desc;
            this.prt_pris2_od = prt_pris2_od;
            this.id_prt_pris2_od_desc = id_prt_pris2_od_desc;
            this.prt_pris2_oe = prt_pris2_oe;
            this.id_prt_pris2_oe_desc = id_prt_pris2_oe_desc;
            this.dist_vertice = dist_vertice;
            this.inc_planto = inc_planto;
            this.ativ_princ = ativ_princ;
            this.otico_area_privilegiada = otico_area_privilegiada;
            this.dist_visao = dist_visao;
            this.personalizada = personalizada;
            this.pris_od = pris_od;
            this.pris_oe = pris_oe;
            this.eixo_od = eixo_od;
            this.eixo_oe = eixo_oe;
            this.borda_od = borda_od;
            this.borda_oe = borda_oe;
            this.centro_od = centro_od;
            this.centro_oe = centro_oe;
            this.furo_od = furo_od;
            this.furo_oe = furo_oe;
            this.format_corte = format_corte;
            this.dist_leitura = dist_leitura;
            this.tipo_lente = tipo_lente;
            this.endereco_paciente = endereco_paciente;
            this.medico_especialista = medico_especialista;
            this.endereco_medico_especialista = endereco_medico_especialista;
            this.refracionista_optico = refracionista_optico;
            this.data_receita = data_receita;
            this.id_produtos_opticos_tipo_aro = id_produtos_opticos_tipo_aro;
            this.dp_montagem = dp_montagem;
            this.id_produtos_opticos_formato_aro = id_produtos_opticos_formato_aro;
            this.codigo_gerencial = codigo_gerencial;
            this.migracao_dados = migracao_dados;
            this.migracao_observacao = migracao_observacao;
            this.portal = portal;
            this.timestamp = timestamp;
        }
    }
}