using Domain.IntegrationsCore.Entities.Parameters;
using Domain.LinxMicrovix_Outbound_Web_Service.Entites.LinxCommerce;
using Domain.LinxMicrovix_Outbound_Web_Service.Interfaces.Repositorys.Base;
using Domain.LinxMicrovix_Outbound_Web_Service.Interfaces.Repositorys.LinxCommerce;

namespace Infrastructure.LinxMicrovix_Outbound_Web_Service.Repository.LinxCommerce
{
    public class B2CConsultaClientesContatosRepository : IB2CConsultaClientesContatosRepository
    {
        private readonly ILinxMicrovixRepositoryBase<B2CConsultaClientesContatos> _linxMicrovixRepositoryBase;

        public B2CConsultaClientesContatosRepository(ILinxMicrovixRepositoryBase<B2CConsultaClientesContatos> linxMicrovixRepositoryBase) =>
            (_linxMicrovixRepositoryBase) = (linxMicrovixRepositoryBase);

        public bool BulkInsertIntoTableRaw(LinxMicrovixJobParameter jobParameter, List<B2CConsultaClientesContatos> records)
        {
            try
            {
                var table = _linxMicrovixRepositoryBase.CreateSystemDataTable(jobParameter, new B2CConsultaClientesContatos());

                for (int i = 0; i < records.Count(); i++)
                {
                    table.Rows.Add(records[i].lastupdateon, records[i].id_clientes_contatos, records[i].id_contato_b2c, records[i].nome_contato, records[i].data_nasc_contato, records[i].sexo_contato,
                        records[i].id_parentesco, records[i].fone_contato, records[i].celular_contato, records[i].email_contato, records[i].cod_cliente_erp, records[i].timestamp, records[i].portal);
                }

                _linxMicrovixRepositoryBase.BulkInsertIntoTableRaw(
                    jobParameter: jobParameter,
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

        public async Task<bool> CreateTableMerge(LinxMicrovixJobParameter jobParameter)
        {
            string? sql = @"IF NOT EXISTS (SELECT * FROM SYS.OBJECTS WHERE TYPE = 'P' AND NAME = 'P_B2CCONSULTACLIENTESCONTATOS_SYNC')
                           BEGIN
                           EXECUTE (
	                           'CREATE PROCEDURE [P_B2CCONSULTACLIENTESCONTATOS_SYNC] AS
	                           BEGIN
		                           MERGE [B2CCONSULTACLIENTESCONTATOS_TRUSTED] AS TARGET
                                   USING [B2CCONSULTACLIENTESCONTATOS_RAW] AS SOURCE

                                   ON (
			                           TARGET.ID_CLIENTES_CONTATOS = SOURCE.ID_CLIENTES_CONTATOS
		                           )
        
		                           WHEN MATCHED AND SOURCE.[TIMESTAMP] != TARGET.[TIMESTAMP] THEN 
			                           UPDATE SET
			                           TARGET.[LASTUPDATEON] = SOURCE.[LASTUPDATEON],
			                           TARGET.[ID_CLIENTES_CONTATOS] = SOURCE.[ID_CLIENTES_CONTATOS],
			                           TARGET.[ID_CONTATO_B2C] = SOURCE.[ID_CONTATO_B2C],
			                           TARGET.[NOME_CONTATO] = SOURCE.[NOME_CONTATO],
			                           TARGET.[DATA_NASC_CONTATO] = SOURCE.[DATA_NASC_CONTATO],
			                           TARGET.[SEXO_CONTATO] = SOURCE.[SEXO_CONTATO],
			                           TARGET.[ID_PARENTESCO] = SOURCE.[ID_PARENTESCO],
			                           TARGET.[FONE_CONTATO] = SOURCE.[FONE_CONTATO],
			                           TARGET.[CELULAR_CONTATO] = SOURCE.[CELULAR_CONTATO],
			                           TARGET.[EMAIL_CONTATO] = SOURCE.[EMAIL_CONTATO],
			                           TARGET.[COD_CLIENTE_ERP] = SOURCE.[COD_CLIENTE_ERP],
			                           TARGET.[TIMESTAMP] = SOURCE.[TIMESTAMP],
			                           TARGET.[PORTAL] = SOURCE.[PORTAL]

                                   WHEN NOT MATCHED BY TARGET AND SOURCE.[ID_CLIENTES_CONTATOS] NOT IN (SELECT [ID_CLIENTES_CONTATOS] FROM [B2CCONSULTACLIENTESCONTATOS_TRUSTED]) THEN
			                           INSERT
			                           ([LASTUPDATEON], [ID_CLIENTES_CONTATOS], [ID_CONTATO_B2C], [NOME_CONTATO], [DATA_NASC_CONTATO], [SEXO_CONTATO],
			                           [ID_PARENTESCO], [FONE_CONTATO], [CELULAR_CONTATO], [EMAIL_CONTATO], [COD_CLIENTE_ERP], [TIMESTAMP], [PORTAL])
			                           VALUES
			                           (SOURCE.[LASTUPDATEON], SOURCE.[ID_CLIENTES_CONTATOS], SOURCE.[ID_CONTATO_B2C], SOURCE.[NOME_CONTATO], SOURCE.[DATA_NASC_CONTATO], SOURCE.[SEXO_CONTATO],
			                           SOURCE.[ID_PARENTESCO], SOURCE.[FONE_CONTATO], SOURCE.[CELULAR_CONTATO], SOURCE.[EMAIL_CONTATO], SOURCE.[COD_CLIENTE_ERP], SOURCE.[TIMESTAMP], SOURCE.[PORTAL]);
	                           END'
                           )
                           END";

            try
            {
                return await _linxMicrovixRepositoryBase.ExecuteQueryCommand(jobParameter: jobParameter, sql: sql);
            }
            catch
            {
                throw;
            }
        }

        public async Task<bool> InsertParametersIfNotExists(LinxMicrovixJobParameter jobParameter)
        {
            try
            {
                return await _linxMicrovixRepositoryBase.InsertParametersIfNotExists(
                    jobParameter: jobParameter,
                    parameter: new
                    {
                        method = jobParameter.jobName,
                        parameters_timestamp = @"<Parameter id=""timestamp"">[0]</Parameter>",
                        parameters_dateinterval = @"<Parameter id=""timestamp"">[0]</Parameter>",
                        parameters_individual = @"<Parameter id=""timestamp"">[0]</Parameter>",
                        ativo = 1
                    }
                );
            }
            catch
            {
                throw;
            }
        }

        public async Task<bool> InsertRecord(LinxMicrovixJobParameter jobParameter, B2CConsultaClientesContatos? record)
        {
            string? sql = $"INSERT INTO {jobParameter.tableName}_raw " +
                          "([lastupdateon], [id_clientes_contatos], [id_contato_b2c], [nome_contato], [data_nasc_contato], [sexo_contato], " + 
                          "[id_parentesco], [fone_contato], [celular_contato], [email_contato], [cod_cliente_erp], [timestamp], [portal])" +
                          "Values " +
                          "(@lastupdateon, @id_clientes_contatos, @id_contato_b2c, @nome_contato, @data_nasc_contato, @sexo_contato, @id_parentesco, " + 
                          "@fone_contato, @celular_contato, @email_contato, @cod_cliente_erp, @timestamp, @portal)";

            try
            {
                return await _linxMicrovixRepositoryBase.InsertRecord(jobParameter: jobParameter, sql: sql, record: record);
            }
            catch
            {
                throw;
            }
        }
    }
}
