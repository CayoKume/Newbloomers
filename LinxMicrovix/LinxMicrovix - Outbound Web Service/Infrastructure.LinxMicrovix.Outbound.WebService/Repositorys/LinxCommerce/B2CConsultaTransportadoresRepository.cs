using Domain.IntegrationsCore.Entities.Exceptions;
using Domain.IntegrationsCore.Enums;
using Domain.LinxMicrovix.Outbound.WebService.Entities.LinxCommerce;
using Domain.LinxMicrovix.Outbound.WebService.Entities.Parameters;
using Domain.LinxMicrovix.Outbound.WebService.Interfaces.Repositorys.Base;
using Domain.LinxMicrovix.Outbound.WebService.Interfaces.Repositorys.LinxCommerce;

namespace Infrastructure.LinxMicrovix.Outbound.WebService.Repository.LinxCommerce
{
    public class B2CConsultaTransportadoresRepository : IB2CConsultaTransportadoresRepository
    {
        private readonly ILinxMicrovixRepositoryBase<B2CConsultaTransportadores> _linxMicrovixRepositoryBase;

        public B2CConsultaTransportadoresRepository(ILinxMicrovixRepositoryBase<B2CConsultaTransportadores> linxMicrovixRepositoryBase) =>
            (_linxMicrovixRepositoryBase) = (linxMicrovixRepositoryBase);

        public bool BulkInsertIntoTableRaw(LinxAPIParam jobParameter, IList<B2CConsultaTransportadores> records)
        {
            var table = _linxMicrovixRepositoryBase.CreateSystemDataTable(jobParameter.tableName, new B2CConsultaTransportadores());

            for (int i = 0; i < records.Count(); i++)
            {
                table.Rows.Add(records[i].lastupdateon, records[i].cod_transportador, records[i].nome, records[i].nome_fantasia, records[i].tipo_pessoa, records[i].tipo_transportador, records[i].endereco, records[i].numero_rua,
                    records[i].bairro, records[i].cep, records[i].cidade, records[i].uf, records[i].documento, records[i].fone, records[i].email, records[i].pais, records[i].obs, records[i].timestamp, records[i].portal);
            }

            _linxMicrovixRepositoryBase.BulkInsertIntoTableRaw(
                dataTable: table
            );

            return true;
        }

        public async Task<IEnumerable<string?>> GetRegistersExists(LinxAPIParam jobParameter, List<B2CConsultaTransportadores> registros)
        {
            var identificadores = String.Empty;
            for (int i = 0; i < registros.Count(); i++)
            {
                if (i == registros.Count() - 1)
                    identificadores += $"'{registros[i].documento}'";
                else
                    identificadores += $"'{registros[i].documento}', ";
            }

            string sql = $"SELECT CONCAT('[', DOCUMENTO, ']', '|', '[', [TIMESTAMP], ']') FROM [linx_microvix_commerce].[B2CCONSULTATRANSPORTADORES] WHERE DOCUMENTO IN ({identificadores})";

            return await _linxMicrovixRepositoryBase.GetKeyRegistersAlreadyExists(sql);
        }

        public async Task<bool> InsertRecord(LinxAPIParam jobParameter, B2CConsultaTransportadores? record)
        {
            string? sql = $"INSERT INTO {jobParameter.tableName} " +
                          "([lastupdateon], [cod_transportador], [nome], [nome_fantasia], [tipo_pessoa], [tipo_transportador], [endereco], [numero_rua], [bairro], [cep], [cidade], [uf], [documento], [fone], [email], [pais], [obs], [timestamp], [portal]) " +
                          "Values " +
                          "(@lastupdateon, @cod_transportador, @nome, @nome_fantasia, @tipo_pessoa, @tipo_transportador, @endereco, @numero_rua, @bairro, @cep, @cidade, @uf, @documento, @fone, @email, @pais, @obs, @timestamp, @portal)";

            return await _linxMicrovixRepositoryBase.InsertRecord(jobParameter.tableName, sql: sql, record: record);
        }
    }
}
