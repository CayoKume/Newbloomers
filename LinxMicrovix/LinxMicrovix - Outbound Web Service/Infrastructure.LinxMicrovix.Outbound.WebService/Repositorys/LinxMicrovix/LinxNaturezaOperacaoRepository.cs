﻿using Domain.LinxMicrovix.Outbound.WebService.Entities.Parameters;
using Domain.LinxMicrovix.Outbound.WebService.Interfaces.Repositorys.Base;
using Domain.LinxMicrovix.Outbound.WebService.Interfaces.Repositorys.LinxMicrovix;
using Domain.LinxMicrovix.Outbound.WebService.Entities.LinxMicrovix;
using Domain.IntegrationsCore.Enums;
using Domain.IntegrationsCore.Entities.Exceptions;

namespace Infrastructure.LinxMicrovix.Outbound.WebService.Repository.LinxMicrovix
{
    public class LinxNaturezaOperacaoRepository : ILinxNaturezaOperacaoRepository
    {
        private readonly ILinxMicrovixRepositoryBase<LinxNaturezaOperacao> _linxMicrovixRepositoryBase;

        public LinxNaturezaOperacaoRepository(ILinxMicrovixRepositoryBase<LinxNaturezaOperacao> linxMicrovixRepositoryBase) =>
            (_linxMicrovixRepositoryBase) = (linxMicrovixRepositoryBase);

        public bool BulkInsertIntoTableRaw(LinxAPIParam jobParameter, IList<LinxNaturezaOperacao> records)
        {
            var table = _linxMicrovixRepositoryBase.CreateSystemDataTable(jobParameter.tableName, new LinxNaturezaOperacao());

            for (int i = 0; i < records.Count(); i++)
            {
                table.Rows.Add(records[i].lastupdateon, records[i].portal, records[i].cod_natureza_operacao, records[i].descricao, records[i].soma_relatorios, records[i].operacao,
                    records[i].inativa, records[i].timestamp, records[i].calcula_ipi, records[i].calcula_iss, records[i].calcula_irrf, records[i].tipo_preco,
                    records[i].atualiza_custo, records[i].transferencia, records[i].baixar_estoque, records[i].consumo_proprio, records[i].contabiliza_cmv, records[i].despesa, records[i].atualiza_custo_medio, records[i].exige_nf_origem,
                    records[i].integra_contabilidade, records[i].id_obs, records[i].venda_futura, records[i].base_icms_considera_ipi, records[i].permite_escolha_historico, records[i].import_produtos, records[i].deposito_reserva_venda,
                    records[i].exibe_nfe, records[i].faturamento_antecipado, records[i].exibir_informacoes_imposto, records[i].gera_garantia_nacional, records[i].transferencia_deposito, records[i].venda_diferencial_aliquota,
                    records[i].insere_obs_pis_cofins, records[i].diferencial_ativo_consumo, records[i].recusa_de, records[i].codigo_ws);
            }

            _linxMicrovixRepositoryBase.BulkInsertIntoTableRaw(
                dataTable: table
            );

            return true;
        }

        public async Task<IEnumerable<string?>> GetRegistersExists()
        {
            string sql = $"SELECT CONCAT('[', TRIM(COD_NATUREZA_OPERACAO), ']', '|', '[', [TIMESTAMP], ']') FROM [linx_microvix_erp].[LinxNaturezaOperacao]";

            return await _linxMicrovixRepositoryBase.GetKeyRegistersAlreadyExists(sql);
        }

        public async Task<bool> InsertRecord(LinxAPIParam jobParameter, LinxNaturezaOperacao? record)
        {
            string? sql = @$"INSERT INTO [untreated].[{jobParameter.tableName}] 
                            ([lastupdateon],[portal],[cod_natureza_operacao],[descricao],[soma_relatorios],[operacao],[inativa],[timestamp],[calcula_ipi],[calcula_iss],[calcula_irrf],
                             [tipo_preco],[atualiza_custo],[transferencia],[baixar_estoque],[consumo_proprio],[contabiliza_cmv],[despesa],[atualiza_custo_medio],[exige_nf_origem],
                             [integra_contabilidade],[id_obs],[venda_futura],[base_icms_considera_ipi],[permite_escolha_historico],[import_produtos],[deposito_reserva_venda],[exibe_nfe],
                             [faturamento_antecipado],[exibir_informacoes_imposto],[gera_garantia_nacional],[transferencia_deposito],[venda_diferencial_aliquota],[insere_obs_pis_cofins],
                             [diferencial_ativo_consumo],[recusa_de],[codigo_ws])
                            Values
                            (@lastupdateon,@portal,@cod_natureza_operacao,@descricao,@soma_relatorios,@operacao,@inativa,@timestamp,@calcula_ipi,@calcula_iss,@calcula_irrf,@tipo_preco,
                             @atualiza_custo,@transferencia,@baixar_estoque,@consumo_proprio,@contabiliza_cmv,@despesa,@atualiza_custo_medio,@exige_nf_origem,@integra_contabilidade,
                             @id_obs,@venda_futura,@base_icms_considera_ipi,@permite_escolha_historico,@import_produtos,@deposito_reserva_venda,@exibe_nfe,@faturamento_antecipado,
                             @exibir_informacoes_imposto,@gera_garantia_nacional,@transferencia_deposito,@venda_diferencial_aliquota,@insere_obs_pis_cofins,@diferencial_ativo_consumo,
                             @recusa_de,@codigo_ws)";

            return await _linxMicrovixRepositoryBase.InsertRecord(jobParameter.tableName, sql: sql, record: record);
        }
    }
}
