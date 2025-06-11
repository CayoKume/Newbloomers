using Domain.IntegrationsCore.Entities.Enums;
using Domain.IntegrationsCore.Exceptions;
using Domain.LinxMicrovix.Outbound.WebService.Entities.Parameters;
using Domain.LinxMicrovix.Outbound.WebService.Interfaces.Repositorys.Base;
using Domain.LinxMicrovix.Outbound.WebService.Interfaces.Repositorys.LinxMicrovix;
using Domain.LinxMicrovix.Outbound.WebService.Entities.LinxMicrovix;

namespace Infrastructure.LinxMicrovix.Outbound.WebService.Repository.LinxMicrovix
{
    public class LinxLojasRepository : ILinxLojasRepository
    {
        private readonly ILinxMicrovixAzureSQLRepositoryBase<LinxLojas> _linxMicrovixRepositoryBase;

        public LinxLojasRepository(ILinxMicrovixAzureSQLRepositoryBase<LinxLojas> linxMicrovixRepositoryBase) =>
            (_linxMicrovixRepositoryBase) = (linxMicrovixRepositoryBase);

        public bool BulkInsertIntoTableRaw(LinxAPIParam jobParameter, IList<LinxLojas> records)
        {
            try
            {
                var table = _linxMicrovixRepositoryBase.CreateSystemDataTable(jobParameter.tableName, new LinxLojas());

                for (int i = 0; i < records.Count(); i++)
                {
                    table.Rows.Add(records[i].lastupdateon, records[i].portal, records[i].empresa, records[i].nome_emp, records[i].razao_emp, records[i].cnpj_emp,
                        records[i].inscricao_emp, records[i].endereco_emp, records[i].num_emp, records[i].complement_emp, records[i].bairro_emp, records[i].cep_emp,
                        records[i].cidade_emp, records[i].estado_emp, records[i].fone_emp, records[i].email_emp, records[i].cod_ibge_municipio, records[i].data_criacao_emp,
                        records[i].data_criacao_portal, records[i].sistema_tributacao, records[i].regime_tributario, records[i].area_empresa, records[i].timestamp,
                        records[i].sigla_empresa, records[i].id_classe_fiscal, records[i].centro_distribuicao, records[i].inscricao_municipal_emp, records[i].cnae_emp,
                        records[i].cod_cliente_linx, records[i].tabela_preco_preferencial);
                }

                _linxMicrovixRepositoryBase.BulkInsertIntoTableRaw(
                    dataTable: table,
                    dataTableRowsNumber: table.Rows.Count
                );

                return true;
            }
            catch
            {
                throw;
            }
        }

        public async Task<List<string>> GetRegistersExists()
        {
            try
            {
                string sql = $"SELECT CONCAT('[', EMPRESA, ']', '|', '[', CNPJ_EMP, ']', '|', '[', [TIMESTAMP], ']') FROM [linx_microvix_erp].[LinxLojas]";

                return await _linxMicrovixRepositoryBase.GetKeyRegistersAlreadyExists(sql);
            }
            catch (Exception ex) when (ex is not InternalException && ex is not SQLCommandException)
            {
                throw new InternalException(
                    stage: EnumStages.GetRegistersExists,
                    error: EnumError.Exception,
                    level: EnumMessageLevel.Error,
                    message: "Error when filling identifiers to sql command",
                    exceptionMessage: ex.Message
                );
            }
            catch
            {
                throw;
            }
        }

        public async Task<bool> InsertRecord(LinxAPIParam jobParameter, LinxLojas? record)
        {
            string? sql = @$"INSERT INTO [untreated].[{jobParameter.tableName}]
                            ([lastupdateon],[portal],[empresa],[nome_emp],[razao_emp],[cnpj_emp],[inscricao_emp],[endereco_emp],[num_emp],[complement_emp],[bairro_emp],[cep_emp],
                             [cidade_emp],[estado_emp],[fone_emp],[email_emp],[cod_ibge_municipio],[data_criacao_emp],[data_criacao_portal],[sistema_tributacao],[regime_tributario],
                             [area_empresa],[timestamp],[sigla_empresa],[id_classe_fiscal],[centro_distribuicao],[inscricao_municipal_emp],[cnae_emp],[cod_cliente_linx],
                             [tabela_preco_preferencial])
                            Values
                            (@lastupdateon,@portal,@empresa,@nome_emp,@razao_emp,@cnpj_emp,@inscricao_emp,@endereco_emp,@num_emp,@complement_emp,@bairro_emp,@cep_emp,@cidade_emp,@estado_emp,
                             @fone_emp,@email_emp,@cod_ibge_municipio,@data_criacao_emp,@data_criacao_portal,@sistema_tributacao,@regime_tributario,@area_empresa,@timestamp,@sigla_empresa,@id_classe_fiscal,
                             @centro_distribuicao,@inscricao_municipal_emp,@cnae_emp,@cod_cliente_linx,@tabela_preco_preferencial)";

            try
            {
                return await _linxMicrovixRepositoryBase.InsertRecord(jobParameter.tableName, sql: sql, record: record);
            }
            catch
            {
                throw;
            }
        }
    }
}
